﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FloatingPlayer2DController : MonoBehaviour
{
    public float moveForce = 0.5f;
    public float boostMultiplier = 2;
	Rigidbody2D myBody;

    public GameObject fireanimation;

    void Start ()
	{
		myBody = this.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
	{
		Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
			CrossPlatformInputManager.GetAxis("Vertical"))
			* moveForce;
		Vector3 lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_2"),
			CrossPlatformInputManager.GetAxis("Vertical_2"), 4096);

		if (lookVec.x != 0 && lookVec.y != 0)
			transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);
		
		bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
		myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));

        if (moveVec.sqrMagnitude > 0.0f)
        {
            fireanimation.SetActive(true);
        }
        else
        {
            fireanimation.SetActive(false);
        }
	}
}