using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float timer;
	public float speed;
    public GameObject speedBoost;
    public GameObject escapeMenu;
    public GameObject wallsAndFloors; 
    public bool onSpeedBoost;
    public bool jump; 
	private Rigidbody rb;
	void Awake(){
		print ("Awake Function");
	}
	// Use this for initialization
	void Start () {
		print("Start Function");
		rb = gameObject.GetComponent<Rigidbody>();
		speed = 10.0f;
        jump = false; 
	}

    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject == speedBoost)
        {
            onSpeedBoost = true;
            if (onSpeedBoost)
            {
                speed = 20.0f;
            }
        }
        else
        {
            onSpeedBoost = false;
            speed = 10.0f;
        }
        if(other.gameObject.tag == "NotKillObsticle")
        {
            jump = true; 
        }
    }
    private void OnCollisionExit(UnityEngine.Collision other)
    {
        if(other.gameObject.tag == "NotKillObsticle")
        {
            jump = false; 
        }
    }

    // Update is called once per frame
    void Update () 
    {
		timer += Time.deltaTime;
		if(Input.GetAxis("Horizontal") > 0)
        {
			transform.position -= Vector3.left * speed * Time.deltaTime;	
		}
		if(Input.GetAxis("Horizontal") < 0)
        {
			transform.position += Vector3.left * speed * Time.deltaTime;	
		}
		if((jump) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
				rb.velocity = new Vector3(0, 5, 0);
		}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //locks cursor to the middle of the screen and makes it invisible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            escapeMenu.SetActive(true);
            Time.timeScale = 0;
        }
	}
}