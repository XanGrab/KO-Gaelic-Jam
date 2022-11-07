using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject {
    Context criteria;

    [SerializeField] private string[] dialogue;
    public string[] Dialogue => dialogue;
} 
