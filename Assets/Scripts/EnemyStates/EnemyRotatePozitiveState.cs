using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotatePozitiveState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {

    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider other)
    {

    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider other)
    {

    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        Rotate(enemy, enemy.rotate);
        if (enemy.transform.localEulerAngles.y > 240)
        {
            enemy.SwitchState(enemy.RotateNegativeState);
        }
    }
    void Rotate(EnemyStateManager enemy, int rotate)
    {
        switch (rotate)
        {
            case 0:
                enemy.transform.Rotate(0, Time.deltaTime * 10, 0);
                break;
            case 1:
                enemy.transform.Rotate(0, 0, Time.deltaTime * 10);
                break;
            default:
                break;
        }
    }
}
