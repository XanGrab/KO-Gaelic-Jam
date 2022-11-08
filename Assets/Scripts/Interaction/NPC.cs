using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    public string[] dialogueSecret;
    public string[] dialogueToUse;
    private int index = 0;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    public void exit(){
        playerIsClose = false;
        zeroText();
    }

    public void Start() {
        dialogueToUse = dialogue;
    }

    // Update is called once per frame
    void Update() {
        if(playerIsClose){
            if(dialoguePanel.activeInHierarchy){
                //zeroText();
            }else{
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing(dialogueToUse));
            }
        }

        if(dialogueText.text == dialogueToUse[index]){
            contButton.SetActive(true);
        }
    }

    public void zeroText(){
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(string[] d){
        foreach(char letter in d[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine(){

        contButton.SetActive(false);

        if (index < dialogueToUse.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing(dialogueToUse));
        }else{
            exit();
        }
    }
}
