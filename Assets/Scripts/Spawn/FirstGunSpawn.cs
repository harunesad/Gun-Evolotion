using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class FirstGunSpawn : MonoBehaviour
{
    public static FirstGunSpawn first;
    //SpawnPlayerBullet playerBullet;
    public List<GameObject> guns;
    public List<Sprite> gunSprites;
    public List<Material> materials;
    public Image gunBar;
    public GameObject spawnPoint;
    public GameObject firstGunObj;
    public int startIndex;
    public BoxCollider stateCol;
    float current;
    float next;
    private void Awake()
    {
        first = this;
    }
    void Start()
    {
        SpawnUpgrade.upgrade.so = SaveManager.Load();
        startIndex = PlayerPrefs.GetInt("FirstGun");
        guns[startIndex].gameObject.SetActive(true);
        firstGunObj = guns[startIndex];
        Debug.Log(startIndex);

        NewDistance();
        //playerBullet = firstGunObj.GetComponent<SpawnPlayerBullet>();
        current = (SpawnUpgrade.upgrade.so.progressId[startIndex + 1] - 1) * 10;
        next = SpawnUpgrade.upgrade.so.progressId[startIndex + 1] * 10;
        Debug.Log(next);
        gunBar.fillAmount = current / 100;
        //RenderSettings.skybox = materials[(int)Mathf.Round((startIndex + 1) / 5)];
    }
    public void NewDistance()
    {
        stateCol.size = new Vector3(stateCol.size.x, stateCol.size.y, firstGunObj.GetComponent<GunProperties>().range);
        stateCol.center = new Vector3(stateCol.center.x, stateCol.center.y, stateCol.size.z / 2);
    }
    public void ProgressBar()
    {
        gunBar.sprite = gunSprites[startIndex];
        gunBar.DOFillAmount(next / 100, 0.4f);
        SpawnUpgrade.upgrade.so.progressId[startIndex + 1] += 9;
        next = SpawnUpgrade.upgrade.so.progressId[startIndex + 1] * 10;
        Debug.Log(next);
        if (next == 100)
        {
            Debug.Log("sadsa");
            startIndex++;
            Debug.Log(startIndex);
            PlayerPrefs.SetInt("FirstGun", startIndex);
        }
        SaveManager.Save(SpawnUpgrade.upgrade.so);
    }
}
