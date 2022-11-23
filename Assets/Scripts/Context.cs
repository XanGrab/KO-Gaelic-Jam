using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Context {
    // public List<ConditionalItems> criteria;
    public List<Condition> criteria;

    public bool checkConditions(){
        bool eval = true;
        foreach(var criterion in criteria){
            eval = criterion.Invoke();
        }
        return eval;
    }
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

[System.Serializable]
public class Condition : SerializableCallback<bool> {}
//https://github.com/Siccity/SerializableCallback/issues/24
[System.Serializable]
public class ConditionalItem : SerializableCallback<Item, bool> {
}