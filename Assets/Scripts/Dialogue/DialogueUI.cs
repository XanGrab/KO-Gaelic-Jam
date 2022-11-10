using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour {
    private static DialogueUI _instance;
    public static DialogueUI Instance { get { return _instance; } }

    public TMP_Text dialogueLabel;
    public Button continueButton;

    private TypewriterEffect typeFx;

    private void Awake() {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else{
            _instance = this;
        }

        typeFx = GetComponent<TypewriterEffect>();
    }

    private void Start() {

        //Test
        typeFx.Run("This is Test", dialogueLabel);
    } 
    
}
