﻿using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public float xoffset = 0.03f;
    public float yoffset = 0.03f;
    public float width = 0.3f;
    public float height = 0.3f;
    public float radius = 0.5f;
    public GameObject EnemyPrefab;
    public GameObject AmmoPrefab;
   // public int enemyMax = 6;
    public int enemyMin = 4;
    public float curve = 0.1f;
    public float curvature = 0.5f;
    public float scale = 0.1f;
    public float track = 0;
    public float desEnemyCnt;
    public float minTime = 2;
    public float maxTime = 4;
   // float enemyNum;
    bool left = true;
    float rand;
    public static SpawnScript spawnthingy;
    float ammoTimer;

    public AudioClip Musick, Kick;
    float Beat = 0.851f;
    float EnDelay = -0.10f;
    float NextKick;
    int BeatI =0;

    AudioSource[] Sauces = new AudioSource[3];
    int SauceI = 0;

	// Use this for initializatio
	void Start () {
        spawnthingy = this;
        //enemyNum = Random.Range(enemyMin, enemyMax);


        for(int i = 3;i-- >0;) { 
            var src = Sauces[i] = gameObject.AddComponent<AudioSource>();
            src.clip = i==2? Musick : Kick;
        }
        float delay = 0.75f;
        NextKick =delay +Beat *2;
        Sauces[1].PlayScheduled( delay );
        Invoke( "SpawnEnemy", delay+ EnDelay );
        BeatI++;
	}



    void SpawnEnemy( )
    {
        float difficultyAdd = (Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
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

        /*
        var dm =  (Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
        desEnemyCnt = (float)enemyMin + (Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
        int desEnemyNo = enemyMin + (int)(Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
 
        if(track < desEnemyNo)
        {
            SpawnEnemy( dm );
        } */

        if((NextKick -= Time.deltaTime) < 1 ) {

            if((++BeatI) == 3) {
                BeatI = -1;
            } else { 
                Sauces[SauceI=1-SauceI].PlayScheduled( NextKick );
                Invoke( "SpawnEnemy", NextKick+EnDelay );             
            }
            NextKick +=Beat;
        }

        if((ammoTimer -= Time.deltaTime) < 0)
        {
            SpawnAmmo();
            ammoTimer = Random.Range(minTime, maxTime);
        }

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
