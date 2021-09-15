using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpingCube : MonoBehaviour
{
    public GameObject playerCube = null;
    private float xMove = 0;
    private float yMove = 0;
    private Vector3 cameraPos;

    private CharacterController controller;

    [SerializeField] Camera playerCamera = null;
    
    [Range(5, 30), SerializeField] float moveSpeed = 6f;
    
    [SerializeField] float gravity = -9.81f;

    Vector3 velocity;
    
    public float jumpHeight = 2;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        xMove = Input.GetAxis("Horizontal");
        Vector3 move = (transform.right * xMove); 

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        if (controller.isGrounded)
        {
            velocity = Vector3.zero;
                
             if (Input.GetButton("Jump"))
             {
                 velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight);
                 
                 velocity.y = 34;
             }
             else
             {
                 move.y = 0;
             }
        }
        
        controller.Move(move * moveSpeed * Time.deltaTime);
        cameraPos = new Vector3(transform.position.x, transform.position.y, -10);
        playerCamera.transform.position = cameraPos;
    }
}
