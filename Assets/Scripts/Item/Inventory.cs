using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory")]
[System.Serializable]
public class Inventory : ScriptableObject {

    public int space = 20;
    public List<Item> items;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    void OnEnable(){
        items = new List<Item>();
    }

    public bool IsEmpty() {
        if(items.Count == 0) return true;
        return false;
    }

    public bool Lookup(Item item) {
        return items.Contains(item);
    }

    public bool Add(Item item){
        if(!item.isDefaultItem){
            if(items.Count >= space){
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null){
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public bool Contains(Item item){
        return items.Contains(item);
    }

    public bool ContainsCane(){
        foreach(Item i in items){
            if(i.name.Equals("Cane")) return true;
        }
        return false;
    }

    public void Remove(Item item){
        items.Remove(item);

        if(onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
    }

}
