using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour {
    // public Context memory;
    public List<DialogueNode> dialogue;

    // /**
    // * Append the global inventory to the current NPC's memory
    // */
    // public Context getCurrentContext() {
    //     Context current = memory;

    //     foreach(var item in Global.Instance.playerInventory.items) {
    //         if(!current.inventory.Contains(item)){
    //             current.inventory.Add(item);
    //         }
    //     }

    //     return current;
    // }

    public DialogueNode getCurrentDialogue() {
        List<DialogueNode> currentDialogue = new List<DialogueNode>();
        foreach(var dialogueNode in dialogue){
            // Context current = getCurrentContext();
            if(dialogueNode.IsValidContext()) {
                currentDialogue.Add(dialogueNode);
            }
        }

        // Debug.Log($"[NPC] current dialogue count:[{currentDialogue.Count}]");
        // Debug.Log($"[NPC] got dialogue i[{index}]");
        return currentDialogue != null ? FindMaxPriorety(currentDialogue) : null;
    }

    public DialogueNode FindMaxPriorety(List<DialogueNode> list){
        if (list.Count == 0) Debug.LogError("[NPC] Empty list");

            DialogueNode maxPriorety = list[0];
            foreach (DialogueNode d in list) {
                if (d.priorety > maxPriorety.priorety) maxPriorety = d;
            }
        return maxPriorety;
    }
}
