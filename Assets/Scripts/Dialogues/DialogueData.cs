using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Dialogue
{
    public string name;
    [TextArea(5, 10)]
    public string text;
}
[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/TalkScript", order = 0)]
public class DialogueData : ScriptableObject
{
    public List<Dialogue> velho;
    public List<Dialogue> cacique;
    public List<Dialogue> aquyma;
}
