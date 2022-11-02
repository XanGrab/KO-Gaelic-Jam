using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueNode : MonoBehaviour { 
    public List<Item> conditions;
    private string[] dialogue;

    public string[] queryDialogue(List<Item> ctx){ 
        foreach(var item in conditions){
            if(ctx.Lookup)
        }
        return dialogue;
    }
}