using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public static bool GameStart = false;
    public GameObject startMenuUI;
    public GameObject counterMenuUI;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (startMenuUI.activeSelf)
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (data != null)
            {
                Movement.wins = data.wins;
                Movement.plays = data.plays;
            }
            
        }
    }

    public void StartGame()
    {
        GameStart = true;
        startMenuUI.SetActive(false);
        counterMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
