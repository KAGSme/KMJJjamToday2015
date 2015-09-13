using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class ButtonNextLevel : MonoBehaviour
{
    float timer = 1;
    bool changeLevel = false;
    string olevelName;
    public void NextLevelButton(string levelName)
    {
        changeLevel = true;
        olevelName = levelName;
    }

    void Update()
    {
        if (changeLevel)
        {
            GetComponent<AudioSource>().volume = Mathf.MoveTowards(GetComponent<AudioSource>().volume, 0, Time.deltaTime);
            if ((timer -= Time.deltaTime) <= 0)
            {
                Application.LoadLevel(olevelName);
            }
        }
    }
}
