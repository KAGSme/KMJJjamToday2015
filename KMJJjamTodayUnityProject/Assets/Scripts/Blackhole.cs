using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour {

    public float maxForce= 500;
    public float speed = 20;
    Rigidbody2D player;
    public Transform[] travelPoints;
    Transform currentDestination;
    public bool moves = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        if (moves)
        {
            if (currentDestination == null)
            {
                currentDestination = travelPoints[Random.Range(0, travelPoints.Length)];
            }
            if (currentDestination != null)
            {
                transform.position = Vector3.Slerp(transform.position, currentDestination.position, Time.deltaTime * speed);
                if (Mathf.Abs(Vector3.Magnitude(currentDestination.position - transform.position)) < 1.0f)
                {
                    currentDestination = travelPoints[Random.Range(0, travelPoints.Length)];
                }
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        var direction = transform.position - player.gameObject.transform.position;
        var force = Mathf.Clamp(maxForce / direction.magnitude, 10, maxForce);
        player.AddRelativeForce(direction.normalized * force);
	}
}   

// Andrew was in this code, you have to add me to the credits of the game, i take 10% royalties
