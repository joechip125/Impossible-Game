using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvents : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] private string state;
    private BoxCollider playCollider;
    private int loseCount;
    private int winCount;
    void Start()
    {
        playCollider = player.GetComponent<BoxCollider>();
        loseCount = 0;
        winCount = 0;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        string value;
        if (state == "Won")
        {
            value = "winCount";
            Debug.Log("You won");
        }
        else if (state == "Lose")
        {
            value = "loseCount";
            Debug.Log("You Lost");
        }
        else
        {
            value = "blank";
        }
        PlayerPrefs.SetInt(value, PlayerPrefs.GetInt(value) + 1);
        winCount = PlayerPrefs.GetInt(value);
        StartCoroutine(ReloadLevelDelayed());
    }
    
    IEnumerator ReloadLevelDelayed()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ImpossibleGameScene");
        string enter = string.Concat("You Have Won", winCount);
        
        Debug.Log(enter);
    }

    
}
