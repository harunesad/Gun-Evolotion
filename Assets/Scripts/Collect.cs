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
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 12 && other.GetComponent<EnemyStateManager>().needKillBullet == 0)
        {
            for (int i = 0; i < FirstGunSpawn.first.guns.Count; i++)
            {
                if (other.name == FirstGunSpawn.first.guns[i].name)
                {
                    collectedGuns = FirstGunSpawn.first.guns[i];
                }
            }
            //SpawnPlayerBullet spawnPlayer = FindObjectOfType<SpawnPlayerBullet>();
            //GameObject spawnPoint = spawnPlayer.transform.parent.gameObject;
            //Destroy(FindObjectOfType<PlayerStateManager>().gameObject);
            //Destroy(spawnPlayer);
            //spawnPlayer.gameObject.SetActive(false);
            FirstGunSpawn.first.firstGunObj.SetActive(false);
            collectedGuns.gameObject.SetActive(true);
            FirstGunSpawn.first.firstGunObj = collectedGuns;
            //var gun = Instantiate(collectedGuns, spawnPoint.transform.position, Quaternion.identity);
            //gun.transform.parent = spawnPoint.transform;
            FirstGunSpawn.first.NewDistance();
            SpawnUpgrade.upgrade.NewRateFire();
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == 13 && other.GetComponent<EnemyStateManager>().needKillBullet == 0)
        {
            cash += cashInc;
            PlayerPrefs.SetInt("Cash", cash);
            cash = PlayerPrefs.GetInt("Cash");
            cashText.text = "" + PlayerPrefs.GetInt("Cash") +" $";
            Destroy(other.gameObject);
        }
    }    
}
