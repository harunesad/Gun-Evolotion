using UnityEngine;
public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void OnTriggerStay(PlayerStateManager player, Collider other);
    public abstract void OnTriggerExit(PlayerStateManager player, Collider other);
}
