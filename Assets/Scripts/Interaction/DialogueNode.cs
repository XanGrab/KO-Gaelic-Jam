using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject {
    public ItemRequirements[] requiredItems;

    [SerializeField] private string[] dialogue;
    public string[] Dialogue => dialogue;

    checkConditions() {
        foreach(var item in requiredItems){

        }
    }
} 

[Serializable]
public struct ItemRequirements {
   public Item item;
   public bool requirement;
}