using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.CancelInvoke();
        GameEnd.end.GameOver();
    }

    public override void OnTriggerExit(PlayerStateManager player, Collider other)
    {
        
    }

    public override void OnTriggerStay(PlayerStateManager player, Collider other)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }
}
