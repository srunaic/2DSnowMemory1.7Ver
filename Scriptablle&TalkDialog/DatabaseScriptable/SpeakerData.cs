using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speaker Data", menuName = "Scriptable Object/Speaker Data", order = int.MaxValue)]
public class SpeakerData : ScriptableObject
{
    public string viewName; //보여질 이름

    public Sprite[] portrait; //보여질 이미지 
}
