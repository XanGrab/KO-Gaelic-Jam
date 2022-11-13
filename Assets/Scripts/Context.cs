using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Context {
    public Criterion[] criteria;
    public List<Item> inventory;

    public bool IsValidContext(Context ctx) {
        // Iterate over criteria and evaluate conditional

        return true;
    }
}

[System.Serializable]
public class Criterion {
    public string key;
    public int value;
}