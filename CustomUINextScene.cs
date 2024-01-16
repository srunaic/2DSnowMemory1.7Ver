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
        if (!Clicked) //함수를 넣어서 관리.
        {
            Clicked = true;
            Debug.Log("함수 실행.");
            NextScene();
        }
        else
        {
            Clicked = false;
            Debug.Log("버튼 비활성화");
        }

    }
    public void OnClickHelpus()
    {
        if (!Clicked) //함수를 넣어서 관리.
        {
            Clicked = true;
            Debug.Log("함수 실행.");
            helpus.SetActive(true);
        }

        else
        {
            Clicked = false;
            Debug.Log("버튼 비활성화");
        }

    }
    public void ImageSet()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            helpus.SetActive(false);
        }
    }
    // UI 버튼 클릭 시 호출될 함수
    public void QuitGame()
    {
        // 애플리케이션 종료
        Application.Quit();

        // 주의: 에디터 상에서는 작동하지 않을 수 있습니다.
        // 게임을 플레이하는 동안에만 사용하도록 합니다.
    }

 
    public void NextScene() //다음 씬
    {
        SceneManager.LoadScene("2DMainSnowProtocol"); // Replace "NextSceneName" with the name of your next scene
    }
}
