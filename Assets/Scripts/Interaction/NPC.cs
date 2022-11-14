using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour {
    public Context memory;
    public List<DialogueNode> dialogue;

    public DialogueNode getCurrentDialogue() {
        List<DialogueNode> currentDialogue = new List<DialogueNode>();
        foreach(var dialogueNode in dialogue){
            if(dialogueNode.criteria.IsValidContext(memory) > 0) {
                currentDialogue.Add(dialogueNode);
            }
        }

        Debug.Log($"[NPC] current dialogue count:[{currentDialogue.Count}]");
        int index = currentDialogue.Count > 1 ? Random.Range(0, currentDialogue.Count - 1) : 0;
        Debug.Log($"[NPC] got dialogue i[{index}]");
        return currentDialogue[ index ];
    }
}
