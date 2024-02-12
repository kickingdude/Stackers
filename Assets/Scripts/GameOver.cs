using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame

    public void Retry()
    {
        Movement.number = 3;
        StartMenu.GameStart = false;
        SceneManager.LoadScene("SampleScene");
    }
}
