using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        // rotates the object
        Rot();
    }

    // rotates the object
    private void Rot()
    {
        transform.Rotate(new Vector3(15.0f, 30.0f, 45.0f) * Time.deltaTime);
    }
}