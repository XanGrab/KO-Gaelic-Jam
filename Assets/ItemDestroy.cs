using UnityEngine;

public class ItemDestroy : Interactable
{
    public override void Interact(){
        base.Interact();
        Destroy(gameObject);
    }

}

