using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private WaitForSeconds m_wait;

    private void Start()
    {
        m_wait = new WaitForSeconds(3);
    }

    private IEnumerator Wait()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        transform.Translate(new Vector3(0.0f, -4.0f, 0.0f));
        yield return m_wait;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
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