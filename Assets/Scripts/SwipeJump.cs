using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour
{

	private Vector2 startTouchPosition, endTouchPosition;
	private Rigidbody rb;
	private float jumpForce;
	private bool jumpAllowed = false;

	// Use this for initialization
	private void Start()
	{
		 rb = GetComponent<Rigidbody>();
		 jumpForce = 700f;
	}

	// Update is called once per frame
	private void Update()
	{
		//SwipeCheck();
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
			startTouchPosition = Input.GetTouch(0).position;

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			endTouchPosition = Input.GetTouch(0).position;
			if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
				jumpAllowed = true;
		}
	}

	private void FixedUpdate()
	{
		JumpIfAllowed();
	}

	/*private void SwipeCheck()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
			startTouchPosition = Input.GetTouch(0).position;

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			endTouchPosition = Input.GetTouch(0).position;
			if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
				jumpAllowed = true;
		}
	}*/

	private void JumpIfAllowed()
	{
		if (jumpAllowed)
		{
			rb.AddForce(Vector2.up * jumpForce);
			jumpAllowed = false;
		}
	}

}
