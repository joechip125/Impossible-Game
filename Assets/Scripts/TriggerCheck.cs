using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public bool isTriggered;
    public bool tickTrigger;
    public string triggerType;
    [HideInInspector] public string printThis;
    
    // Start is called before the first frame update
    void Start()
    {
        printThis = "Failure";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerType == "Loser")
        {
            
        }

        else
        {
            isTriggered = true;
        }
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
