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
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        Destroy(gameObject, 0.75f);
    }
    private void OnTriggerEnter(Collider other)
    {
        parent = other.transform.GetChild(0);
        for (int i = 0; i < 7; i++)
        {
            if (parent.GetComponent<EnemyStateManager>() == null)
            {
                parent = parent.transform.GetChild(0);
            }
        }
        Debug.Log(parent.name);
        //GameObject triggerObj = parent.GetChild(0).gameObject;
        int needKillCount = parent.GetComponent<EnemyStateManager>().needKillBullet;
        TextMeshProUGUI needKillText = parent.GetComponent<EnemyStateManager>().needKillBulletText;
        needKillCount -= attack;
        needKillText.text = "" + needKillCount;
        if (needKillCount >= 0)
        {
            parent.GetComponent<EnemyStateManager>().needKillBullet = needKillCount;
            parent.GetComponent<EnemyStateManager>().needKillBulletText = needKillText;
        }
        else
        {
            parent.GetComponent<EnemyStateManager>().needKillBullet = 0;
            parent.GetComponent<EnemyStateManager>().needKillBulletText.text = "0";
        }
        Vector3 scale = new Vector3(other.transform.localScale.x, other.transform.localScale.y, other.transform.localScale.z);
        other.transform.DOScale(scale * 1.1f, 0.1f).OnComplete(() => 
        {
            other.transform.DOScale(scale, 0.1f);
            });
        Debug.Log(scale * 2);
        Destroy(gameObject);
    }
}
