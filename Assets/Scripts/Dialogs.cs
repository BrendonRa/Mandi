using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dialogs : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    public TextMeshProUGUI textNpc;
    public DialogueData dialogueData;
    private int correntText = 0;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Dialog(string npc)
    {
        if (correntText < dialogueData.talkScript.Count && Input.GetKeyDown("g")) correntText++; 

        if (npc == "Cacique")
        {
            textNpc.text = Convert.ToString(dialogueData.talkScript[correntText].text);
            canvas.targetDisplay = 0;
        }
        else if (npc == "Velho")
        {
            textNpc.text = "Olá eu sou o Velho";
            canvas.targetDisplay = 0;
        }
        if (npc == default)
        {
            canvas.targetDisplay = 1;
        }
        if (correntText < dialogueData.talkScript.Count)
        {
            Dialog(npc);
        }
        else correntText = 0;
    }
}
