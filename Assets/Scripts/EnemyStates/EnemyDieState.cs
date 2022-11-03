using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log(enemy.gameObject.transform.parent.gameObject);
        GameObject parent = enemy.gameObject.transform.parent.gameObject;
        for (int i = 0; i < 7; i++)
        {
            parent = parent.transform.parent.gameObject;
        }

        //GameObject parent = enemy.gameObject.transform.parent.gameObject;

        //GameObject enemySoldier = parent.transform.parent.gameObject;

        if (enemy.gameObject.layer == 14)
        {
            enemy.gameObject.layer = 12;
        }
        parent.layer = 0;
        enemy.gameObject.transform.parent = null;
        enemy.gameObject.transform.localScale = new Vector3(1, 1, 1);

        //enemy.GetComponent<BoxCollider>().isTrigger = false;
        //enemy.GetComponent<Rigidbody>().useGravity = true;
        //enemy.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);

        enemy.CancelInvoke();
        enemy.enemyAnim.SetBool("Die", true);

        Object.Destroy(parent.GetComponent<Rigidbody>());
        Object.Destroy(parent.GetComponent<CapsuleCollider>());
        Object.Destroy(enemy.enemySpawn);
        Object.Destroy(parent, 2);
        Object.Destroy(parent.transform.GetChild(2).gameObject, 0.1f);

        PlayerStateManager playerState = Object.FindObjectOfType<PlayerStateManager>();
        SpawnPlayerBullet spawn = Object.FindObjectOfType<SpawnPlayerBullet>();

        spawn.CancelInvoke();
        playerState.currentState = playerState.MoveState;
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
