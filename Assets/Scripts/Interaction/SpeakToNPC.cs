using UnityEngine;

public class SpeakToNPC : Interactable
{
    public NPC npc;
    public override void Interact(){
        base.Interact();
        npc.playerIsClose = true;
    }
}
