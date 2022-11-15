using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Context {
    // public DataTable _criteria;
    public List<Criterion> criteria;
    public List<Item> inventory;
}

[System.Serializable]
public class Criterion : IEquatable<Criterion> {
    public string key;
    public int value;

    public bool Equals(string _key) {
        if(_key.Equals(key)) return true;
        return false;
    }

    public bool Equals(Criterion other) {
        if(other.key.Equals(key)) return true;
        return false;
    }
}