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
                textNpc.text = Convert.ToString(dialogueData.cacique[correntText].text);
                break;

            case "Velho":
                textNpc.text = Convert.ToString(dialogueData.velho[correntText].text);
                break;
        }
        canvas.targetDisplay = 0;
        correntText++;
    }

    public bool NextDialog()
    {
        Debug.Log(correntText);
        string dialo;
        switch (mainNpc)
        {
            case "Cacique":
                textNpc.text = Convert.ToString(dialogueData.cacique[correntText].text);
                break;

            case "Velho":
                textNpc.text = Convert.ToString(dialogueData.velho[correntText].text);
                break;
        }
        
        if (correntText < dialogueData.velho.Count)
        {
            correntText++;
            canvas.targetDisplay = 0;
            return true;
        } else {
            correntText = 0;
            canvas.targetDisplay = 1;
            return false;
        }
    }
}
