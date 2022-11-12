using UnityEngine;

[RequireComponent(typeof(NPC))]
public class DialogueTrigger : Interactable {
    private NPC npc;

    private void Awake() {
        npc = this.GetComponent<NPC>();
    }

    public override void Interact() {
        base.Interact();
        DialogueNode dialogue = npc.dialogue;
        if(dialogue) DialogueUI.StartDialogue(dialogue);
    }
}
