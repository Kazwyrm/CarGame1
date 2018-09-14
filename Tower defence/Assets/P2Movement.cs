/* // Created by Tim // 13/09 // */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour {

	private float moveForce;
	private float NormSpeed;
	private float rotTorque;
	private float hoverHeight;
	private float hoverForce;
	private float hoverDamp;
	private float jump;

	public GameObject player;

	public Rigidbody rb;

	void Start()
	{
		moveForce	= 40;
		rotTorque	= 4;
		hoverHeight	= 3;
		hoverForce	= 3;
		hoverDamp	= 2;
		jump		= 20; 
		rb = player.GetComponent<Rigidbody>();
		NormSpeed = moveForce;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.RightControl))
		{
			moveForce = NormSpeed * 2;
		}
		else
		{
			moveForce = 40;
			NormSpeed = moveForce;
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
		{
			rb.AddForce(Input.GetAxis("VerticalP2") * moveForce * transform.forward);
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
		{
			rb.AddTorque(Input.GetAxis("HorizontalP2") * rotTorque * Vector3.up);
		}
		RaycastHit hit;
		Ray downRay = new Ray(transform.position, Vector3.down);
		if (Physics.Raycast(downRay, out hit))
		{
			float hoverError = hoverHeight - hit.distance;
			if (hoverError > 0)
			{
				float upwardSpeed = rb.velocity.y;
				float lift = hoverError * hoverForce - upwardSpeed * hoverDamp;
				rb.AddForce(lift * Vector3.up);
			}
		}
	}
}
