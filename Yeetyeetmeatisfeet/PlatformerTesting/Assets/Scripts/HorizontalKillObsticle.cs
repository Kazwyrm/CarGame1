using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalKillObsticle : MonoBehaviour {
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
        if (timer < 8.0f)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (timer >= 8.0f && timer < 16.0f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (timer >= 16.0f)
        {
            timer = 0.0f;
        }
    }
}
