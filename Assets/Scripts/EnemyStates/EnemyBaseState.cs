using UnityEngine;
public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager enemy);
    public abstract void UpdateState(EnemyStateManager enemy);
    public abstract void OnTriggerStay(EnemyStateManager enemy, Collider other);
    public abstract void OnTriggerExit(EnemyStateManager enemy, Collider other);
}
