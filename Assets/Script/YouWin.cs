using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    //public GameObject youwin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene("YouWin");
        }
    }

    public void QuitGame()
    {
       SceneManager.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
