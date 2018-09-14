using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private float moveForce;
    private float NormSpeed;
    private float rotTorque;
    private float hoverHeight;
	private float hoverForce;
    private float hoverDamp;
    private float jump;

    public GameObject player;

    public Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
		moveForce = 40;
		rotTorque = 4;
		hoverHeight = 3;
		hoverForce = 3;
		hoverDamp = 2;
		jump = 20;
		rb = player.GetComponent<Rigidbody>();
        NormSpeed = moveForce;
	}

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            moveForce = NormSpeed * 2;
        }
        else
        {
            moveForce = 40;
            NormSpeed = moveForce;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Input.GetAxis("Vertical") * moveForce * transform.forward);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Input.GetAxis("Horizontal") * rotTorque * Vector3.up);
        }
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(downRay,out hit))
        {
            float hoverError = hoverHeight - hit.distance;
            if(hoverError > 0)
            {
                float upwardSpeed = rb.velocity.y;
                float lift = hoverError * hoverForce - upwardSpeed * hoverDamp;
                rb.AddForce(lift * Vector3.up);
            }
        }
    }
}
