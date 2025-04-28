using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private float minY = -7;

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
