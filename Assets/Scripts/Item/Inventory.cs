using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public static Inventory instance;

    void Awake(){
        if (instance != null){
            Debug.LogWarning("More than one instance found!");
            return;
        }
        instance = this;
    }

    #endregion

    public List<Item> items = new List<Item>();

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

    public bool contains (Item item){
        return items.Contains(item);
    }

    public void Remove (Item item){
        items.Remove(item);

        if(onItemChangedCallback != null){
                onItemChangedCallback.Invoke();
        }
    }
}
