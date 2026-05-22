using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerBulletAttack : MonoBehaviour
{
    public float bulletSpeed;
    public int attack;
    Transform parent;
    private void Start()
    {
        attack = EnemiesSpawn.enemiesSpawn.attack;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        Destroy(gameObject, 0.75f);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyStateManager enemyState = other.GetComponentInChildren<EnemyStateManager>();
        if (enemyState == null)
        {
            enemyState = other.GetComponentInParent<EnemyStateManager>();
        }

        if (enemyState != null)
        {
            int needKillCount = enemyState.needKillBullet;
            needKillCount -= attack;
            
            if (needKillCount >= 0)
            {
                enemyState.needKillBullet = needKillCount;
            }
            else
            {
                enemyState.needKillBullet = 0;
            }

            if (enemyState.needKillBulletText != null)
            {
                enemyState.needKillBulletText.text = "" + enemyState.needKillBullet;
            }

            Vector3 scale = other.transform.localScale;
            other.transform.DOScale(scale * 1.05f, 0.1f).OnComplete(() => 
            {
                if (other != null)
                {
                    other.transform.DOScale(scale, 0.1f);
                }
            });
        }
        Destroy(gameObject);
    }
}
