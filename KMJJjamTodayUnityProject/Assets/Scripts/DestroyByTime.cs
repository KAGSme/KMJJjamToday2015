using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float timeToDestroy = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0) DestroyObject(this.gameObject);
	}
}
