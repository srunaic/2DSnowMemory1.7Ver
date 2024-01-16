using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class monoDialog
{
    //public string speaker;
    public SpeakerData speaker;
    public int emotionCode = 0;
    [TextArea(3, 10)]
    public string dialog;
}
[CreateAssetMenu(fileName = "Dialog Data", menuName = "Scriptable Object/Dialog Data", order = int.MaxValue)]
public class DialogData : ScriptableObject
{
    //ScriptableObject는 데이터를 보관하기 위한 목적
    //그래서 함수 없음

    public monoDialog[] dialogList;

}
