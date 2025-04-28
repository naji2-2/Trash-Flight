using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float spawnInterval;

    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while (true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount++;
            if (spawnCount % 10 == 0)
            {
                enemyIndex++;
                moveSpeed += 2;
            }

            // 보스 등장
            if (enemyIndex >= enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        // 20%의 확률로 한 단계 높은 적이 나오록함
        if (Random.Range(0, 5) == 0)
        {
            index++;
        }

        if (index >= enemies.Length)
        {
            index -= enemies.Length - 1;
        }

        GameObject enmeyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enmeyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}