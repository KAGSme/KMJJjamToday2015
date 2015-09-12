using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public static PlayerData pd;
    public int maxHealth = 3;
    int health;
    int score;
    int finalScore;
    public bool isInvincible = false;
    float iTimer = 1;

    public int Score{
        get { return score; }
        set { score = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public void HealthChange(int value)
    {
        if (!isInvincible)
        {
            health += value;
            isInvincible = true;
        }
    }

    void Start()
    {
        if (pd == null) {
            pd = this;
            DontDestroyOnLoad(this); 
        }
        else Destroy(this);

        score = 0;
        health = maxHealth;
    }
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        score = (int)timer * 10;
        if (health <= 0)
        {
            finalScore = score;
            Application.LoadLevel("MainMenu");
        }

        if (isInvincible)
        {
            if ((iTimer -= Time.deltaTime) <= 0)
            {
                isInvincible = false;
                iTimer = 1;
            }
        }
    }
}
