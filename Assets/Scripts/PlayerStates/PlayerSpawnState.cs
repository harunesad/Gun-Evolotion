using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnState : PlayerBaseState
{
    SpawnPlayerBullet spawn;

    public override void EnterState(PlayerStateManager player)
    {
        //player.spawnSpeed = player.firstGun.firstGunObj.GetComponent<GunProperties>().spawnSpeed;
        spawn = GameObject.FindObjectOfType<SpawnPlayerBullet>();
        spawn.InvokeRepeating("SpawnObjects", 0, player.spawnSpeed);
    }

    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        Debug.Log("sad");
        spawn.CancelInvoke();
        player.SwitchState(player.MoveState);
    }

    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.lifeBar.fillAmount == 0)
        {
            player.SwitchState(player.DieState);
        }
        //GameObject parent = player.transform.parent.gameObject;
        //GameObject playerObj = parent.transform.parent.gameObject;
        //playerObj.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
        player.moveSpeed = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().moveSpeed;
        player.player.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
    }
}
