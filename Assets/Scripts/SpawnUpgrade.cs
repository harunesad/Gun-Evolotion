using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnUpgrade : MonoBehaviour
{
    public static SpawnUpgrade upgrade;
    public SaveObject so;
    public CashBuy cash;
    GunProperties gunProperties;
    public TextMeshProUGUI cashCostText;
    public TextMeshProUGUI cashlevelText;
    public TextMeshProUGUI rangeCostText;
    public TextMeshProUGUI rangeLevelText;
    public TextMeshProUGUI rateFireCostText;
    public TextMeshProUGUI rateFireLevelText;
    private void Awake()
    {
        upgrade = this;
    }
    void Start()
    {
        so = SaveManager.Load();

        //playerState = FirstGunSpawn.first.guns[FirstGunSpawn.first.startIndex].GetComponent<PlayerStateManager>();
        gunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
        cashCostText.text = "" + so.cashId * 10;
        cashlevelText.text = "" + so.cashId;
        rangeCostText.text = "" + so.rangeId[FirstGunSpawn.first.startIndex] * 10;
        rangeLevelText.text = "" + so.rangeId[FirstGunSpawn.first.startIndex];
        rateFireCostText.text = "" + so.rateFireId[FirstGunSpawn.first.startIndex] * 10;
        rateFireLevelText.text = "" + so.rateFireId[FirstGunSpawn.first.startIndex];
        NewRateFire();
        //BoxCollider firstGun = FindObjectOfType<PlayerStateManager>().GetComponent<BoxCollider>();
        //firstGun.size = new Vector3(firstGun.size.x, firstGun.size.y, firstGun.size.z + ((so.rangeId[FirstGunSpawn.first.startIndex] - 1) / 10f));
        FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().range += ((so.rangeId[FirstGunSpawn.first.startIndex] - 1) / 10f);
    }
    public void NewRateFire()
    {
        gunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
        gunProperties.spawnSpeed /= Mathf.Pow(1.1f, so.rateFireId[FirstGunSpawn.first.startIndex] - 1);
        PlayerStateManager playerState = FindObjectOfType<PlayerStateManager>();
        playerState.spawnSpeed = gunProperties.spawnSpeed;
    }
    public void BuyCash()
    {
        if (Collect.collect.cash >= cash.cashCost)
        {
            Collect.collect.cash -= cash.cashCost;
            PlayerPrefs.SetInt("Cash", Collect.collect.cash);
            Collect.collect.cashText.text = "" + PlayerPrefs.GetInt("Cash");
            so.cashId++;
            cash.cashLevel = so.cashId;
            cashlevelText.text = "" + cash.cashLevel;
            cash.cashCost = so.cashId * 10;
            cashCostText.text = "" + cash.cashCost;
            Collect.collect.cashInc += 1;
            PlayerPrefs.SetInt("CashInc", Collect.collect.cashInc);
            SaveManager.Save(so);
            Collect.collect.StartGame();
        }
    }
    public void BuyRange()
    {
        if (Collect.collect.cash >= gunProperties.rangeCost)
        {
            Collect.collect.cash -= gunProperties.rangeCost;
            PlayerPrefs.SetInt("Cash", Collect.collect.cash);
            Collect.collect.cashText.text = "" + PlayerPrefs.GetInt("Cash");
            BoxCollider firstGun = FindObjectOfType<PlayerStateManager>().GetComponent<BoxCollider>();
            firstGun.size = new Vector3(firstGun.size.x, firstGun.size.y, firstGun.size.z + (so.rangeId[FirstGunSpawn.first.startIndex] / 10f));
            so.rangeId[FirstGunSpawn.first.startIndex]++;
            gunProperties.rangeLevel = so.rangeId[FirstGunSpawn.first.startIndex];
            rangeLevelText.text = "" + gunProperties.rangeLevel;
            gunProperties.rangeCost = so.rangeId[FirstGunSpawn.first.startIndex] * 10;
            rangeCostText.text = "" + gunProperties.rangeCost;
            SaveManager.Save(so);
            Collect.collect.StartGame();
        }
    }
    public void BuyRateFire()
    {
        if (Collect.collect.cash >= gunProperties.rateFireCost)
        {
            Collect.collect.cash -= gunProperties.rateFireCost;
            PlayerPrefs.SetInt("Cash", Collect.collect.cash);
            Collect.collect.cashText.text = "" + PlayerPrefs.GetInt("Cash");
            gunProperties.spawnSpeed /= Mathf.Pow(1.1f, so.rateFireId[FirstGunSpawn.first.startIndex]);
            so.rateFireId[FirstGunSpawn.first.startIndex]++;
            gunProperties.rateFireLevel = so.rateFireId[FirstGunSpawn.first.startIndex];
            rateFireLevelText.text = "" + gunProperties.rateFireLevel;
            gunProperties.rateFireCost = so.rateFireId[FirstGunSpawn.first.startIndex] * 10;
            rateFireCostText.text = "" + gunProperties.rateFireCost;
            SaveManager.Save(so);
            Collect.collect.StartGame();
        }
    }
}
