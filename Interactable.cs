using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public bool UseDirect { get; }//True�� ��쿡 �ٷ� ��ȣ�ۿ���.

    public void Interact(GameObject player);
}
