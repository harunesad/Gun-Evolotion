using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnState : EnemyBaseState
{
    SpawnEnemyBullet spawn;

    public override void EnterState(EnemyStateManager enemy)
    {
        spawn = enemy.GetComponent<SpawnEnemyBullet>();
        if (spawn != null)
        {
            spawn.InvokeRepeating("SpawnObjects", 0, enemy.spawnSpeed);
        }
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider other)
    {
        spawn.CancelInvoke();
        enemy.SwitchState(enemy.IdleState);
    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider other)
    {

    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (enemy.needKillBullet == 0)
        {
            enemy.SwitchState(enemy.DieState);
            spawn.CancelInvoke();
        }
    }
}
