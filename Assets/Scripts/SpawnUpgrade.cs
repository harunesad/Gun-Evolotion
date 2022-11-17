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
    PlayerStateManager playerStateManager;
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

        gunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
        playerStateManager = FindObjectOfType<PlayerStateManager>();
        cashCostText.text = "" + so.cashId * 10 + " $";
        cashlevelText.text = "" + so.cashId;
        rangeCostText.text = "" + so.rangeId[FirstGunSpawn.first.startIndex] * 10 + " $";
        rangeLevelText.text = "" + so.rangeId[FirstGunSpawn.first.startIndex];
        rateFireCostText.text = "" + so.rateFireId[FirstGunSpawn.first.startIndex] * 10 + " $";
        rateFireLevelText.text = "" + so.rateFireId[FirstGunSpawn.first.startIndex];
        FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().range += ((so.rangeId[FirstGunSpawn.first.startIndex] - 1) / 10f);
    }
    public void NewRateFire()
    {
        gunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
        gunProperties.spawnSpeed -= (float)(so.rateFireId[FirstGunSpawn.first.startIndex] - 1) / 40;
        PlayerStateManager playerState = FindObjectOfType<PlayerStateManager>();
        playerState.spawnSpeed = gunProperties.spawnSpeed;
    }
    public void BuyCash()
    {
        if (Collect.collect.cash >= cash.cashCost)
        {
            Collect.collect.cash -= cash.cashCost;
            PlayerPrefs.SetInt("Cash", Collect.collect.cash);
            Collect.collect.cashText.text = "" + PlayerPrefs.GetInt("Cash") + " $";
            so.cashId++;
            cash.cashLevel = so.cashId;
            cashlevelText.text = "" + cash.cashLevel;
            cash.cashCost = so.cashId * 10;
            cashCostText.text = "" + cash.cashCost + " $";
            Collect.collect.cashInc += 1;
            PlayerPrefs.SetInt("CashInc", Collect.collect.cashInc);
            SaveManager.Save(so);
        }
    }
    public void BuyRange()
    {
        if (Collect.collect.cash >= gunProperties.rangeCost)
        {
            Collect.collect.cash -= gunProperties.rangeCost;
            PlayerPrefs.SetInt("Cash", Collect.collect.cash);
            Collect.collect.cashText.text = "" + PlayerPrefs.GetInt("Cash") + " $";
            BoxCollider firstGun = FindObjectOfType<PlayerStateManager>().GetComponent<BoxCollider>();
            firstGun.size = new Vector3(firstGun.size.x, firstGun.size.y, firstGun.size.z + (so.rangeId[FirstGunSpawn.first.startIndex] / 10f));
            so.rangeId[FirstGunSpawn.first.startIndex]++;
            gunProperties.rangeLevel = so.rangeId[FirstGunSpawn.first.startIndex];
            rangeLevelText.text = "" + gunProperties.rangeLevel;
            gunProperties.rangeCost = so.rangeId[FirstGunSpawn.first.startIndex] * 10;
            rangeCostText.text = "" + gunProperties.rangeCost + " $";
            SaveManager.Save(so);
        }
    }
    public void BuyRateFire()
    {
        if (Collect.collect.cash >= gunProperties.rateFireCost)
        {
            Collect.collect.cash -= gunProperties.rateFireCost;
            PlayerPrefs.SetInt("Cash", Collect.collect.cash);
            Collect.collect.cashText.text = "" + PlayerPrefs.GetInt("Cash") + " $";
            gunProperties.spawnSpeed -= (float)(so.rateFireId[FirstGunSpawn.first.startIndex]) / 40;
            playerStateManager.spawnSpeed = gunProperties.spawnSpeed;
            so.rateFireId[FirstGunSpawn.first.startIndex]++;
            gunProperties.rateFireLevel = so.rateFireId[FirstGunSpawn.first.startIndex];
            rateFireLevelText.text = "" + gunProperties.rateFireLevel;
            gunProperties.rateFireCost = so.rateFireId[FirstGunSpawn.first.startIndex] * 10;
            rateFireCostText.text = "" + gunProperties.rateFireCost + " $";
            SaveManager.Save(so);
        }
    }
}
