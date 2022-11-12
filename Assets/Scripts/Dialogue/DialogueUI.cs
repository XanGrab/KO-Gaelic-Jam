using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public Button continueButton; //TODO: show interaction key
    public GameObject panel;

    private TypewriterEffect typeFx;

    public delegate void DialogueAction();
    public static event DialogueAction OnDialogueStart;
    public static event DialogueAction OnDialogueEnd;

    private void Awake() {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else{
            _instance = this;
        }

        typeFx = GetComponentInChildren(typeof(TypewriterEffect)) as TypewriterEffect;
        _input = new InputSystem();

        panel.SetActive(false);
    }

    private void OnEnable() {
        _input.Enable();
    }

    private void OnDisable() {
        _input.Disable();
    }
    
    public static void StartDialogue(DialogueNode toShow) {
        _instance.panel.SetActive(true);
        OnDialogueStart.Invoke();
        _instance.StartCoroutine(_instance.StepThroughDialogue(toShow));
    }

    private IEnumerator StepThroughDialogue(DialogueNode toStep) {
        foreach (var line in toStep.Dialogue) {
            yield return typeFx.Run(line, dialogueLabel);        
            yield return new WaitUntil(() => _input.Player.Interact.triggered);
        }
        CloseDialogue();
    }
    
    private void CloseDialogue() {
        OnDialogueEnd.Invoke();
        panel.SetActive(false);
        dialogueLabel.text = string.Empty;
    }
}
