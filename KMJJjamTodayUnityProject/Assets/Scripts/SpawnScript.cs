using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public float xoffset = 0.03f;
    public float yoffset = 0.03f;
    public float width = 0.3f;
    public float height = 0.3f;
    public GameObject EnemyPrefab;
    public int enemyMax = 6;
    public int enemyMin = 4;
    public float curve = 0.1f;
    public float curvature = 0.5f;
    public float scale = 0.1f;
    float track = 0;
    float enemyNum;
    bool left = true;
    float rand;
    static SpawnScript spawnthingy;

	// Use this for initializatio
	void Start () {

        //enemyNum = Random.Range(enemyMin, enemyMax);
	
	}

    void SpawnEnemy()
    {

        var Pos = Vector3.zero;

        if (left)
        {
            Pos.x = ((xoffset + width * Random.value) * Screen.width);
            left = false;
        }

        else
        {
            Pos.x = (Screen.width - (xoffset + width * Random.value));
            left = true;
        }

        rand = Random.value;

        if(rand > 0.5)
        {
            Pos.y = ((yoffset + height * Random.value) * Screen.height);
        }
        else
        {
            Pos.y = (Screen.height - (yoffset + height * Random.value));
        }

        Pos = Camera.main.ScreenToWorldPoint(Pos);
        Pos.z = 0.0f;

        Instantiate(EnemyPrefab, Pos, Quaternion.identity);
        track += 1;
        Debug.Log("hellllllo");

    }
	
	// Update is called once per frame
	void Update () {

        int desEnemyNo = enemyMin + (int)(Mathf.Pow(Time.timeSinceLevelLoad, curvature) * scale);
 
        if(track < desEnemyNo)
        {
            SpawnEnemy();
        }
	}
}
