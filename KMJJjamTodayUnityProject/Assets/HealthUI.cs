using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    Image healthBar;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = (float)PlayerData.pd.Health / (float)PlayerData.pd.maxHealth;
	}
}
