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
    string mainNpcText;
    int dialoCount;
    string mainNpc;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Dialog(string npc)
    {
        mainNpc = npc;
        switch (npc)
        {
            case "Cacique":
                dialoCount = dialogueData.cacique.Count;
                mainNpcText = Convert.ToString(dialogueData.cacique[correntText].text);
                break;

            case "Velho":
                dialoCount = dialogueData.velho.Count;
                mainNpcText = Convert.ToString(dialogueData.velho[correntText].text);
                break;
        }
        textNpc.text = mainNpcText;
        canvas.targetDisplay = 0;
        correntText++;
    }

    public bool NextDialog()
    {   
        if (correntText < dialoCount)
        {
            Dialog(mainNpc);
            return true;
        } else {
            correntText = 0;
            canvas.targetDisplay = 1;
            return false;
        }
    }
}
