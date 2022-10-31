using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        //enemy.needKillBullet *= (GameEnd.end.levelNumber + 1);
        enemy.needKillBulletText.text = "" + enemy.needKillBullet;
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider other)
    {

    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider other)
    {
        enemy.SwitchState(enemy.SpawnState);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (enemy.needKillBullet == 0)
        {
            enemy.SwitchState(enemy.DieState);
        }
    }
}
