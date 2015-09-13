﻿using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public static PlayerData pd;
    public int maxHealth = 3;
    int health;
    int score;
    int finalScore;
    public bool isInvincible = false;
    float iTimer = 1;
    GameObject iParticles;

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
            iParticles.SetActive(true);
            health += value;
            isInvincible = true;
        }
    }

    void OnLevelWasLoaded(int Level)
    {
        if (Level == 1)
        {
            score = 0;
            timer = 0;
            health = maxHealth;

            iParticles = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>().iParticles;
            iParticles.SetActive(false);
        }
    }

    void Start()
    {
        if (pd == null) {
            pd = this;
            DontDestroyOnLoad(this); 
        }
        else Destroy(this);
    }
    float timer;
    void Update()
    {
        if (Application.loadedLevelName == "MainLevel")
        {
            timer += Time.deltaTime;
            score = (int)timer * 10;
            if (health <= 0)
            {
                finalScore = score;
                Application.LoadLevel("Menu 3D");
            }

            if (isInvincible)
            {
                if ((iTimer -= Time.deltaTime) <= 0)
                {
                    iParticles.SetActive(false);
                    isInvincible = false;
                    iTimer = 1;
                }
            }
        }
    }
}
