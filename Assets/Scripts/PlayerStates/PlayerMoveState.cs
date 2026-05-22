using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveState : PlayerBaseState
{
    private GunProperties cachedGunProperties;

    public override void EnterState(PlayerStateManager player)
    {
        SpawnUpgrade.upgrade.NewRateFire();
        if (FirstGunSpawn.first != null && FirstGunSpawn.first.firstGunObj != null)
        {
            cachedGunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
        }
        
        if (cachedGunProperties != null && player.levelText != null)
        {
            player.levelText.text = "Level " + cachedGunProperties.playerLevel;
        }
    }

    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {

    }

    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {
        player.SwitchState(player.SpawnState);
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
            if (Collect.collect != null && Collect.collect.isStart)
            {
                player.moveSpeed = cachedGunProperties.moveSpeed;
                player.player.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
            }
        }
    }
}
