using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandomRespawn : MonoBehaviour
{
   
    public GameObject Monster;
    public GameObject rangeObject;
    BoxCollider2D rangeCollider;
    public int maxMonsterCount = 5; // 생성될 몬스터의 최대 개수
    private int currentMonsterCount = 0; // 현재 생성된 몬스터 개수
    public float textDisappearTime = 5.0f; // 텍스트가 사라지는데 걸리는 시간

    private bool Emergency = false;
    private float timer = 0f;

    [SerializeField]
    private GameObject MonsterText;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    Vector3 Return_RandomPosition() //적 랜덤 생성 로직.
    {
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        //float range_Z = rangeCollider.bounds.size.y; // 여기서 z를 y로 수정 3D에서 쓰는 방식.
        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        //range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPosition = new Vector3(range_X, 0f);// range_Z);
        Vector3 respawnPosition = originPosition + RandomPosition;
        return respawnPosition;
    }

    public void OnTriggerEnter2D(Collider2D other) //랜덤으로 적이 스폰됨.
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RandomRespawn_Coroutine());
            MonsterText.SetActive(true);
            Emergency = true;

        }

     
    }
 
    private void Update()//트리거 적용 했을때, 텍스트 컨트롤 방법
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

            // Monster가 null인지 확인 후에 Instantiate
            if (Monster != null && Emergency)
            {
                GameObject instantMonster = Instantiate(Monster, Return_RandomPosition(), Quaternion.identity);
                currentMonsterCount++;
            }
            else
            {
                Debug.LogWarning("Monster 프리팹이 null입니다. 프리팹을 할당하세요.");
            }
        }
    }
}
