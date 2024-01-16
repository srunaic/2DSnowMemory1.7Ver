using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandomRespawn : MonoBehaviour
{
   
    public GameObject Monster;
    public GameObject rangeObject;
    BoxCollider2D rangeCollider;
    public int maxMonsterCount = 5; // ������ ������ �ִ� ����
    private int currentMonsterCount = 0; // ���� ������ ���� ����
    public float textDisappearTime = 5.0f; // �ؽ�Ʈ�� ������µ� �ɸ��� �ð�

    private bool Emergency = false;
    private float timer = 0f;

    [SerializeField]
    private GameObject MonsterText;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    Vector3 Return_RandomPosition() //�� ���� ���� ����.
    {
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        //float range_Z = rangeCollider.bounds.size.y; // ���⼭ z�� y�� ���� 3D���� ���� ���.
        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        //range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPosition = new Vector3(range_X, 0f);// range_Z);
        Vector3 respawnPosition = originPosition + RandomPosition;
        return respawnPosition;
    }

    public void OnTriggerEnter2D(Collider2D other) //�������� ���� ������.
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RandomRespawn_Coroutine());
            MonsterText.SetActive(true);
            Emergency = true;

        }

     
    }
 
    private void Update()//Ʈ���� ���� ������, �ؽ�Ʈ ��Ʈ�� ���
    {
       if (Emergency)
        {
            timer += Time.deltaTime;
            if (timer >= textDisappearTime)
            {
                MonsterText.SetActive(false);
                Emergency = false;
                timer = 0f;
            }
        }
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (currentMonsterCount < maxMonsterCount)
        {
            yield return new WaitForSeconds(1f);

            // Monster�� null���� Ȯ�� �Ŀ� Instantiate
            if (Monster != null && Emergency)
            {
                GameObject instantMonster = Instantiate(Monster, Return_RandomPosition(), Quaternion.identity);
                currentMonsterCount++;
            }
            else
            {
                Debug.LogWarning("Monster �������� null�Դϴ�. �������� �Ҵ��ϼ���.");
            }
        }
    }
}
