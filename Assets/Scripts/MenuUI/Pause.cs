using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class Pause : MonoBehaviour {
    public InputAction interact;
    public static bool isPaused = false;
    public GameObject pausePanel;

    public static event Action OnPause;
    public static event Action OnUnpause;

    void OnEnable() {
        interact.Enable();
        interact.performed += ctx => { 
            Debug.Log("Pause Pressed"); 
            PausePressed(); 
        };
    }

    private void OnDisable() {
        interact.Disable();
    }

    public void PausePressed() {
        if(!isPaused){
            OnPause.Invoke();
            pausePanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }else{
            OnUnpause.Invoke();
            pausePanel.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
