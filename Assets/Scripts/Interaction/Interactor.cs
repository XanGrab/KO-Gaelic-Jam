using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#else
Debug.LogError("New Unity Input System is required for the Character Inputs");
#endif

[RequireComponent(typeof(Collider))]
public class Interactor : MonoBehaviour {
    public InputAction interact;
    private bool _interacting;

    private GameObject _mainCamera;
    private Interactable focus; // The object currently focused on by the player

    void Awake() {
        if (_mainCamera == null)
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        interact.started += ctx => _interacting = true;
        interact.performed += ctx => _interacting = false;
        interact.canceled += ctx => _interacting = false;
    }

    private void OnEnable() {
        interact.Enable();
    }

    private void OnTriggerStay(Collider other) {
        if(!DialogueUI.dialogueActive){
            if(other.TryGetComponent<Interactable>(out var interactable)){
                if(_interacting) {
                    SetFocus(interactable);
                }   
            }
        }
    }

    void SetFocus(Interactable newFocus) {
        if (newFocus != focus){
            if (focus != null){
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus() {
        if (focus != null) {
            focus.OnDefocused();
        }
        focus = null;
    }
}
