using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        SpawnUpgrade.upgrade.NewRateFire();
        player.levelText.text = "Level " + player.firstGun.firstGunObj.GetComponent<GunProperties>().playerLevel;
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
        if (FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().playerLevel == 0)
        {
            player.SwitchState(player.DieState);
        }
        if (Collect.collect.isStart)
        {
            player.moveSpeed = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().moveSpeed;
            player.player.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
        }
    }
}
