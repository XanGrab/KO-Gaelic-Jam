using UnityEngine;

[RequireComponent(typeof(NPC))]
public class DialogueTrigger : Interactable {
    private NPC npc;

    private void Awake() {
        npc = this.GetComponent<NPC>();
    }

    public override void Interact() {
        if(DialogueUI.dialogueActive) return;

        DialogueNode dialogue = npc.getCurrentDialogue();

        if(dialogue) {
            base.Interact();
            DialogueUI.StartDialogue(dialogue);
        } else {
            Debug.Log("No dialogue found for: " + npc.name);
        }
    }
}
