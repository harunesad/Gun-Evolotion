using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnState : PlayerBaseState
{
    SpawnPlayerBullet spawn;
    private GunProperties cachedGunProperties;

    public override void EnterState(PlayerStateManager player)
    {
        spawn = GameObject.FindObjectOfType<SpawnPlayerBullet>();
        if (spawn != null)
        {
            spawn.InvokeRepeating("SpawnObjects", 0, player.spawnSpeed);
        }
        if (FirstGunSpawn.first != null && FirstGunSpawn.first.firstGunObj != null)
        {
            cachedGunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
        }
    }

    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        if (spawn != null)
        {
            spawn.CancelInvoke("SpawnObjects");
        }
        player.SwitchState(player.MoveState);
    }

    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (cachedGunProperties == null || (FirstGunSpawn.first != null && FirstGunSpawn.first.firstGunObj != null && cachedGunProperties.gameObject != FirstGunSpawn.first.firstGunObj))
        {
            if (FirstGunSpawn.first != null && FirstGunSpawn.first.firstGunObj != null)
            {
                cachedGunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
            }
        }

        if (cachedGunProperties != null)
        {
            if (cachedGunProperties.playerLevel == 0)
            {
                player.SwitchState(player.DieState);
                return;
            }
            player.moveSpeed = cachedGunProperties.moveSpeed;
            player.player.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
        }
    }
}
