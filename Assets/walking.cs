using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private Animator anim;

    GameObject Char = GameObject.FindGameObjectWithTag("Marine");


	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        IsMoving();
        

	}

    void IsMoving()
    {
        Vector3 lastPos;
        Vector3 currentPos;

        lastPos = Char.transform.position;
        System.Threading.Thread.Sleep(300);
        currentPos = Char.transform.position;

        if (lastPos != currentPos)
        {
            anim.SetFloat("walk", 1);

        }
    }
}
