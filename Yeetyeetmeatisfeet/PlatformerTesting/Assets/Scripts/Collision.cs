using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject == Player)
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
