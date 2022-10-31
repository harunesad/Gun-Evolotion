using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndSpawn : MonoBehaviour
{
    public GameObject enemyCash;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            var cashLeft = Instantiate(enemyCash, new Vector3(-2.5f, 0.5f, 2 * i + 5), Quaternion.identity);
            var cashMiddle = Instantiate(enemyCash, new Vector3(0, 0.5f, 2 * i + 5), Quaternion.identity);
            var cashRight = Instantiate(enemyCash, new Vector3(2.5f, 0.5f, 2 * i + 5), Quaternion.identity);

            TextUpgrade(cashLeft, i);
            TextUpgrade(cashMiddle, i);
            TextUpgrade(cashRight, i);

            cashLeft.name = enemyCash.name;
            cashMiddle.name = enemyCash.name;
            cashRight.name = enemyCash.name;
        }
    }
    void TextUpgrade(GameObject obj, int i)
    {
        GameObject parent = obj.transform.GetChild(0).gameObject;
        GameObject cash = parent.transform.GetChild(0).gameObject;
        int needKillCount = cash.GetComponent<EnemyStateManager>().needKillBullet;
        needKillCount = i * 5 + 3 * (GameEnd.end.levelNumber + 1);
        cash.GetComponent<EnemyStateManager>().needKillBullet = needKillCount;
        cash.GetComponent<EnemyStateManager>().needKillBulletText.text = "" + needKillCount;
    }
    void Update()
    {
        
    }
}
