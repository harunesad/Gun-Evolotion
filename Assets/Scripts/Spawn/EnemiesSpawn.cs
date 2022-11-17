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
            GameObject parent = cash.transform.GetChild(0).gameObject;
            for (int j = 0; j < 5; j++)
            {
                parent = parent.transform.GetChild(0).gameObject;
            }
            parent.GetComponent<EnemyStateManager>().needKillBullet *= (GameEnd.end.levelNumber + 1);
            parent.GetComponent<EnemyStateManager>().needKillBulletText.text = "" + parent.GetComponent<EnemyStateManager>().needKillBullet;
        }
        for (int j = FirstGunSpawn.first.startIndex; j < FirstGunSpawn.first.startIndex + 5; j++)
        {
            if (j < FirstGunSpawn.first.guns.Count)
            {
                var enemy = Instantiate(enemies[j], new Vector3(Random.Range(-2, 2), 0, posZ[0]), enemies[j].transform.rotation);
                strongEnemy = enemy;
                posZ.RemoveAt(0);
                parent = strongEnemy.transform.GetChild(0);
                for (int i = 0; i < 7; i++)
                {
                    if (parent.GetComponent<EnemyStateManager>() == null)
                    {
                        parent = parent.transform.GetChild(0);
                    }
                }
                parent.GetComponent<EnemyStateManager>().needKillBullet *= (GameEnd.end.levelNumber + 1);
                parent.GetComponent<EnemyStateManager>().levelText.text = "Level " + parent.GetComponent<EnemyStateManager>().enemyLevel;
                parent.GetComponent<EnemyStateManager>().needKillBulletText.text = "" + parent.GetComponent<EnemyStateManager>().needKillBullet;
            }
        }
        if (posZ.Count > 0)
        {
            for (int k = 0; k < posZ.Count; k++)
            {
                var cash = Instantiate(enemiesCash[0], new Vector3(Random.Range(-2, 2), 0, posZ[k]), enemiesCash[0].transform.rotation);
                GameObject parent = cash.transform.GetChild(0).gameObject;
                for (int j = 0; j < 5; j++)
                {
                    parent = parent.transform.GetChild(0).gameObject;
                }
                parent.GetComponent<EnemyStateManager>().needKillBullet *= (GameEnd.end.levelNumber + 1);
                parent.GetComponent<EnemyStateManager>().needKillBulletText.text = "" + parent.GetComponent<EnemyStateManager>().needKillBullet;
            }
        }
        attack = (int)Mathf.Round(parent.GetComponent<EnemyStateManager>().needKillBullet / 4) + 1;
        needKillCount = (int)Mathf.Round(parent.GetComponent<EnemyStateManager>().needKillBullet);
    }
}
