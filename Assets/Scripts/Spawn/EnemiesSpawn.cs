using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> enemiesCash;
    public List<float> posZ;
    void Start()
    {
        for (int i = 0; i < posZ.Count; i++)
        {
            RandomEnemies(i);
        }
    }
    void RandomEnemies(int z)
    {
        int random = Random.Range(0, 2);
        if (enemies.Count >= FirstGunSpawn.first.startIndex + 1)
        {
            EnemiesChose(0, z);
        }
        else
        {
            EnemiesChose(1, z);
        }
    }
    void EnemiesChose(int chose, int z)
    {
        switch (chose)
        {
            case 0:
                Instantiate(enemies[FirstGunSpawn.first.startIndex], new Vector3(Random.Range(-2, 2), 0.5f, posZ[z]), enemies[FirstGunSpawn.first.startIndex].transform.rotation);
                enemies.RemoveAt(FirstGunSpawn.first.startIndex);
                break;
            case 1:
                Instantiate(enemiesCash[0], new Vector3(Random.Range(-2, 2), 0.5f, posZ[z]), Quaternion.identity);
                break;
            default:
                break;
        }
    }
    void Update()
    {
        
    }
}
