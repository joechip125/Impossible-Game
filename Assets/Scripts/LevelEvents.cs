using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] private string state;
    private BoxCollider playCollider;
    private int loseCount;
    private int count;
    public float timer;
    public bool ifTrigger;
    public bool ifCollision;
    void Start()
    {
        loseCount = 0;
        count = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (ifCollision)
        {
            timer = 0.3f;
            SetUpReload();
        }
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (ifTrigger)
        {
            timer = 1.0f;
            SetUpReload();
        }
    }

    void SetUpReload()
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
        count = PlayerPrefs.GetInt(value);
        StartCoroutine(ReloadLevelDelayed()); 
    }
    
    IEnumerator ReloadLevelDelayed()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("ImpossibleGameScene");
        if (state == "Won")
        {  
            Debug.Log($"You Have Won {count} times");
        }
        else if (state == "Lost")
        {
            Debug.Log($"You Have Lost {count} times");
        }
    }
}
