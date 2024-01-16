using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingItem2 : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // ȸ�� �ӵ�
    public GameObject Flying;//������ ���̴� ���� ������Ʈ �÷��̾ �޷�����.
    public bool OnFlying; //������ ������ �ִ� ��������.
    public LanaPlayer player;
    void Update()
    {
        // Z ���� �߽����� ��������Ʈ ȸ��
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            OnFlying = true;
            AirItemDestroy();
        }

    }
    public void AirItemDestroy()
    {
        if (OnFlying)
        {
            gameObject.SetActive(false);//�Ĺ� ������ 1ȸ�� ������ ��ü ����.
            Flying.SetActive(true); //�ö��̿� ��Ƴ���.

        }
    }

    public void FlyingItemRemove() //Ư�� ���ǿ��� �߻���.
    {
        OnFlying = false;
        Destroy(Flying, 1f);// �� �Լ��� LanaPlayer���� delay �߻��� ����. ���ӽð� ���� �� ��ü �ı�.
        player.flyItemDelay = 0;//0 �ʱ�ȭ.
    }
}
