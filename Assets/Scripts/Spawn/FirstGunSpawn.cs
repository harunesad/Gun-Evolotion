using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class FirstGunSpawn : MonoBehaviour
{
    public static FirstGunSpawn first;
    public List<GameObject> guns;
    public List<Sprite> gunSprites;
    public List<Material> materials;
    public Image gunBar;
    public Image gunBarBlack;
    public TextMeshProUGUI percentText;
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

        NewDistance();
        current = (SpawnUpgrade.upgrade.so.progressId[startIndex + 1] - 1) * 10;
        next = SpawnUpgrade.upgrade.so.progressId[startIndex + 1] * 10;
        gunBar.fillAmount = current / 100;
        RenderSettings.skybox = materials[Mathf.FloorToInt((startIndex + 1) / 7)];
    }
    public void NewDistance()
    {
        stateCol.size = new Vector3(stateCol.size.x, stateCol.size.y, firstGunObj.GetComponent<GunProperties>().range);
        stateCol.center = new Vector3(stateCol.center.x, stateCol.center.y, stateCol.size.z / 2);
    }
    public void ProgressBar()
    {
        gunBarBlack.sprite = gunSprites[startIndex];
        gunBar.sprite = gunSprites[startIndex];
        gunBar.DOFillAmount(next / 100, 0.4f);
        percentText.text = "% " + next;
        SpawnUpgrade.upgrade.so.progressId[startIndex + 1] += 1;
        next = SpawnUpgrade.upgrade.so.progressId[startIndex + 1] * 10;
        if (next == 100)
        {
            startIndex++;
            PlayerPrefs.SetInt("FirstGun", startIndex);
        }
        SaveManager.Save(SpawnUpgrade.upgrade.so);
    }
}
