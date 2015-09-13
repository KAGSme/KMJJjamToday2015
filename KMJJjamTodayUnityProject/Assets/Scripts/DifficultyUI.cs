using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyUI : MonoBehaviour {

    Text difficultyUItxt;

    void Start()
    {
        difficultyUItxt = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if(PlayerData.pd.difficulty <= 0.1)
        {
            difficultyUItxt.text = "Difficulty: " + PlayerData.pd.difficultyNames[0];
        }
        if (PlayerData.pd.difficulty > 0.1 && PlayerData.pd.difficulty <= 0.4)
        {
            difficultyUItxt.text = "Difficulty: " + PlayerData.pd.difficultyNames[1];
        }
        if (PlayerData.pd.difficulty > 0.4 && PlayerData.pd.difficulty <= 0.7)
        {
            difficultyUItxt.text = "Difficulty: " + PlayerData.pd.difficultyNames[2];
        }
        if (PlayerData.pd.difficulty > 0.7 && PlayerData.pd.difficulty <= 1)
        {
            difficultyUItxt.text = "Difficulty: " + PlayerData.pd.difficultyNames[3];
        }
	}
}
