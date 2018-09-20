using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalKillObject : MonoBehaviour {
    public float speed;
    public float timer;
    // Use this for initialization
    void Start()
    {
        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 1.2f)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
        else if (timer >= 1.2f && timer < 2.4f)
        {
            transform.position -= Vector3.down * speed * Time.deltaTime;
        }
        else if (timer >= 2.4f)
        {
            timer = 0.0f;
        }
    }
}
