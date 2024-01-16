using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���¸� �����ϴµ� ���� ������ ����
enum tState
{
    Off,     //����ǥ���� ���� ����
    Typeing, //���ڸ� ǥ���ϴ� ����
    Wait,    //������ ������ ��ٸ��� ����
    End      //��� ������ ���� ����
}

public class TextViewer : MonoBehaviour
{
    public Image speakerImage; //ȭ���� �ʻ�ȭ�� ǥ���ϴ� ��
    public Text speakerViewer; //�̸��� ǥ���ϴ� ������Ʈ
    public Text textViewer; //���ڸ� ǥ���ϴ� ������Ʈ

    public GameObject textViewBox; //HiddenNpc��ȭâ
    public GameObject NextMark;
    public GameObject SkipMark;
    public GameObject EndMark;

    [SerializeField]
    tState viewState = tState.Off;

    //
    public DialogData dialogData; //ǥ���� ��ȭ

    [SerializeField]
    monoDialog nowDialog; //�̹��� ǥ���� ��ȭ
    [SerializeField]
    string[] textList; //ǥ���� ���� ���
    [SerializeField]
    string nowText; //�̹��� ǥ���� ����

    int dialogNum;// �̹� ��ȭ ����
    int textNum;  // �̹� ���� ����
    int charNum;  // �̹� ���� ���� 

    public float typeDelay = 0.07f; //���ڸ��� ��� �ð�
    float delayTime = 0; //���� ��� �ð��� Ȯ��

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
        //����� if-elseif-else�� ������ ���¸� ����
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
                //�̹��� ǥ���� ����(charNum)��
                //ǥ���� ������ ����(nowText.Length)����
                //������
                //(�迭�� ������ 0���Ͷ� ���̿� ���� ������ ������)
                if (charNum < nowText.Length)
                {
                    //���� �Է� - �ѱ��ڸ� �߰�
                    char typeChar = nowText[charNum];

                    if (typeChar == '!')
                    {
                        //â�� ����.
                        //boxAnimator.SetTrigger("Shake");
                    }

                    textViewer.text += typeChar;

                    charNum++;

                    delayTime = 0;
                }
                else //������ �������
                {
                    textNum++;

                    //���� ������ ���� ���
                    //���� ������ ������ ���� ����� ���� ���ΰ�?
                    //textNum ���� textList.Length ���� ������?
                    if (textNum < textList.Length)
                    {
                        useSkip = false;

                        NextMark.SetActive(true);
                        SkipMark.SetActive(false);
                        EndMark.SetActive(false);

                        viewState = tState.Wait;
                    }
                    else //������ ����
                    {
                        dialogNum++;
                        //���� ��ȭ�� �ִ°��
                        if (dialogNum < dialogData.dialogList.Length)
                        {
                            //���� ��ȭ�� ����
                            nowDialog = dialogData.dialogList[dialogNum];

                            textList = nowDialog.dialog.Split('/');

                            //���� ��ȭ�� ù �ؽ�Ʈ�� ����
                            textNum = 0;
                            nowText = textList[textNum];

                            charNum = 0;
                            delayTime = typeDelay;

                            //�����·� ����
                            viewState = tState.Wait;
                        }
                        else //���� ��ȭ�� ���°��
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
                //������ ���� �ִ��� �����
                textViewer.text = "";
                //���� ���� ǥ���ϱ� ���� �ʿ��� �����ϰ�
                nowText = textList[textNum];
                charNum = 0; ;
                delayTime = typeDelay;

                //����� �ű�
                speakerViewer.text = nowDialog.speaker.viewName;
                speakerImage.sprite
                     = nowDialog.speaker.portrait[nowDialog.emotionCode];

                NextMark.SetActive(false);
                SkipMark.SetActive(true);
                EndMark.SetActive(false);

                //�ٽ� typeing ���� �ٲ��ش�..
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
            Debug.Log("���������� ����");
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

        delayTime = typeDelay; //ù���� �ٷ� ������ �ҷ���

        textNum = 0; //ù ������� Ȯ��
        charNum = 0; //ù ���ں��� Ȯ��

        //�̹��� ǥ���� ������ ù�������� ����
        nowText = textList[textNum];

        //�ؽ�Ʈ �ڽ��� ����
        NextMark.SetActive(false);
        SkipMark.SetActive(true);
        EndMark.SetActive(false);
        textViewBox.SetActive(true);

        viewState = tState.Typeing;
    }

}
