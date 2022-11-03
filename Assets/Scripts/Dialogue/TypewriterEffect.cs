using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;

public class TypewriterEffect : MonoBehaviour {
    public float typeSpeed = 20f;

    public void Run(string textToType, TMP_Text label) {
        StartCoroutine( TypeText(textToType, label) );
    }

    private IEnumerator TypeText(string text2Type, TMP_Text label){
        float timer = 0;
        int charIndex = 0;

        while(charIndex < text2Type.Length) {
            timer += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(timer);
            charIndex = Mathf.Clamp(charIndex, 0, text2Type.Length);

            label.text = text2Type.Substring(0, charIndex);

            yield return null;
        }
    }
}