using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnState : PlayerBaseState
{
    SpawnPlayerBullet spawn;

    public override void EnterState(PlayerStateManager player)
    {
        spawn = GameObject.FindObjectOfType<SpawnPlayerBullet>();
        spawn.InvokeRepeating("SpawnObjects", 0, player.spawnSpeed);
    }

    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        spawn.CancelInvoke();
        player.SwitchState(player.MoveState);
    }

    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().playerLevel == 0)
        {
            player.SwitchState(player.DieState);
        }
        player.moveSpeed = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().moveSpeed;
        player.player.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
    }
}
