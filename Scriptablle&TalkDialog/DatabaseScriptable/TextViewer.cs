using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//상태를 구분하는데 좋은 열거형 변수
enum tState
{
    Off,     //글자표현이 없는 상태
    Typeing, //글자를 표현하는 상태
    Wait,    //문장이 끝나고 기다리는 상태
    End      //모든 문장이 끝난 상태
}

public class TextViewer : MonoBehaviour
{
    public Image speakerImage; //화자의 초상화를 표현하는 곳
    public Text speakerViewer; //이름을 표현하는 컴포넌트
    public Text textViewer; //글자를 표현하는 컴포넌트

    public GameObject textViewBox; //HiddenNpc대화창
    public GameObject NextMark;
    public GameObject SkipMark;
    public GameObject EndMark;

    [SerializeField]
    tState viewState = tState.Off;

    //
    public DialogData dialogData; //표현할 대화

    [SerializeField]
    monoDialog nowDialog; //이번에 표현할 대화
    [SerializeField]
    string[] textList; //표현할 문장 목록
    [SerializeField]
    string nowText; //이번에 표현할 문장

    int dialogNum;// 이번 대화 순서
    int textNum;  // 이번 문장 순서
    int charNum;  // 이번 글자 순서 

    public float typeDelay = 0.07f; //글자마다 대기 시간
    float delayTime = 0; //누적 대기 시간을 확인

    bool useSkip = false; 

    
    void Start()
    {
        viewState = tState.Off;

        textViewBox.SetActive(false);

    }

    void Update()
    {
        NextTyping();
    }

    public void NextTyping()
    {
        //연결된 if-elseif-else로 완전히 상태를 구분
        if (viewState == tState.Off)
        {

        }
        else if (viewState == tState.Typeing)
        {
            if (!useSkip && Input.GetKeyDown(KeyCode.Z))
            {
                useSkip = true;
            }
            if (useSkip || delayTime >= typeDelay)
            {
                //이번에 표현할 순서(charNum)가
                //표현할 문장의 길이(nowText.Length)보다
                //작을때
                //(배열의 순서는 0부터라 길이와 같은 순서는 범위밖)
                if (charNum < nowText.Length)
                {
                    //글자 입력 - 한글자를 추가
                    char typeChar = nowText[charNum];

                    if (typeChar == '!')
                    {
                        //창을 흔든다.
                        //boxAnimator.SetTrigger("Shake");
                    }

                    textViewer.text += typeChar;

                    charNum++;

                    delayTime = 0;
                }
                else //문장이 끝난경우
                {
                    textNum++;

                    //아직 문장이 남은 경우
                    //다음 순서의 문장이 문장 목록의 범위 안인가?
                    //textNum 값이 textList.Length 보다 작은가?
                    if (textNum < textList.Length)
                    {
                        useSkip = false;

                        NextMark.SetActive(true);
                        SkipMark.SetActive(false);
                        EndMark.SetActive(false);

                        viewState = tState.Wait;
                    }
                    else //마지막 문장
                    {
                        dialogNum++;
                        //다음 대화가 있는경우
                        if (dialogNum < dialogData.dialogList.Length)
                        {
                            //다음 대화를 세팅
                            nowDialog = dialogData.dialogList[dialogNum];

                            textList = nowDialog.dialog.Split('/');

                            //다음 대화의 첫 텍스트를 세팅
                            textNum = 0;
                            nowText = textList[textNum];

                            charNum = 0;
                            delayTime = typeDelay;

                            //대기상태로 변경
                            viewState = tState.Wait;
                        }
                        else //다음 대화가 없는경우
                        {
                            NextMark.SetActive(false);
                            SkipMark.SetActive(false);
                            EndMark.SetActive(true);

                            viewState = tState.End;
                        }
                    }
                }
            }

            delayTime += Time.deltaTime;
        }
        else if (viewState == tState.Wait)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //기존에 적혀 있던거 지우고
                textViewer.text = "";
                //다음 문장 표현하기 위해 필요한 세팅하고
                nowText = textList[textNum];
                charNum = 0; ;
                delayTime = typeDelay;

                //여기로 옮김
                speakerViewer.text = nowDialog.speaker.viewName;
                speakerImage.sprite
                     = nowDialog.speaker.portrait[nowDialog.emotionCode];

                NextMark.SetActive(false);
                SkipMark.SetActive(true);
                EndMark.SetActive(false);

                //다시 typeing 상태 바꿔준다..
                viewState = tState.Typeing;
            }
        }
        else if (viewState == tState.End)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                textViewer.text = "";
                textViewBox.SetActive(false);

                viewState = tState.Off;
            }
        }
        else
        {
            Debug.Log("비정상적인 상태");
        }

    }


    public void SetTextList(DialogData data)
    {
        dialogNum = 0;
        nowDialog = data.dialogList[dialogNum];

        textList = nowDialog.dialog.Split('/');
        speakerViewer.text = nowDialog.speaker.viewName;
        speakerImage.sprite
            = nowDialog.speaker.portrait[nowDialog.emotionCode];
    }
    public void StartTextView()
    {
        textViewer.text = "";

        delayTime = typeDelay; //첫글자 바로 나오게 할려고

        textNum = 0; //첫 문장부터 확인
        charNum = 0; //첫 글자부터 확인

        //이번에 표현할 문장을 첫문장으로 세팅
        nowText = textList[textNum];

        //텍스트 박스를 켜줌
        NextMark.SetActive(false);
        SkipMark.SetActive(true);
        EndMark.SetActive(false);
        textViewBox.SetActive(true);

        viewState = tState.Typeing;
    }

}
