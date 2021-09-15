using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public bool isTriggered;
    public bool tickTrigger;
    [HideInInspector] public string printThis;
    
    // Start is called before the first frame update
    void Start()
    {
        printThis = "Failure";
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            tickTrigger = true;
        }
    }
}
