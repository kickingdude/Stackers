using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text wins;

    // Update is called once per frame
    void Update()
    {
        wins.text = "Number of Wins: " + Movement.wins.ToString();
    }
}
