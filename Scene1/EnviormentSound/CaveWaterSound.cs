using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveWaterSound : MonoBehaviour
{
    public AudioManager audioManager;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.WaterSound();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.WaterSoundStop();
        }
    }
}
