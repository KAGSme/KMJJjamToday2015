using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {

    public float spinSpeed = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,spinSpeed * Time.deltaTime));
	}
}
