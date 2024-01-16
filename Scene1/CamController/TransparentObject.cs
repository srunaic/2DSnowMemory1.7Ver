using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [Header("ĳ���� �������� ���� ������Ʈ ó��.")]
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float transparentAlpha = 0.2f; // ����ȭ��ų ���� �� (0���� 1����)

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //�� ��ũ��Ʈ ���ǻ��� ����ȭ ������Ʈ�� �߽����� ����� Ȯ�ε�.
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
        else
        {
            // ��������Ʈ �������� ã�� �� ���� ��� ó���� ���� �߰�.
        }
    }

    private void Update()
    {
        // ��������Ʈ�� ���� ��ǥ�� ������
        Vector3 spriteWorldPos = transform.position;

        // ��������Ʈ�� ȭ�� ���� �ִ��� Ȯ��
        if (spriteRenderer != null && IsVisibleOnScreen(spriteWorldPos))
        {
            // ����ȭ ó��
            Color newColor = spriteRenderer.color;
            newColor.a = transparentAlpha; // ���� ���� �����Ͽ� ����ȭ
            spriteRenderer.color = newColor;
        }
        else if (spriteRenderer != null)
        {
            // ī�޶� ȭ�� �ۿ� �ִ� ��� ���� �������� ����
            spriteRenderer.color = originalColor;
        }
    }

    private bool IsVisibleOnScreen(Vector3 worldPos)
    {
        // ī�޶� ��������Ʈ�� X, Y ��ǥ�� �����ϸ� ȭ�� ���� �ִ� ������ ����
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 screenPoint = mainCamera.WorldToViewportPoint(worldPos);
            return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
        }
        return false;
    }
}
