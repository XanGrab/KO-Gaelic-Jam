using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
[System.Serializable]
public class DialogueNode : ScriptableObject {
    public Context conditions;
    public int priorety;

    [SerializeField] private string[] dialogue;
    public string[] Dialogue => dialogue;

    public bool IsValidContext() {
        if (conditions == null) return true;
        return conditions.checkConditions();
    }
} 
