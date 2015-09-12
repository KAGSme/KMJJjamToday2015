using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour {

    public float maxForce;
    Rigidbody2D player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var direction = transform.position - player.gameObject.transform.position;
        var force = Mathf.Clamp(maxForce / direction.magnitude, 10, maxForce);
        player.AddRelativeForce(direction.normalized * force);
	}
}   

// Andrew was in this code, you have to add me to the credits of the game, i take 10% royalties
