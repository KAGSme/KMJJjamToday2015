using UnityEngine;
using System.Collections;

public class CharAiming : MonoBehaviour {

    public GameObject rotObject;
    public GameObject laserPrefab;
    public GameObject isLoadedTexture;
    public bool isLoaded = false;

	// Use this for initialization
	void Start () {
        isLoaded = false;
        isLoadedTexture.GetComponent<SpriteRenderer>().color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetJoystickNames().Length > 0) { 
            var angle = Mathf.Atan2(-Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical")) * Mathf.Rad2Deg;
            if (Input.GetAxis("RVertical") == 0 && Input.GetAxis("RHorizontal") == 0) rotObject.gameObject.SetActive(false);
            else{
                rotObject.gameObject.SetActive(true);
                rotObject.transform.rotation = Quaternion.Euler(0,0, angle);

                if (Input.GetAxis("FireR") > 0 && isLoaded)
                {
                    var laser = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.Euler(0,0,angle));
                    laser.GetComponent<Laser>().angle = new Vector2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"));
                    isLoadedTexture.GetComponent<SpriteRenderer>().color = Color.clear;
                    isLoaded = false;
                }
            }
        } else { 
            var vec = (Vector2) Camera.main.ScreenToWorldPoint( Input.mousePosition ) - (Vector2)transform.position;
            if( vec.sqrMagnitude < 0.01f ) rotObject.gameObject.SetActive(false);
            else{ 
                rotObject.gameObject.SetActive(true);
                rotObject.transform.rotation = Quaternion.Euler(0,0, Mathf.Atan2(-vec.x, vec.y) * Mathf.Rad2Deg);

                if (Input.GetButtonDown("Fire1") && isLoaded)
                {
                    var laser = (GameObject)Instantiate(laserPrefab, transform.position, rotObject.transform.rotation );
                    laser.GetComponent<Laser>().angle = vec;
                    isLoadedTexture.GetComponent<SpriteRenderer>().color = Color.clear;
                    isLoaded = false;
                }
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "AmmoPickup")
        {
            Destroy(other.gameObject);
            isLoaded = true;
            isLoadedTexture.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
