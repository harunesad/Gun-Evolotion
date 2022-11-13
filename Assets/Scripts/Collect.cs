using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Collect : MonoBehaviour
{
    public static Collect collect;
    public GameObject collectedGuns;
    public GameObject startPanel;
    public TextMeshProUGUI cashText;
    public Animator playerAnim;
    public int cash;
    public int cashInc;
    public bool isStart;
    private void Awake()
    {
        collect = this;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("CashInc"))
        {
            cashInc = PlayerPrefs.GetInt("CashInc");
        }
        if (PlayerPrefs.HasKey("Cash"))
        {
            cash = PlayerPrefs.GetInt("Cash");
            cashText.text = "" + cash + " $";
        }
        else
        {
            PlayerPrefs.SetInt("Cash", cash);
            cashText.text = "" + cash + " $";
        }
    }
    public void StartGame()
    {
        startPanel.gameObject.SetActive(false);
        isStart = true;
        playerAnim.SetBool("Run", true);
    }
    public void EndGame()
    {
        playerAnim.SetBool("Run", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyStateManager enemyStateManager = other.GetComponent<EnemyStateManager>();
        PlayerStateManager playerStateManager = FindObjectOfType<PlayerStateManager>();
        if(other.gameObject.layer == 12 && enemyStateManager.needKillBullet == 0 && playerStateManager != null)
        {
            for (int i = 0; i < FirstGunSpawn.first.guns.Count; i++)
            {
                if (other.name == FirstGunSpawn.first.guns[i].name)
                {
                    collectedGuns = FirstGunSpawn.first.guns[i];
                }
            }
            FirstGunSpawn.first.firstGunObj.SetActive(false);
            collectedGuns.gameObject.SetActive(true);
            FirstGunSpawn.first.firstGunObj = collectedGuns;
            FirstGunSpawn.first.NewDistance();
            SpawnUpgrade.upgrade.NewRateFire();
            playerStateManager.levelText.text = "Level " + collectedGuns.GetComponent<GunProperties>().playerLevel;
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == 13 && enemyStateManager.needKillBullet == 0 && playerStateManager != null)
        {
            cash += cashInc;
            PlayerPrefs.SetInt("Cash", cash);
            cash = PlayerPrefs.GetInt("Cash");
            cashText.text = "" + PlayerPrefs.GetInt("Cash") +" $";
            Destroy(other.gameObject);
        }
    }    
}
