using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public LayerMask laserHit;
    float distance = 0;
    public float Speed = 10;
    public int enemyKillPoints = 100;
    [HideInInspector]
    public Vector2 angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        var ray = Physics2D.Raycast(transform.position, angle, distance += Speed * Time.deltaTime, laserHit);
        if (ray.collider != null)
        {
            if (ray.collider.gameObject.tag == "Player")
            {
                if( PlayerData.pd != null ) PlayerData.pd.HealthChange(-1);
            }
            else
            {
                Debug.Log("Hit " + enemyKillPoints);
                Destroy(ray.collider.gameObject);
                PlayerData.pd.AScore += enemyKillPoints;
            }
        }
    }
}
