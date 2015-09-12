using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreUI : MonoBehaviour {

    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + PlayerData.pd.Score.ToString();
	}
}
