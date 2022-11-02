using UnityEngine;

[RequireComponent(typeof(Speakable))]
public class SpeakOnInteract : Interactable {
    private Speakable npc;

    void Start() {
        npc = GetComponent<Speakable>();  
    }

    public override void Interact(){
        base.Interact();
        npc.playerIsClose = true;
    }
}
