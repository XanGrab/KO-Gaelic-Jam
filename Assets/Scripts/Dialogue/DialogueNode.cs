using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject {
    public Context criteria;
    public int priorety;

    [SerializeField] private string[] dialogue;
    public string[] Dialogue => dialogue;

    public bool IsValidContext(Context current) {
        foreach (var item in criteria.inventory) {
            if(!current.inventory.Contains(item)) {
                Debug.Log("player does not have:" + item.name);
                return false;
            }
        } 

        foreach (var criterion in criteria.criteria) {
            if(!current.criteria.Contains(criterion)) {    
                Debug.Log("criterion key missing:" + criterion.key);
                return false;
            }

            int i = current.criteria.IndexOf(criterion);
            if(current.criteria[i].value != criterion.value){
                Debug.Log($"criterion value not met expected({criterion.value}):" + current.criteria[i].value);
                return false;
            }
        } 

        return true;
    }
} 
