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
        //player.lifeBar = GameObject.Find("LifeBar").GetComponent<Image>();
        //BoxCollider playerCol = player.gameObject.GetComponent<BoxCollider>();

        //playerCol.size = new Vector3(playerCol.size.x, playerCol.size.y, player.firstGun.firstGunObj.GetComponent<GunProperties>().range);
        //playerCol.center = new Vector3(playerCol.center.x, playerCol.center.y, playerCol.size.z / 2);
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
        //if (player.lifeBar.fillAmount == 0)
        //{
        //    player.SwitchState(player.DieState);
        //}
        if (FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().playerLevel == 0)
        {
            player.SwitchState(player.DieState);
        }
        if (Collect.collect.isStart)
        {
            //GameObject parent = player.transform.parent.gameObject;
            //GameObject playerObj = parent.transform.parent.gameObject;
            //playerObj.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
            player.moveSpeed = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>().moveSpeed;
            player.player.transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed);
        }
    }
}
