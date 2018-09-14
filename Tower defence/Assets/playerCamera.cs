using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
	[Serializable]
	public class AdvancedOptions
	{
		public bool updateCameraInUpdate;
		public bool updateCameraInFixedUpdate = true;
		public bool updateCameraInLateUpdate;
	}//yes

	// how smoothly the camera follows
	public float smoothing = 6f;
	// where it should look at
	public Transform lookAtTarget;
	// where the target of the camera is
	public Transform positionTarget;
	public AdvancedOptions advOp;

	// Update is called once per frame
	private void Update()
	{
		if (advOp.updateCameraInUpdate)
			UpdateCamera();
	}

	private void FixedUpdate()
	{
		if (advOp.updateCameraInFixedUpdate)
			UpdateCamera();
	}

	private void LateUpdate()
	{
		if (advOp.updateCameraInLateUpdate)
			UpdateCamera();
	}

	private void UpdateCamera()
	{
		transform.position = Vector3.Lerp(transform.position, positionTarget.position, Time.deltaTime * smoothing);
		transform.LookAt(lookAtTarget);
	}
}
