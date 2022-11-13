using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyDieState : EnemyBaseState
{
    GameEndSpawn gameEnd;
    public override void EnterState(EnemyStateManager enemy)
    {
        gameEnd = GameObject.FindObjectOfType<GameEndSpawn>();
        if (enemy.gameObject.layer == 14)
        {
            enemy.gameObject.layer = 12;
        }
        if (enemy.gameObject.transform.position.z > 125)
        {
            gameEnd.progress++;
            gameEnd.endGameBarProgress.DOFillAmount(gameEnd.progress / gameEnd.count, 1);
        }
        enemy.parent.layer = 0;
        enemy.gameObject.transform.parent = null;
        enemy.gameObject.transform.localScale = new Vector3(4, 4, 4);

        enemy.CancelInvoke();
        enemy.enemyAnim.SetBool("Die", true);

        Object.Destroy(enemy.parent.GetComponent<Rigidbody>());
        Object.Destroy(enemy.parent.GetComponent<CapsuleCollider>());
        Object.Destroy(enemy.enemySpawn);
        Object.Destroy(enemy.parent, 2);
        Object.Destroy(enemy.levelText);
        Object.Destroy(enemy.needKillBulletText);
        Object.Destroy(enemy.parent.transform.GetChild(2).gameObject, 0.1f);

        PlayerStateManager playerState = Object.FindObjectOfType<PlayerStateManager>();
        SpawnPlayerBullet spawn = Object.FindObjectOfType<SpawnPlayerBullet>();
        if (spawn != null)
        {
            spawn.CancelInvoke();
            playerState.currentState = playerState.MoveState;
        }
        enemy.transform.localEulerAngles = new Vector3(enemy.rotX, 180, 0);
        enemy.SwitchState(enemy.RotatePozitiveState);
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider other)
    {
        
    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider other)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }
}
