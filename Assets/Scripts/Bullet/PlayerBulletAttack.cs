using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerBulletAttack : MonoBehaviour
{
    public float bulletSpeed;
    public float spawnSpeed;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        Destroy(gameObject, 0.75f);
    }
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.GetChild(0).gameObject.transform;
        GameObject triggerObj = parent.GetChild(0).gameObject;
        int needKillCount = triggerObj.GetComponent<EnemyStateManager>().needKillBullet;
        TextMeshProUGUI needKillText = triggerObj.GetComponent<EnemyStateManager>().needKillBulletText;
        needKillCount--;
        needKillText.text = "" + needKillCount;
        triggerObj.GetComponent<EnemyStateManager>().needKillBullet = needKillCount;
        triggerObj.GetComponent<EnemyStateManager>().needKillBulletText = needKillText;
        Vector3 scale = new Vector3(other.transform.localScale.x, other.transform.localScale.y, other.transform.localScale.z);
        other.transform.DOScale(scale * 1.1f, 0.1f).OnComplete(() => 
        {
            other.transform.DOScale(scale, 0.1f);
            });
        Debug.Log(scale * 2);
        Destroy(gameObject);
    }
}
