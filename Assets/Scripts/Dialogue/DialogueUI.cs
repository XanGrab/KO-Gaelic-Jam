using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#else
Debug.LogError("New Unity Input System is required for the Character Inputs");
#endif

public class DialogueUI : MonoBehaviour {
    private InputSystem _input;

    private static DialogueUI _instance;
    public static DialogueUI Instance { get { return _instance; } }

    public TMP_Text dialogueLabel;
    public Button continueButton;

    private TypewriterEffect typeFx;
    [SerializeField] DialogueNode test;

    private void Awake() {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else{
            _instance = this;
        }

        typeFx = GetComponent<TypewriterEffect>();
        _input = new InputSystem();
    }

    private void OnEnable() {
        _input.Enable();
    }
    private void OnDisable() {
        _input.Enable();
    }

    private void Start() {
        if (test) ShowDialogue(test);    
    }
    
    public void ShowDialogue(DialogueNode toShow) {
        StartCoroutine(StepThroughDialogue(toShow));
    }

    public IEnumerator StepThroughDialogue(DialogueNode toStep) {
        foreach (var line in toStep.Dialogue) {
            yield return typeFx.Run(line, dialogueLabel);        
            yield return new WaitUntil(() => _input.Player.Interact.triggered);
        }
    }
    
}
