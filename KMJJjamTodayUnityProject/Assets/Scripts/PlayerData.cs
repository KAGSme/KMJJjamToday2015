using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public static PlayerData pd;
    public int maxHealth = 3;
    int health;
    int score;
    int finalScore;

    public int Score{
        get { return score; }
        set { score = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public void HealthChange(int value)
    {
        health += value; 
    }

    void Start()
    {
        if (pd == null) {
            pd = this;
            DontDestroyOnLoad(this); 
        }
        else Destroy(this);

        score = 0;
        health = maxHealth;
    }
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        score = (int)timer * 10;
        if (health <= 0)
        {
            finalScore = score;
            Application.LoadLevel("MainMenu");
        }
    }
}
