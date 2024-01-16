using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomUINextScene : MonoBehaviour
{
    public Button Btn;
    private bool Clicked = false;
    public GameManager gameManager;

    private float Timer = 0f;

    [SerializeField]
    private GameObject helpus;

    public void Update()
    {
        ImageSet();
    }

    public void OnClickFuntion()
    {
        if (!Clicked) //�Լ��� �־ ����.
        {
            Clicked = true;
            Debug.Log("�Լ� ����.");
            NextScene();
        }
        else
        {
            Clicked = false;
            Debug.Log("��ư ��Ȱ��ȭ");
        }

    }
    public void OnClickHelpus()
    {
        if (!Clicked) //�Լ��� �־ ����.
        {
            Clicked = true;
            Debug.Log("�Լ� ����.");
            helpus.SetActive(true);
        }

        else
        {
            Clicked = false;
            Debug.Log("��ư ��Ȱ��ȭ");
        }

    }
    public void ImageSet()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            helpus.SetActive(false);
        }
    }
    // UI ��ư Ŭ�� �� ȣ��� �Լ�
    public void QuitGame()
    {
        // ���ø����̼� ����
        Application.Quit();

        // ����: ������ �󿡼��� �۵����� ���� �� �ֽ��ϴ�.
        // ������ �÷����ϴ� ���ȿ��� ����ϵ��� �մϴ�.
    }

 
    public void NextScene() //���� ��
    {
        SceneManager.LoadScene("2DMainSnowProtocol"); // Replace "NextSceneName" with the name of your next scene
    }
}
