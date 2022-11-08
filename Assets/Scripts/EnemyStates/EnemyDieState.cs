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
        //Debug.Log(enemy.gameObject.transform.parent.gameObject);
        //GameObject parent = enemy.gameObject.transform.parent.gameObject;
        //for (int i = 0; i < 7; i++)
        //{
        //    parent = parent.transform.parent.gameObject;
        //}

        //GameObject parent = enemy.gameObject.transform.parent.gameObject;

        //GameObject enemySoldier = parent.transform.parent.gameObject;
        if (enemy.gameObject.layer == 14)
        {
            enemy.gameObject.layer = 12;
        }
        if (enemy.gameObject.transform.position.z > 2)
        {
            gameEnd.progress++;
            gameEnd.endGameBarProgress.DOFillAmount(gameEnd.progress / gameEnd.count, 1);
        }
        enemy.parent.layer = 0;
        enemy.gameObject.transform.parent = null;
        enemy.gameObject.transform.localScale = new Vector3(2, 2, 2);

        //enemy.GetComponent<BoxCollider>().isTrigger = false;
        //enemy.GetComponent<Rigidbody>().useGravity = true;
        //enemy.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);

        enemy.CancelInvoke();
        enemy.enemyAnim.SetBool("Die", true);

        Object.Destroy(enemy.parent.GetComponent<Rigidbody>());
        Object.Destroy(enemy.parent.GetComponent<CapsuleCollider>());
        Object.Destroy(enemy.enemySpawn);
        Object.Destroy(enemy.parent, 2);
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
        //Object.Destroy(enemy.gameObject.GetComponent<EnemyStateManager>());
        //Debug.Log("saddsasda");
        //Time.timeScale = 0;
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
