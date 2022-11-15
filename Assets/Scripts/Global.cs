using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Inventory))]
public class Global : MonoBehaviour {
    private static Global _instance;
    public static Global Instance { get { return _instance; } }

    public static Context global;
    public static Inventory inventory;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        inventory = GetComponent<Inventory>();
    }
}
