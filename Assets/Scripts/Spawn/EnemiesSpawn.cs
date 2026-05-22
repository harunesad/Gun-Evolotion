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
    public Transform parent;
    public int attack;
    public int needKillCount;
    private void Awake()
    {
        enemiesSpawn = this;
    }
    public void EnemySpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            int random = Random.Range(0, posZ.Count);
            var cash = Instantiate(enemiesCash[0], new Vector3(Random.Range(-2, 2), 0, posZ[random]), enemiesCash[0].transform.rotation);
            posZ.RemoveAt(random);
            
            EnemyStateManager manager = cash.GetComponentInChildren<EnemyStateManager>();
            if (manager != null)
            {
                manager.needKillBullet *= (GameEnd.end.levelNumber + 1);
                if (manager.needKillBulletText != null)
                {
                    manager.needKillBulletText.text = "" + manager.needKillBullet;
                }
            }
        }
        for (int j = FirstGunSpawn.first.startIndex; j < FirstGunSpawn.first.startIndex + 5; j++)
        {
            if (j < FirstGunSpawn.first.guns.Count)
            {
                var enemy = Instantiate(enemies[j], new Vector3(Random.Range(-2, 2), 0, posZ[0]), enemies[j].transform.rotation);
                strongEnemy = enemy;
                posZ.RemoveAt(0);
                
                EnemyStateManager manager = strongEnemy.GetComponentInChildren<EnemyStateManager>();
                if (manager != null)
                {
                    parent = manager.transform;
                    manager.needKillBullet *= (GameEnd.end.levelNumber + 1);
                    if (manager.levelText != null)
                    {
                        manager.levelText.text = "Level " + manager.enemyLevel;
                    }
                    if (manager.needKillBulletText != null)
                    {
                        manager.needKillBulletText.text = "" + manager.needKillBullet;
                    }
                }
            }
        }
        if (posZ.Count > 0)
        {
            for (int k = 0; k < posZ.Count; k++)
            {
                var cash = Instantiate(enemiesCash[0], new Vector3(Random.Range(-2, 2), 0, posZ[k]), enemiesCash[0].transform.rotation);
                EnemyStateManager manager = cash.GetComponentInChildren<EnemyStateManager>();
                if (manager != null)
                {
                    manager.needKillBullet *= (GameEnd.end.levelNumber + 1);
                    if (manager.needKillBulletText != null)
                    {
                        manager.needKillBulletText.text = "" + manager.needKillBullet;
                    }
                }
            }
        }
        
        if (parent != null)
        {
            EnemyStateManager manager = parent.GetComponent<EnemyStateManager>();
            if (manager != null)
            {
                attack = (int)Mathf.Round(manager.needKillBullet / 4) + 1;
                needKillCount = (int)Mathf.Round(manager.needKillBullet);
            }
            else
            {
                attack = 1;
                needKillCount = 10;
            }
        }
        else
        {
            attack = 1;
            needKillCount = 10;
        }
    }
}
