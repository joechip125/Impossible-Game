using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicJumpingCube : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    
    public GameObject playerCube = null;
    private float xMove = 0;
    private float yMove = 0;
    private Vector3 cameraPos;
    private BoxCollider collider;
    private bool triggered;
    private Rigidbody myBody;

    private bool isGrounded;
    
    [SerializeField] Camera playerCamera = null;
    
    [Range(5, 30), SerializeField] float moveSpeed = 6f;
    
    [SerializeField] float gravity = -9.81f;

    Vector3 velocity;
    
    public float jumpHeight = 2;


    
    void Start()
    {
        myBody = GetComponent<Rigidbody>();

    }
    

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
    //    transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        
        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                myBody.AddForce(new Vector3(0,5f,0), ForceMode.Impulse);
            }
        }
        
        playerCamera.transform.position =  new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
