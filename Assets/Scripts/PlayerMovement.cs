using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{

    //movement
    public float movementSpeed = 5f;
    public float turnSpeed = 45f;
    float notMoving = 0f;

    //camerapos
    public float cameraDistance = 10f;
    public float cameraHeight = 10f;

    Rigidbody rb;
    Transform mainCamera;
    Vector3 cameraOffset;
	
	void Start ()
    {
		if(isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        rb = GetComponent<Rigidbody>();

        cameraOffset = new Vector3(0f, cameraHeight, -cameraDistance);

        mainCamera = Camera.main.transform;
        MoveCamera();
	}
	
	
	void FixedUpdate ()
    {
        //getting horizontal and vertical
        float turnAmount = Input.GetAxis("Horizontal");
        float moveAmount = Input.GetAxis("Vertical");

        //calculate and apply new pos
        Vector3 deltaTranslation = transform.position + transform.forward * movementSpeed * moveAmount * Time.deltaTime;
        rb.MovePosition(deltaTranslation);

        //calculate and apply new rot
        Quaternion deltaRotation = Quaternion.Euler(turnSpeed * new Vector3(0, turnAmount, 0) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        if(moveAmount == 0f) //if player isn't moving he can't turn
        {
            turnSpeed = notMoving;
        }

        if(moveAmount < 0f) //if player goes backwards controls are reversed
        {
            turnSpeed = -45f;
        }
        
        if(moveAmount > 0f)
        {
            turnSpeed = 45f;
        }


        MoveCamera();
	}

    void MoveCamera()
    {
        mainCamera.position = transform.position; //move camera to player
        mainCamera.rotation = transform.rotation; //camera rotates with player
        mainCamera.Translate(cameraOffset); //offsetting camera pos
        mainCamera.LookAt(transform); //camera looks at player
    }

}
