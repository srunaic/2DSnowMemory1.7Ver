using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speaker Data", menuName = "Scriptable Object/Speaker Data", order = int.MaxValue)]
public class SpeakerData : ScriptableObject
{
    public string viewName; //������ �̸�

    public Sprite[] portrait; //������ �̹��� 
}
