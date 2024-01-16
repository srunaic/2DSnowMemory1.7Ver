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
    //ScriptableObject�� �����͸� �����ϱ� ���� ����
    //�׷��� �Լ� ����

    public monoDialog[] dialogList;

}
