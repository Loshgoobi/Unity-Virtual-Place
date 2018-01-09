using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {


    string scene1 = "Etage1";
    string scene2 = "Etage2";
    public string scenes;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (scenes == scene1)
            {
                SceneManager.LoadScene(scene1);
            }
            else if (scenes == scene2)
            {
                SceneManager.LoadScene(scene2);
            }
        }
    }
   
}
