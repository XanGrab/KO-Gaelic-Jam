using UnityEngine;

public class DialogueTrigger : Interactable {
    private DialogueUI ui;

    public override void Interact(){
        base.Interact();
        // npc.playerIsClose = true;
    }
}
