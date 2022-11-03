using UnityEngine;

public class SpeakToNPC : Interactable
{
    public NPC npc;
    public Item item;
    public override void Interact(){
        base.Interact();
        if(Inventory.instance.contains(item)){
            npc.dialogueToUse = npc.dialogueSecret;
        }else{
            npc.dialogueToUse = npc.dialogue;
        }
        npc.playerIsClose = true;
    }
}
