using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgController : MonoBehaviour
{
    [SerializeField]
    private GameObject StartUI;
    private float UIDuration = 3f;//15초가 지날시.

    private void Start() //게임 시작시 발생 함수
    {
        StartUI.SetActive(true);
        Time.timeScale = 0;//일시정지
     
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
        Time.timeScale = 1;//해제.

    }
}
