using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject {
    public Context criteria;

    [SerializeField] private string[] dialogue;
    public string[] Dialogue => dialogue;
} 
