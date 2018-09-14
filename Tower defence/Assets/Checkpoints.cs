using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public GameObject startFinish;
	public GameObject check1;
	public GameObject check2;
	public GameObject check3;

	private GameObject p1next;
	private GameObject p1curr;
	private GameObject p1prev;

	private GameObject p2next;
	private GameObject p2curr;
	private GameObject p2prev;

	// Use this for initialization
	void Start () {
		p1curr = startFinish;
		p1prev = check3;
		p1next = check1;

		p2curr = startFinish;
		p2prev = check3;
		p2next = check1;
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.GetComponent<BoxCollider>() == check1.GetComponent<BoxCollider>())
		{

		}
	}
}
