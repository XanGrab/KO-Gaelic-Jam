using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    // public string[] dialogue;
    [SerializeField]
    private DialogueNode dialogueNode; 
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    public void exit(){
        playerIsClose = false;
        zeroText();
    }

    void Update() {
        if(playerIsClose){
            if(dialoguePanel.activeInHierarchy){
                //zeroText();
            }else{
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        string[] dialogue = dialogueNode.queryDialogue();
        if(dialogue != null){
            if(dialogueText.text == dialogue[index]){
                contButton.SetActive(true);
            }
        }
    }

    public void zeroText(){
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(){
        string[] dialogue = dialogueNode.queryDialogue();
        if(dialogue != null){
            foreach(char letter in dialogue[index].ToCharArray()){
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
    }

    public void NextLine(){
        contButton.SetActive(false);

        string[] dialogue = dialogueNode.queryDialogue();
        if(dialogue != null){
            if (index < dialogue.Length - 1){
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }else{
                exit();
            }
        }
    }
}
