using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public static PlayerData pd;
    public int maxHealth = 3;
    int health;
    int score;
    int finalScore;

    public void healthChange(int value)
    {
        health += value; 
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (health <= 0)
        {
            Application.LoadLevel("");
        }
    }
}
