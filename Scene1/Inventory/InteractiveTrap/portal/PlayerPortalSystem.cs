using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalSystem : MonoBehaviour
{
    public static PlayerPortalSystem instance;

    public FaidInOut Faid;


    [Header("따로적용되는 객체 지향성 포탈.")]
    public Transform MainPlayerPortal;
    public GameObject PlanetPors;

    private LanaPlayer thePlayer;
    private float PortalTime;

    private void Start()
    {
        thePlayer = FindObjectOfType<LanaPlayer>();
        Faid = FindObjectOfType<FaidInOut>(); //제네릭 싱글톤
    }


   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //플레이어와 부딪힐때, 발생하는 코드.
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
