using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public bool UseDirect { get; }//True인 경우에 바로 상호작용함.

    public void Interact(GameObject player);
}
