/* // Created by Tim // 13/09 // */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour {

    [HideInInspector]
	public float moveForce;
	private float rotTorque;
	public GameObject player;

	public Rigidbody rb;

    // used to time how long the speed up power up lasts for
    private WaitForSeconds m_wait;

	void Start()
	{
		moveForce	= 40;
		rotTorque	= 160;
        rb = player.GetComponent<Rigidbody>();

        // 2 second wait
        m_wait = new WaitForSeconds(2);
	}

	void FixedUpdate()
	{
        float vertical = Input.GetAxis("VerticalP2") * moveForce * Time.deltaTime;
        float horizontal = Input.GetAxis("HorizontalP2") * rotTorque * Time.deltaTime;

        Move(vertical);
        Turn(horizontal);
    }

    // moves the object by the given value
    public void Move(float v)
    {
        // vector in the facing direction
        Vector3 movement = v * moveForce * Time.deltaTime * player.transform.forward;
        // moves the object by the vector
        rb.MovePosition(rb.position + movement);
    }
    // turns the object by the given value
    public void Turn(float h)
    {
        // turn amount in degrees
        float horizontal = h * rotTorque * Time.deltaTime;
        // euler transform of the turn amount
        Quaternion rotation = Quaternion.Euler(0.0f, horizontal, 0.0f);
        // moves the rotation by the euler
        rb.MoveRotation(rb.rotation * rotation);
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
        rotTorque = 160;
    }
    // nulls the variables
    public void DisableControls()
    {
        moveForce = 0;
        rotTorque = 0;
    }
}
