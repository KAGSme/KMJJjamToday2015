using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public float xoffset = 0.03f;
    public float width = 0.015f;
    public GameObject EnemyPrefab;

	// Use this for initialization
	void Start () {

        bool left = true;
        var Pos = Vector3.zero;

        if(left)
        {
            Pos.x = ((xoffset + width * Random.value) * Screen.width);
            //Pos.y = Screen.height;
        }

        else
        {
            Pos.x = (Screen.width - (xoffset + width * Random.value));
        }
        Debug.Log("hellllllo" + Pos);
        Pos = Camera.main.ScreenToWorldPoint(Pos);
        Pos.z = 0.0f;

        Instantiate(EnemyPrefab, Pos, Quaternion.identity);

        Debug.Log("hellllllo" + Pos);
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
