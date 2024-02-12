using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RetryUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text plays;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plays.text = "Number of Plays: " + Movement.plays.ToString();
    }
}
