using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        GameObject parent = enemy.gameObject.transform.parent.gameObject;
        GameObject enemySoldier = parent.transform.parent.gameObject;

        if (enemy.gameObject.layer == 9)
        {
            enemy.gameObject.layer = 12;
        }
        enemy.gameObject.transform.parent = null;
        enemy.gameObject.transform.localScale = new Vector3(1, 1, 1);

        enemy.GetComponent<BoxCollider>().isTrigger = false;
        enemy.GetComponent<Rigidbody>().useGravity = true;
        enemy.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);

        Object.Destroy(enemy.gameObject.GetComponent<EnemyStateManager>());
        Object.Destroy(enemySoldier);

        PlayerStateManager playerState = Object.FindObjectOfType<PlayerStateManager>();
        SpawnPlayerBullet spawn = Object.FindObjectOfType<SpawnPlayerBullet>();

        spawn.CancelInvoke();
        playerState.currentState = playerState.MoveState;
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
