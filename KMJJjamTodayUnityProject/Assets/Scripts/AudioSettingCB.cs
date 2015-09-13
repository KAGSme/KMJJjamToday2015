using UnityEngine;
using System.Collections;

public class AudioSettingCB : MonoBehaviour {

    public void CB(float valueChange)
    {
         AudioListener.volume = valueChange; 
    }
    void Start() {
        GetComponent<UnityEngine.UI.Slider>().value = AudioListener.volume;
    }
}
