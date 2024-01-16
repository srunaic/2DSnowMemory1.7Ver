using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLana : MonoBehaviour
{
    public bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public Animator anim;

}
