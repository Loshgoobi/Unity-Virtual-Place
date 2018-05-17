using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour {

    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveFoward;

    private CharacterController cc;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveFoward = true;
        }
        else
        {
            moveFoward = false;
        }

        if (moveFoward)
        {
            Vector3 foward = vrCamera.TransformDirection(Vector3.forward);

            cc.SimpleMove(foward * speed);
        }
	}
}
