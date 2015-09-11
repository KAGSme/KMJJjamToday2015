using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class CharController : MonoBehaviour {

    public float maxSpeed = 100;
    Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddRelativeForce(new Vector2(Input.GetAxis("Horizontal") * maxSpeed, Input.GetAxis("Vertical") * maxSpeed));
	}
}
