using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{


    public AudioSource[] BGM;
    public AudioSource[] SFX;



    private void Start()
    {
        
        
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("sound") == 1)
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                BGM[i].volume = 0.5f;
            }
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                BGM[i].volume = 0.0f;
            }
        }

        if (PlayerPrefs.GetInt("sfx") == 1)
        {
            for (int i = 0; i < SFX.Length; i++)
            {
                SFX[i].volume = 0.5f;
            }
        }
        else if (PlayerPrefs.GetInt("sfx") == 0)
        {
            for (int i = 0; i < SFX.Length; i++)
            {
                SFX[i].volume = 0.0f;
            }
        }
    }

}