using System;
using TMPro;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    public TextMeshProUGUI textNpc;
    public DialogueData dialogueData;
    private int correntText = 0;
    string mainNpc;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Dialog(string npc)
    {
        mainNpc = npc;
        switch (mainNpc)
        {
            case "Cacique":
                textNpc.text = Convert.ToString(dialogueData.talkScript[correntText].text);
                canvas.targetDisplay = 0;
                break;

            case "Velho":
                break;
        }
    }

    public bool NextDialog()
    {
        Debug.Log(dialogueData.talkScript.Count);
        switch (mainNpc)
        {
            case "Cacique":
                textNpc.text = Convert.ToString(dialogueData.talkScript[correntText].text);
                break;

            case "Velho":
                break;
        }

        if (correntText < dialogueData.talkScript.Count)
        {
            correntText++;
            canvas.targetDisplay = 0;
            return false;
        }
        else
        {
            correntText = 0;
            canvas.targetDisplay = 1;
            return true;
        }
    }
}
