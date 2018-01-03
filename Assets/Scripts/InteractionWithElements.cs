using UnityEngine;
using System.Collections;
using System;

public class InteractionWithElements : MonoBehaviour, IInteraction
{
    public void Execute()
    {
        DialogueManager.GetInstance().OpenDialogue(GetComponent<Pnj>().id);
    }
}
