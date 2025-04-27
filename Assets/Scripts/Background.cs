using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour 
{
    private float moveSpeed = 3f;

    void Update()
    {
        // 일정한 속도로 이미지가 아래로 내려오도록 함
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
        if (transform.position.y < -10)
        {
            // 배경 이미지의 y위치가 -10 아래로 내려온 경우 y위치를 10으로 올림
            transform.position += new Vector3(0, 20f, 0);
        }
    }
    
}
