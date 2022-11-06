using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyStateManager stateManager;
    public SpawnEnemyBullet spawn;
    private void OnTriggerEnter(Collider other)
    {
        stateManager.SwitchState(stateManager.SpawnState);
    }
    private void OnTriggerExit(Collider other)
    {
        spawn.CancelInvoke();
        stateManager.SwitchState(stateManager.IdleState);
    }
}
