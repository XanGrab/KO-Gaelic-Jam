using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Context", menuName = "Global/Context")]
public class Context : ScriptableObject {
    public List<string> criteria;
    public Inventory currentInventory;

    public bool IsValidContext(Context ctx) {
        foreach (string _criteria in ctx.criteria) {
            if(!criteria.Contains(_criteria)) return false;
        }
        if (currentInventory.IsEmpty()) {
            if (currentInventory.IsEmpty() != ctx.currentInventory.IsEmpty()) return false;
        } else {
            foreach(var item in currentInventory.items) {
                if(!ctx.currentInventory.Lookup(item)) return false;
            }
        }

        return true;
    }
}