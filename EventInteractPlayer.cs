using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInteractPlayer : MonoBehaviour
{
    [Header("플레이어가 상호작용할 객체의 작동원리.")]

    [SerializeField]
    private GameObject EventUI;
    private float TimeSurvive = 5f;//지나는 시간.
    bool isTimeLimit = false;

    public void UIInteract()//플레이어가 접촉중임을 이미 매니저에서 적용 해줬음으로, 시간을 바로 적용.
    {
        isTimeLimit = true; // 접촉 시 true로 변경

        if (isTimeLimit) // 올바른 값일 때 실행
        {
            EventUI.SetActive(true);
            Debug.Log("이벤트 발생" + EventUI);

            StartCoroutine(TimeInterver());

        }
    }

    //타임 리미트 값 설정. 특정상황 연출.
    IEnumerator TimeInterver()
    {
        yield return new WaitForSeconds(TimeSurvive);

        EventUI.SetActive(false); // 이벤트 UI 숨기기
        Debug.Log("이벤트 제거" + EventUI);
        isTimeLimit = false;
    }

}
