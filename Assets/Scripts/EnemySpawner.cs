using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Camera _camera;
    private Dictionary<GameObject, EnemyBehaviour> EnemyDatas;
    [NonSerialized]public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        EnemyDatas = new Dictionary<GameObject, EnemyBehaviour>();
        foreach (var enemyPrefab in enemyPrefabs)
        {
            EnemyDatas[enemyPrefab] = enemyPrefab.GetComponent<EnemyBehaviour>();
        }
        InvokeRepeating(nameof(SpawnEnemies), 0.0f, 1f);
    }

    public void SpawnEnemies()
    {
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            var enemyData = EnemyDatas[enemyPrefab];
            for (int i = 0; i < enemyData.spawnAmount; i++)
            {
                if (Random.Range(0f, 100f) <= enemyData.spawnRate)
                {
                    // Debug.Log($"He spawneado algo");
                    var enemy = Instantiate(enemyPrefab,
                        GetRandomSpawnPosition(),
                        Quaternion.identity);
                    enemy.GetComponent<EnemyBehaviour>().playerTransform = player.transform;
                }
            }


        }

    }

    public Vector2 GetRandomSpawnPosition()
    {
        var x = Random.Range(-0.3f, 0.3f);
        if (x > 0) x += 1f;
        var y = Random.Range(-0.3f, 0.3f);
        if (y > 0) y += 1f;

        return _camera.ViewportToWorldPoint(new Vector2(x, y));


    }

    // Update is called once per frame
    void Update()
    {

    }
}
