using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeTextAnimation : MonoBehaviour
{
    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;
    public string fullText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeText());
    }
    IEnumerator TypeText() {
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for (int i = 0; i <= textObject.text.Length; i++) {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
    }

    public void StartTyping()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
