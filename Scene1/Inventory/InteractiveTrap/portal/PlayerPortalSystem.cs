using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalSystem : MonoBehaviour
{
    public static PlayerPortalSystem instance;

    public FaidInOut Faid;


    [Header("��������Ǵ� ��ü ���⼺ ��Ż.")]
    public Transform MainPlayerPortal;
    public GameObject PlanetPors;

    private LanaPlayer thePlayer;
    private float PortalTime;

    private void Start()
    {
        thePlayer = FindObjectOfType<LanaPlayer>();
        Faid = FindObjectOfType<FaidInOut>(); //���׸� �̱���
    }


   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //�÷��̾�� �ε�����, �߻��ϴ� �ڵ�.
        {
            Faid.Fade();

            thePlayer.transform.position = MainPlayerPortal.position;
           
            PortalTime += Time.deltaTime;

            if (PortalTime >= 3f)
            {
                PlanetPors.SetActive(false);
            }
            else

                PortalTime = 0;
        }
    }

}
