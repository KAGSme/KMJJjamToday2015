using UnityEngine;
using System.Collections;

public class AudioSettingCB : MonoBehaviour {

    public void CB(float valueChange)
    {
         AudioListener.volume = valueChange; 
    }

}
