using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameObject character;

    void Start()
    {
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float pX = character.transform.position.x;
            float pY = character.transform.position.y;

            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            character.transform.position = new Vector2(pX, pY);
            PlayerPrefs.SetInt("TimeToLoad", 0);

            PlayerPrefs.Save();
        }
    }

    public void PlayerPosSave()
    {
        PlayerPrefs.SetFloat("p_x", character.transform.position.x);
        PlayerPrefs.SetFloat("p_y", character.transform.position.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save(); 
    }
    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }

    
}

