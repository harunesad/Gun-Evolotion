using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAttack : MonoBehaviour
{
    public float bulletSpeed;
    public float attack;
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * bulletSpeed);
        Destroy(gameObject, 0.75f);
    }
    private void OnTriggerEnter(Collider other)
    {
        //float lifeBarFillAmount = FindObjectOfType<PlayerStateManager>().lifeBar.fillAmount;
        //Debug.Log(FindObjectOfType<PlayerStateManager>().lifeBar.fillAmount);
        //lifeBarFillAmount -= attack / 10;
        //if (lifeBarFillAmount >= 0)
        //{
        //    FindObjectOfType<PlayerStateManager>().lifeBar.fillAmount = lifeBarFillAmount;
        //}
        //else
        //{
        //    FindObjectOfType<PlayerStateManager>().lifeBar.fillAmount = 0;
        //}
        int playerLevel = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().playerLevel;
        Debug.Log(FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().playerLevel);
        playerLevel -= (int)attack;
        if (playerLevel >= 0)
        {
            FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().playerLevel = playerLevel;
            FindObjectOfType<PlayerStateManager>().levelText.text = "Level " + playerLevel;
        }
        else
        {
            FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().playerLevel = 0;
            FindObjectOfType<PlayerStateManager>().levelText.text = "Level " + playerLevel;
        }
        Destroy(gameObject);
    }
}
