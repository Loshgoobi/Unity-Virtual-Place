using UnityEngine;
using System.Collections;
//using SmartLocalization;

public class DialogueManager : MonoSingleton<DialogueManager> {

    [SerializeField]
    GameObject fenetreDialogue;

    //LoadAllLanguages langages;
    Animator anim;

    void Start()
    {
        anim = fenetreDialogue.GetComponent<Animator>();
        //langages = fenetreDialogue.GetComponent<LoadAllLanguages>();
    }

	public void OpenDialogue(int idPnj)
    {
        anim.SetBool("open", true);
        //langages.Init(idPnj);
    }
}
