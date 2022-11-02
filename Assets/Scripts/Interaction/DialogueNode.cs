using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject {
    public List<Item> requiredItems;    

    [SerializeField] private string[] dialogue;
    public string[] Dialogue => dialogue;

    public bool checkConditions() {
        bool ret = true;
        foreach(var item in requiredItems) {
            ret = ret && Inventory.instance.Lookup(item);
        }
        return ret;
    }
} 