using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBtnBufferRemove : MonoBehaviour
{
    [SerializeField]
    private GameObject ActiveTrapObj;

    public Sprite OffImage;
    SpriteRenderer myRenderer;

    private bool OnBtn = false;

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           
           OnBtn = true;

        }

    }

    void Update()
    {
      
        if (OnBtn)
        {
            myRenderer.sprite = OffImage;
            ActiveTrapObj.SetActive(false);//false
        }
        
    }

}
