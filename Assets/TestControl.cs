using UnityEngine;
using System.Collections;

public class TestControl : MonoBehaviour {

	public float vitesse = 1;


	// Use this for initialization
	void Start () {
		// Choix de la vitesse
		vitesse = vitesse/100;
	}

	// Update is called once per frame
	void Update () {
		// bouton test de la manette
		/*if (Input.GetButtonDown ("Fire1")) {
			// fait tourner l'object
			// Plus tard ce sera le bouton pour les dialogues
			transform.Rotate (transform.rotation.eulerAngles + new Vector3 (0f, 0.1f, 0f));		
		}*/
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

        Vector3 moveForward = Camera.main.transform.forward * v * vitesse;
        transform.position += new Vector3(moveForward.x, 0, moveForward.z);
        //transform.position += ;
        //transform.forward += new Vector3(h * vitesse, 0f, v * vitesse);
        //transform.position += new Vector3 (h * vitesse, 0f, v * vitesse);
	}
}
