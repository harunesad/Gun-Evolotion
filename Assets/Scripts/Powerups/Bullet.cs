using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bullet : MonoBehaviour
{
    public static Bullet bullet;
    public int bulletCount;
    public int newBulletCount = 1;
    [SerializeField] string result;
    private void Awake()
    {
        bullet = this;
    }
    void Start()
    {
        GameObject canvas = gameObject.transform.GetChild(0).gameObject;
        TextMeshProUGUI distanceText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        distanceText.text = result;
        if (result == "+")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.2f, 0.9f, 0.2f, 0.4f);
        }
        if(result == "-")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.9f, 0.2f, 0.2f, 0.4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //bulletCount++;
        SpawnPlayerBullet spawnBullet = FirstGunSpawn.first.firstGunObj.GetComponent<SpawnPlayerBullet>();
        if (result == "-" && spawnBullet.bulletCount > 0)
        {
            spawnBullet.bulletCount--;
            bulletCount = spawnBullet.bulletCount;
        }
        else if (result == "-" && spawnBullet.bulletCount == 0)
        {
            bulletCount = 0;
        }
        newBulletCount = bulletCount;
        spawnBullet.bulletCount = newBulletCount;
    }
}
