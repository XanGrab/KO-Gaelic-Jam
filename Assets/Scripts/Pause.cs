using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour {
    public InputAction interact;
    public static bool isPaused = false;
    public GameObject pausePanel;

    void OnEnable() {
        interact.Enable();
        interact.performed += ctx => { 
            Debug.Log("Pause Pressed"); 
            PausePressed(); 
        };
    }

    public void PausePressed() {
        if(!isPaused){
            pausePanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }else{
            pausePanel.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
