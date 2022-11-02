using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerBullet : MonoBehaviour
{
    public PlayerStateManager stateManager;
    public GameObject spawnBullet;
    public Transform spawnPoint;
    public int bulletCount;
    int repeatBullet;
    public float currentProgress;
    public float nextProgress;
    private void Start()
    {
        spawnPoint = gameObject.transform.parent;
        spawnPoint = gameObject.transform.GetChild(0);
    }

    public void SpawnObjects()
    {
        if (stateManager != null)
        {
            repeatBullet = bulletCount;
            Instantiate(spawnBullet, spawnPoint.position, Quaternion.identity);
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        if (bulletCount > 0)
        {
            yield return new WaitForSeconds(0.075f);
            Instantiate(spawnBullet, spawnPoint.position, Quaternion.identity);
            bulletCount--;
            StartCoroutine(Attack());
        }
        else
        {
            bulletCount = repeatBullet;
        }
    }
}
