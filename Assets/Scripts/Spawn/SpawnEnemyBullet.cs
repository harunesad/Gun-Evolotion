using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBullet : MonoBehaviour
{
    public PlayerStateManager playerStateManager;
    public GameObject spawnBullet;
    public Transform spawnPoint;
    private void Start()
    {
        spawnPoint = gameObject.transform.GetChild(0);
        playerStateManager = FindObjectOfType<PlayerStateManager>();
    }
    public void SpawnObjects()
    {
        if (playerStateManager != null)
        {
            Instantiate(spawnBullet, spawnPoint.position, Quaternion.identity);
        }
    }
}
