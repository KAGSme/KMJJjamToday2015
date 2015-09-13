using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {

    public GameObject whiteFlash;
	
	// Update is called once per frame
	void Update () {
        whiteFlash.GetComponent<SpriteRenderer>().color = Vector4.MoveTowards(whiteFlash.GetComponent<SpriteRenderer>().color, Color.clear, Time.deltaTime);
	}
}
