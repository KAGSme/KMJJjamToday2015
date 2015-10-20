using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public AudioClip hit;
    public LayerMask laserHit;
    float distance = 0;
    public float Speed = 10;
    public int enemyKillPoints = 100;
    [HideInInspector]
    public Vector2 angle;
    public AudioSource lasor;
	public GameObject explosionObject;

	// Use this for initialization
	void Start () {

        lasor = GetComponent<AudioSource>();
        lasor.Play();
	
	}
	
	// Update is called once per frame
    void Update()
    {
        var ray = Physics2D.Raycast(transform.position, angle, distance += Speed * Time.deltaTime, laserHit);
        if (ray.collider != null)
        {
            if (ray.collider.gameObject.tag == "Player")
            {
                if( PlayerData.pd != null ){
                    PlayerData.pd.HealthChange(-1);
                    Destroy(this);
                    lasor.PlayOneShot(hit);
                }
            }
            else if(ray.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit " + enemyKillPoints);
                Destroy(ray.collider.gameObject);
                PlayerData.pd.AScore += enemyKillPoints;
				var explosion = (GameObject)Instantiate(explosionObject, ray.collider.gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
