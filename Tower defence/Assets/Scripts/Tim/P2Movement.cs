﻿/* // Created by Tim // 13/09 // */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour {

    [HideInInspector]
	public float moveForce;
	private float rotTorque;
	private float hoverHeight;
	private float hoverForce;
	private float hoverDamp;

    // used to time how long the speed up power up lasts for
    private WaitForSeconds m_wait;

	public GameObject player;

	public Rigidbody rb;

	void Start()
	{
		moveForce	= 40;
		rotTorque	= 4;
		hoverHeight	= 3;
		hoverForce	= 3;
		hoverDamp	= 2;
        rb = player.GetComponent<Rigidbody>();

        // 2 second wait
        m_wait = new WaitForSeconds(2);
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

    // by Tyson

    // speeds up the player, waits a bit, then slows back down
    public IEnumerator Wait()
    {
        SpeedUp();
        yield return m_wait;
        SpeedDown();
    }
    // increases the speed
    private void SpeedUp()
    {
        moveForce = 80;
    }
    // resets the speed to normal
    private void SpeedDown()
    {
        moveForce = 40;
    }
    // reinitialises the variables
    public void EnableControls()
    {
        moveForce = 40;
        rotTorque = 4;
        hoverHeight = 3;
        hoverForce = 3;
        hoverDamp = 2;
    }
    // nulls the variables
    public void DisableControls()
    {
        moveForce = 0;
        rotTorque = 0;
        hoverHeight = 0;
        hoverForce = 0;
        hoverDamp = 0;
    }
}