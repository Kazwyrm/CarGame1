using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearAfterTouch : MonoBehaviour {

    public GameObject Player;
    private float timer;
    private bool disappear;
	// Use this for initialization
	void Start () {
		
	}
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject == Player)
        {
            disappear = true;
        }
    }
    // Update is called once per frame
    void Update () {
        if (disappear)
        {
            timer += Time.deltaTime;
            if(timer > 3.0f)
            {
                Destroy(this.gameObject);
            }
        }

	}
}
