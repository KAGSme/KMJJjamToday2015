using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public LayerMask laserHit;
    float distance = 0;
    public float Speed = 10;
    [HideInInspector]
    public Vector2 angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var ray = Physics2D.Raycast(transform.position, angle, distance += Speed * Time.deltaTime, laserHit);
        if (ray.collider != null)
        {
            Debug.Log("Hit");
            Destroy(ray.collider.gameObject);
        }
	}
}
