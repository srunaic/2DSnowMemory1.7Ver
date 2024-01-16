using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgController : MonoBehaviour
{
    [SerializeField]
    private GameObject StartUI;
    private float UIDuration = 3f;//15�ʰ� ������.

    private void Start() //���� ���۽� �߻� �Լ�
    {
        StartUI.SetActive(true);
        Time.timeScale = 0;//�Ͻ�����
     
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            HideUI();
        }
    }

    private void HideUI()
    {
        StartUI.SetActive(false);
        Time.timeScale = 1;//����.

    }
}
