using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractIceField : MonoBehaviour, Interactable
{
    [Header("이 객체랑 충돌했다는 판단 로직.")]
    bool TriggerDirect = true;

    [SerializeField]
    private EventInteractPlayer EventPlayer;//참조할 스크립트.

    void Awake()
    {
        EventPlayer = FindObjectOfType<EventInteractPlayer>(); //시작할때, 이 스크립트를 참조한다.
    }

    public bool UseDirect
    {
        get { return TriggerDirect; }
    }

    public void Interact(GameObject player)
    {
        ContactIceTrigger(player);//트리거 플레이어.
    }

    public void ContactIceTrigger(GameObject IceTrig)
    {
        EventPlayer.UIInteract();//EventPlayer의 함수를 참조함.

    }

}
