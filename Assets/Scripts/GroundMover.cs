using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public bool move;
    public float moveSpeed;
    private BoxCollider childCollider;
    private TriggerCheck childCheck;
    [HideInInspector] public string superCheck;

    // Start is called before the first frame update
    void Start()
    {
        childCollider = GetComponentInChildren<BoxCollider>();
        childCheck = childCollider.GetComponent<TriggerCheck>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (childCheck.isTriggered)
        {
            superCheck = "Success";
        }
        
        if (move)
        { 
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
