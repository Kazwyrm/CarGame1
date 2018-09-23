using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    // used to time how long the power up "disappears" for
    private WaitForSeconds m_wait;

    private void Start()
    {
        // sets the wait time to 3 seconds
        m_wait = new WaitForSeconds(3);
    }

    // moves the power up out of sight until the wait time is over
    private IEnumerator Wait()
    {
        // sets the rotation to normal so that it is translated properly
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        // moves the object under the terrain
        transform.Translate(new Vector3(0.0f, -4.0f, 0.0f));
        // waits
        yield return m_wait;
        // sets the rotation to normal so that it is translated properly
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        // moves the object above the terrain
        transform.Translate(new Vector3(0.0f, 4.0f, 0.0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        // checks if the object being collided with is player 1
        if (other.tag == "Player1")
        {
            // starts the speed up process for the player
            StartCoroutine(other.gameObject.GetComponent<Movement>().Wait());
            // moves the object under the map
            StartCoroutine(Wait());
        }
        // checks if the object being collided with is player 2
        else if (other.tag == "Player2")
        {
            // starts the speed up process for the player
            StartCoroutine(other.gameObject.GetComponent<P2Movement>().Wait());
            // moves the object under the map
            StartCoroutine(Wait());
        }
    }
}