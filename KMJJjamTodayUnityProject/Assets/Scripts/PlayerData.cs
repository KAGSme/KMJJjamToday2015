using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

    public static PlayerData pd;
    public int maxHealth = 3;
    public float difficulty;
    public string[] difficultyNames;

    public float DiffC1 = 0.5f;
    public float DiffC2 = 2.0f;
    public float DifficultyModifer;

    public GameObject ScoreTextPopUp;

    void calcDiffMod() {
        System.Func<float, float, float, float, float> quad = ( float a, float b, float c, float t) => {
            var ret   = a*(t - 0.5f)*(t - 1.0f)/((0.0f - 0.5f)*(0.0f - 1.0f));
            ret += b*(t - 0.0f)*(t - 1.0f)/((0.5f - 0.0f)*(0.5f - 1.0f));
            ret += c*(t - 0.0f)*(t - 0.5f)/((1.0f - 0.0f)*(1.0f - 0.5f));
            return ret;
        };

        DifficultyModifer = quad( DiffC1, 1, DiffC2, difficulty );
    }

    int health;
    int score;
    int aScore;
    int tScore;
    public bool isInvincible = false;
    float iTimer = 1;
    GameObject iParticles;

    public void Difficulty(float valueChange)
    {
        difficulty = valueChange;
    }

    public int Score{
        get { return score; }
        set { score = value; }
    }

    public int AScore
    {
        get { return aScore; }
        set {
            aScore = value;
            GameObject stp;
            stp = Instantiate(ScoreTextPopUp, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity) as GameObject;
            stp.GetComponentInChildren<Text>().text = value.ToString();
        }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public void HealthChange(int value)
    {
        if (!isInvincible)
        {
            iParticles.SetActive(true);
            health += value;
            isInvincible = true;
        }
    }

    void OnLevelWasLoaded(int Level)
    {
        if( pd != this ) return;
        if (Level == 1)
        {
            isInvincible = false;
            score = 0;
            tScore = 0;
            aScore = 0;
            timer = 0;
            health = maxHealth;
            
            iParticles = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>().iParticles;
            iParticles.SetActive(false);

            calcDiffMod();
        } else  if(Level == 0) { //jim -- reference broken on return to scene
           // var go = GameObject.Find( "Difficulty Slider"); UnityEngine.UI.Slider sldr;
            var am = FindObjectOfType<ApplicationManager>(); UnityEngine.UI.Slider sldr =null;
            if(am != null && (sldr=am.DifficultySlider) != null ) {
                sldr.onValueChanged.RemoveAllListeners();
                sldr.value = difficulty;
                sldr.onValueChanged.AddListener( Difficulty );
                Difficulty( sldr.value );
            }
            //Debug.Log(" am "+am+"  sldr "+sldr );
        }
        
    }

    void Start()
    {

        if (pd == null) {
            pd = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else Destroy(this);


        calcDiffMod();
    }
    float timer;
    void Update()
    {
        if (Application.loadedLevelName == "MainLevel")
        {
            timer += Time.deltaTime;
            tScore = (int)timer * 10;
            score = aScore + tScore;
            if (health <= 0)
            {
                Application.LoadLevel("EndScene");
            }

            if (isInvincible)
            {
                if ((iTimer -= Time.deltaTime) <= 0)
                {
                    iParticles.SetActive(false);
                    isInvincible = false;
                    iTimer = 1;
                }
            }
        }
    }
}
