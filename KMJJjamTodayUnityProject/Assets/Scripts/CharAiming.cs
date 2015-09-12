using UnityEngine;
using System.Collections;

public class CharAiming : MonoBehaviour {

    public GameObject rotObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var angle = Mathf.Atan2(-Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical")) * Mathf.Rad2Deg;
        if (Input.GetAxis("RVertical") == 0 && Input.GetAxis("RHorizontal") == 0) rotObject.gameObject.SetActive(false);
        else rotObject.gameObject.SetActive(true);
            rotObject.transform.rotation = Quaternion.Euler(0,0, angle);
	}
}
