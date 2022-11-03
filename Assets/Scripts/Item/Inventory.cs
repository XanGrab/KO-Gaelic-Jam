using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    #region Singleton
    public static Inventory instance;

    void Awake(){
        if (instance != null){
            Debug.LogWarning("More than one instance found!");
            return;
        }
        instance = this;
    }
    #endregion //Singleton

    public int space = 20;
    [SerializeField] public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool IsEmpty() {
        if(items.Count == 0) return true;
        return false;
    }

    public bool Lookup (Item q) {
        foreach(Item i in items){ 
            if(i.name == q.name) return true;
        }
        return false;
    }

    public bool Add (Item item){
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

    public void Remove (Item item){
        items.Remove(item);

        if(onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
    }
}
