using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("��ü ����� ���� �ҽ�")]
    [Space(10f)]
    public static AudioManager instance;

    [SerializeField]
    private LanaPlayer Player; // ������ �÷��̾� ��ũ��Ʈ;

    public GameObject audioSourcePrefab; // ����� �ҽ� ������
   
   //ĳ���� ����� ȿ���� 
    public AudioSource audioSource;

    [Tooltip("����� ���� ������")]
   
    public AudioClip attackSound;
    public AudioClip jumpSound;
    public AudioClip GameOverAudio;
    public AudioClip KeyItemSound;
    public AudioClip PortSound;
    public AudioClip WaterSource;
    public AudioClip PlanetariumRocksSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        PlayJumpSound();
        PlayAttackSound();
    }

    public void PlayJumpSound()
    {
        if (Player.jump == true)
        {
                audioSource.clip = jumpSound;
                audioSource.Play();
          
        }
    }

    public void PlayAttackSound()
    {
        if (Player.isAttack == true)
        {
            audioSource.clip = attackSound;
            audioSource.Play();
        }
    }

    public void GameOverSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GameOverAudio;
            audioSource.Play();
        }
    }

    public void WaterSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = WaterSource;
            audioSource.Play();
        }

    }
    public void WaterSoundStop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.clip = WaterSource;
            audioSource.Stop();
        }

    }

    public void KeyItemQuick()
    {

        if (!audioSource.isPlaying)
        {
            audioSource.clip = KeyItemSound;
            audioSource.Play();
        }

    }

    public void PlanetBlockSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = PlanetariumRocksSound;
            audioSource.Play();
        }
    }
    public void PortalSound()
    {

        if (!audioSource.isPlaying)
        {
            audioSource.clip = PortSound;
            audioSource.Play();
        }
    }
}

    

