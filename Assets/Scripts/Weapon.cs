using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;

    void Start()
    {
        // 1초가 지나면 없어지도록 함
        Destroy(gameObject, 1);
    }


    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
