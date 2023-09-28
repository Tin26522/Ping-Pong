using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScale : MonoBehaviour
{
    SpriteRenderer bgSprite;

    void Start()
    {
        bgSprite = GetComponent<SpriteRenderer>();

        // Lấy kích thước của camera
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Lấy kích thước hiện tại của background
        float bgHeight = bgSprite.sprite.bounds.size.y;
        float bgWidth = bgSprite.sprite.bounds.size.x;

        // Tính toán tỷ lệ scale cho cả chiều rộng và chiều cao
        float scaleX = cameraWidth / bgWidth;
        float scaleY = cameraHeight / bgHeight;

        // Tính toán khoảng cách giữa camera và nền
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

        // Tính toán vị trí mới cho background để đảm bảo không còn sai số
        Vector3 newScale = new Vector3(scaleX, scaleY, 1f);
        Vector3 newPosition = Camera.main.transform.position + Vector3.forward * distanceToCamera;

        // Áp dụng tỷ lệ và vị trí cho background
        transform.localScale = newScale;
        transform.position = newPosition;
    }
}
