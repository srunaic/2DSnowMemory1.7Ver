using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInteractPlayer : MonoBehaviour
{
    [Header("�÷��̾ ��ȣ�ۿ��� ��ü�� �۵�����.")]

    [SerializeField]
    private GameObject EventUI;
    private float TimeSurvive = 5f;//������ �ð�.
    bool isTimeLimit = false;

    public void UIInteract()//�÷��̾ ���������� �̹� �Ŵ������� ���� ����������, �ð��� �ٷ� ����.
    {
        isTimeLimit = true; // ���� �� true�� ����

        if (isTimeLimit) // �ùٸ� ���� �� ����
        {
            EventUI.SetActive(true);
            Debug.Log("�̺�Ʈ �߻�" + EventUI);

            StartCoroutine(TimeInterver());

        }
    }

    //Ÿ�� ����Ʈ �� ����. Ư����Ȳ ����.
    IEnumerator TimeInterver()
    {
        yield return new WaitForSeconds(TimeSurvive);

        EventUI.SetActive(false); // �̺�Ʈ UI �����
        Debug.Log("�̺�Ʈ ����" + EventUI);
        isTimeLimit = false;
    }

}
