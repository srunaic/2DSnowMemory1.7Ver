using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractIceField : MonoBehaviour, Interactable
{
    [Header("�� ��ü�� �浹�ߴٴ� �Ǵ� ����.")]
    bool TriggerDirect = true;

    [SerializeField]
    private EventInteractPlayer EventPlayer;//������ ��ũ��Ʈ.

    void Awake()
    {
        EventPlayer = FindObjectOfType<EventInteractPlayer>(); //�����Ҷ�, �� ��ũ��Ʈ�� �����Ѵ�.
    }

    public bool UseDirect
    {
        get { return TriggerDirect; }
    }

    public void Interact(GameObject player)
    {
        ContactIceTrigger(player);//Ʈ���� �÷��̾�.
    }

    public void ContactIceTrigger(GameObject IceTrig)
    {
        EventPlayer.UIInteract();//EventPlayer�� �Լ��� ������.

    }

}
