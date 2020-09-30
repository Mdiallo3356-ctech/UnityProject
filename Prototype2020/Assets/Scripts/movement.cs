using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // public Transform myTransform;
    private Rigidbody player; 
    private float jumpVelocity = 5f;
    private bool grounded;
    private float groundedMovement = .0525f;
    private float airMovement = .0525f;
    // Start is called before the first frame update
    void Start()
    {
        grounded = false; 
        player = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded == true)
        {
            if(Input.GetKey(KeyCode.W))
            {
                player.position += new Vector3(0, 0, groundedMovement);
            }

            if(Input.GetKey(KeyCode.A))
            {
                player.position -= new Vector3(groundedMovement, 0, 0);
            }

            if(Input.GetKey(KeyCode.S))
            {
                player.position -= new Vector3(0, 0, groundedMovement);
            }

            if(Input.GetKey(KeyCode.D))
            {
                player.position += new Vector3(groundedMovement, 0, 0);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                player.velocity = Vector3.up * jumpVelocity;
                grounded = false;
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.W))
            {
                player.position += new Vector3(0, 0, airMovement);
            }

            if(Input.GetKey(KeyCode.A))
            {
                player.position -= new Vector3(airMovement, 0, 0);
            }

            if(Input.GetKey(KeyCode.S))
            {
                player.position -= new Vector3(0, 0, airMovement);
            }

            if(Input.GetKey(KeyCode.D))
            {
                player.position += new Vector3(airMovement, 0, 0);
            }
        }

        

        if(grounded == true){
            
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        grounded = true;
    }


}
