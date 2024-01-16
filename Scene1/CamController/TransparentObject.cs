using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [Header("캐릭터 지나갈시 투명 오브젝트 처리.")]
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float transparentAlpha = 0.2f; // 투명화시킬 알파 값 (0부터 1까지)

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //이 스크립트 주의사항 투명화 오브젝트의 중심점을 맞춰야 확인됨.
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
        else
        {
            // 스프라이트 렌더러를 찾을 수 없는 경우 처리할 내용 추가.
        }
    }

    private void Update()
    {
        // 스프라이트의 월드 좌표를 가져옴
        Vector3 spriteWorldPos = transform.position;

        // 스프라이트가 화면 내에 있는지 확인
        if (spriteRenderer != null && IsVisibleOnScreen(spriteWorldPos))
        {
            // 투명화 처리
            Color newColor = spriteRenderer.color;
            newColor.a = transparentAlpha; // 알파 값을 설정하여 투명화
            spriteRenderer.color = newColor;
        }
        else if (spriteRenderer != null)
        {
            // 카메라 화면 밖에 있는 경우 원래 색상으로 복원
            spriteRenderer.color = originalColor;
        }
    }

    private bool IsVisibleOnScreen(Vector3 worldPos)
    {
        // 카메라가 스프라이트의 X, Y 좌표를 포함하면 화면 내에 있는 것으로 간주
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 screenPoint = mainCamera.WorldToViewportPoint(worldPos);
            return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
        }
        return false;
    }
}
