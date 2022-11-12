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

    private TypewriterEffect typeFx;
    [SerializeField] DialogueNode test;

    [SerializeField] 
    public static UnityEvent<DialogueNode> OnDialogueStart;

    private void Awake() {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else{
            _instance = this;
        }

        typeFx = GetComponent<TypewriterEffect>();
        _input = new InputSystem();

        if(OnDialogueStart == null) OnDialogueStart = new UnityEvent<DialogueNode>();
        OnDialogueStart.AddListener(ShowDialogue);

        gameObject.SetActive(false);
    }

    private void OnEnable() {
        _input.Enable();
        OnDialogueStart.AddListener(ShowDialogue);
    }

    private void OnDisable() {
        _input.Enable();
        OnDialogueStart.RemoveListener(ShowDialogue);
    }

    public static void StartDialogue(DialogueNode toShow) {
        OnDialogueStart.Invoke(toShow);
    }
    
    void ShowDialogue(DialogueNode toShow) {
        gameObject.SetActive(true);
        StartCoroutine(StepThroughDialogue(toShow));
    }

    public IEnumerator StepThroughDialogue(DialogueNode toStep) {
        foreach (var line in toStep.Dialogue) {
            yield return typeFx.Run(line, dialogueLabel);        
            yield return new WaitUntil(() => _input.Player.Interact.triggered);
        }
        CloseDialogue();
    }
    
    private void CloseDialogue() {
        gameObject.SetActive(false);
        dialogueLabel.text = string.Empty;
    }
}
