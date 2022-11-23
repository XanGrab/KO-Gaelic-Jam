using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
    public static bool isPaused = false;
    private GameObject mainPanel;

    private void Awake() {
        mainPanel = gameObject;
        Pause.OnPause += ToggleInstructions;
        Pause.OnUnpause += ToggleInstructions;
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDestroy() {
        Pause.OnPause -= ToggleInstructions;
        Pause.OnUnpause -= ToggleInstructions;
    }

    public void ToggleInstructions() {
        if(!isPaused){
            mainPanel.SetActive(false);
            isPaused = true;
        }else{
            mainPanel.SetActive(true);
            isPaused = false;
        }
    }
}
