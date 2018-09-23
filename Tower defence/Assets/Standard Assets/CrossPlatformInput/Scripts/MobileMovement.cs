using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class MobileMovement : MonoBehaviour
    {
        // by Tim

        [HideInInspector]
        public float moveForce;
        private float rotTorque;
        public GameObject player;

        public Rigidbody rb;

        // by Tyson

        // determines if the joystick is being dragged
        [HideInInspector]
        public bool m_bIsDragging = false;
        // reference to the joystick
        public Joystick m_joystick;

        // used to time how long the speed up power up lasts for
        private WaitForSeconds m_wait;


        // Use this for initialization
        void Start()
        {
            moveForce = 40;
            rotTorque = 160;
            rb = player.GetComponent<Rigidbody>();

            // 2 second wait
            m_wait = new WaitForSeconds(2);
        }

        // by Tyson

        private void FixedUpdate()
        {
            // checks if the joystick is being dragged
            if (m_bIsDragging)
            {
                // updates the position and rotation based on the joystick transform
                UpdateAxis(m_joystick.m_transform);
            }
        }

        // updates the position and rotation of the object based on the given position
        private void UpdateAxis(Vector3 value)
        {
            // vector between the joystick starting position and the given position
            var delta = m_joystick.m_StartPos - value;
            // inverts the y position
            delta.y = -delta.y;
            // clamps the vector by the range
            delta /= m_joystick.MovementRange;
            // turns the object by the x component
            Turn(-delta.normalized.x);
            // moves the object by the y component
            Move(delta.normalized.y);
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
}