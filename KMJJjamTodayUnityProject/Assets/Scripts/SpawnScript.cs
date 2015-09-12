using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public float xoffset = 0.03f;
    public float yoffset = 0.03f;
    public float width = 0.3f;
    public float height = 0.3f;
    public float radius = 20.0f;
    public GameObject EnemyPrefab;
    public GameObject AmmoPrefab;
   // public int enemyMax = 6;
    public int enemyMin = 4;
    public float curve = 0.1f;
    public float curvature = 0.5f;
    public float scale = 0.1f;
    public float track = 0;
    public float desEnemyCnt;
   // float enemyNum;
    bool left = true;
    float rand;
    public static SpawnScript spawnthingy;

	// Use this for initializatio
	void Start () {
        spawnthingy = this;
        //enemyNum = Random.Range(enemyMin, enemyMax);
	
	}

    void SpawnEnemy(float difficultyAdd )
    {

        var Pos = Vector3.zero;

        if (left)
        {
            Pos.x = (xoffset + width * Random.value)* Screen.width;
            left = false;
        }

        else
        {
            Pos.x = (1.0f - (xoffset + width * Random.value))* Screen.width;
            left = true;
        }

        rand = Random.value;

        if(rand > 0.5)
        {
            Pos.y =  Screen.height +yoffset; //((yoffset + height * Random.value) * Screen.height);
        }
        else
        {
            Pos.y = -yoffset;//(Screen.height - (yoffset + height * Random.value));
        }

        Pos = Camera.main.ScreenToWorldPoint(Pos);
        Pos.z = 0.0f;

        var go = Instantiate(EnemyPrefab, Pos, Quaternion.identity) as GameObject;
        track += 1;
        Debug.Log("hellllllo");

        difficultyAdd += 0.2f;
        difficultyAdd*= 0.5f + Random.value;
        var en = go.GetComponent<Enemy>();
        var sm = difficultyAdd *0.1;
        en.WanderMn *= en.Speed;
        en.Speed *= (1.0f+ difficultyAdd*0.1f );
        var md = 1.0f + difficultyAdd *0.06f;
        en.ChargeTime /= md;
        en.Accel /= md;
        Debug.Log("en speed "+ en.Speed+"  ChargeTime "+ en.ChargeTime );
        en.WanderMn /= en.Speed;
    }

    void SpawnAmmo()
    {
       Instantiate(AmmoPrefab, (Vector3)Random.insideUnitCircle * radius, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {

        var dm =  (Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
        desEnemyCnt = (float)enemyMin + (Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
        int desEnemyNo = enemyMin + (int)(Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
 
        if(track < desEnemyNo)
        {
            SpawnEnemy( dm );
        }

        SpawnAmmo();
	}

    public void delayedRespawn() {

        StartCoroutine( _delayedRespawn() );
    }
    IEnumerator _delayedRespawn() {
        yield return new WaitForSeconds(0.7f);
        track--;
    }
    //yo
}
