using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetariumPortal : MonoBehaviour
{

    [Header("��������Ǵ� ��ü ���⼺ ��Ż.")]
    public Transform PlanetPortal;
    private LanaPlayer thePlayer;



    private void Start()
    {
        thePlayer = FindObjectOfType<LanaPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            thePlayer.transform.position = PlanetPortal.position;
        }
  
    }

}
