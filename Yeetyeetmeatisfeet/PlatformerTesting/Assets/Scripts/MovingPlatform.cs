using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float speed;
    public float timer;
	// Use this for initialization
	void Start () {
        speed = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer < 3.0f)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        else if (timer >= 3.0f && timer < 6.0f)
        {
            transform.position -= Vector3.left * speed * Time.deltaTime;
        }
        else if(timer >= 6.0f){
            timer = 0.0f;
        }
    }
}
