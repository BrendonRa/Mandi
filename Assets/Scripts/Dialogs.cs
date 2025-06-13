using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialogs : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Dialogs"))
        {
            switch (PlayerPrefs.GetString("Dialogs", ""))
            {
                case "CaciqueDialog":
                    canvas.targetDisplay = 0;
                    break;
            }
        }
        else
        {
            canvas.targetDisplay = 1;
        }
    }
}
