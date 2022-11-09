using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    public static EnemiesSpawn enemiesSpawn;
    public List<GameObject> enemies;
    public List<GameObject> enemiesCash;
    public List<float> posZ;
    public GameObject strongEnemy;
    private void Awake()
    {
        enemiesSpawn = this;
    }
    void Start()
    {
        //for (int i = 0; i < posZ.Count; i++)
        //{
        //    RandomEnemies(i);
        //}
        int count = posZ.Count - (enemies.Count - FirstGunSpawn.first.startIndex);
        for (int k = 0; k < 2; k++)
        {
            int random = Random.Range(0, posZ.Count);
            Instantiate(enemiesCash[0], new Vector3(Random.Range(-2, 2), 0, posZ[random]), enemiesCash[0].transform.rotation);
            posZ.RemoveAt(random);
        }
        for (int j = FirstGunSpawn.first.startIndex; j < FirstGunSpawn.first.startIndex + 4; j++)
        {
            //int random = Random.Range(0, posZ.Count);
            if (j < FirstGunSpawn.first.guns.Count)
            {
                var enemy = Instantiate(enemies[j], new Vector3(Random.Range(-2, 2), 0, posZ[j]), enemies[j].transform.rotation);
                strongEnemy = enemy;
            }
            //enemies.RemoveAt(j);
            //posZ.RemoveAt(random);
        }
    }
    void RandomEnemies(int z)
    {
        int random = Random.Range(0, 2);
        if (enemies.Count >= FirstGunSpawn.first.startIndex + 1)
        {
            EnemiesChose(random, z);
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
                Instantiate(enemies[FirstGunSpawn.first.startIndex], new Vector3(Random.Range(-2, 2), 0, posZ[z]), enemies[FirstGunSpawn.first.startIndex].transform.rotation);
                enemies.RemoveAt(FirstGunSpawn.first.startIndex);
                break;
            case 1:
                Instantiate(enemiesCash[0], new Vector3(Random.Range(-2, 2), 0, posZ[z]), Quaternion.identity);
                break;
            default:
                break;
        }
    }
    void Update()
    {
        
    }
}
