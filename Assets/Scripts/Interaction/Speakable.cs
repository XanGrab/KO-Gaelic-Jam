using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//TODO uncouple from Dialogue panel
public class Speakable : MonoBehaviour {
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    [SerializeField]
    private List<DialogueNode> responses; 
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    public void exit(){
        playerIsClose = false;
        zeroText();
    }

    /**
    * If this method returns null, there is no response
    */
    public string[] getNextResponse(){
        var validResponses = responses.Where(e => e.checkConditions());
        DialogueNode selectedResponse = null;
        if(validResponses.Count() != 0) {
            selectedResponse = validResponses.ElementAt(Random.Range(0, validResponses.Count()));
        }

        return selectedResponse?.Dialogue;        
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

        string[] dialogue = getNextResponse();
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
        string[] dialogue = getNextResponse();
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine(){
        contButton.SetActive(false);

        string[] dialogue = getNextResponse();
        if (index < dialogue.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }else{
            exit();
        }
    }
}
