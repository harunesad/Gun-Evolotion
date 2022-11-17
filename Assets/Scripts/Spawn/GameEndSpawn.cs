using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEndSpawn : MonoBehaviour
{
    public static GameEndSpawn instance;
    public float count;
    public float progress;
    public GameObject enemyCash;
    public GameObject player;
    public Image endGameBar;
    public Image endGameBarProgress;
    int needKillCount;
    private void Awake()
    {
        instance = this;
    }
    public void EnemyCashSpawn()
    {
        for (int i = 0; i < 40; i += 2)
        {
            if ((i + 55) == 55)
            {
                var cashLeft = Instantiate(enemyCash, new Vector3(-2.5f, 0.5f, 2 * (i + 55) + 10), enemyCash.transform.rotation);
                var cashMiddle = Instantiate(enemyCash, new Vector3(0, 0.5f, 2 * (i + 55) + 10), enemyCash.transform.rotation);
                var cashRight = Instantiate(enemyCash, new Vector3(2.5f, 0.5f, 2 * (i + 55) + 10), enemyCash.transform.rotation);
                count += 3;
                TextUpgradeFirst(cashLeft, i);
                TextUpgradeFirst(cashMiddle, i);
                TextUpgradeFirst(cashRight, i);

                ScaleInc(cashLeft);
                ScaleInc(cashMiddle);
                ScaleInc(cashRight);

                cashLeft.name = enemyCash.name;
                cashMiddle.name = enemyCash.name;
                cashRight.name = enemyCash.name;
            }
            else
            {
                var cashLeft = Instantiate(enemyCash, new Vector3(-2.5f, 0.5f, 2 * (i + 55) + 17), enemyCash.transform.rotation);
                var cashMiddle = Instantiate(enemyCash, new Vector3(0, 0.5f, 2 * (i + 55) + 17), enemyCash.transform.rotation);
                var cashRight = Instantiate(enemyCash, new Vector3(2.5f, 0.5f, 2 * (i + 55) + 17), enemyCash.transform.rotation);
                count += 3;
                needKillCount += 7 * (i / 2);

                TextUpgrade(cashLeft, i);
                TextUpgrade(cashMiddle, i);
                TextUpgrade(cashRight, i);

                ScaleInc(cashLeft);
                ScaleInc(cashMiddle);
                ScaleInc(cashRight);

                cashLeft.name = enemyCash.name;
                cashMiddle.name = enemyCash.name;
                cashRight.name = enemyCash.name;
            }
        }
    }
    void TextUpgradeFirst(GameObject obj, int i)
    {
        GameObject parent = obj.transform.GetChild(0).gameObject;
        for (int j = 0; j < 5; j++)
        {
             parent = parent.transform.GetChild(0).gameObject;
        }
        needKillCount = parent.GetComponent<EnemyStateManager>().needKillBullet;
        needKillCount = EnemiesSpawn.enemiesSpawn.needKillCount;
        parent.GetComponent<EnemyStateManager>().needKillBullet = needKillCount;
        parent.GetComponent<EnemyStateManager>().needKillBulletText.text = "" + needKillCount;
    }
    void TextUpgrade(GameObject obj, int i)
    {
        GameObject parent = obj.transform.GetChild(0).gameObject;
        for (int j = 0; j < 5; j++)
        {
            parent = parent.transform.GetChild(0).gameObject;
        }
        parent.GetComponent<EnemyStateManager>().needKillBullet = needKillCount;
        parent.GetComponent<EnemyStateManager>().needKillBulletText.text = "" + needKillCount;
    }
    void ScaleInc(GameObject obj)
    {
        obj.transform.localScale = new Vector3(5, 5, 5);
    }
    void Update()
    {
        if (player.transform.position.z > 125 && Collect.collect.isStart == true)
        {
            endGameBar.gameObject.SetActive(true);
        }
    }
}
