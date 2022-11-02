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
        //enemy.transform.Rotate(0, 0, Time.deltaTime * 10);
        Rotate(enemy, enemy.rotate);
        //Debug.Log(enemy.transform.localEulerAngles);
        //enemy.transform.rotation = Quaternion.Euler(0, enemy.transform.rotation.y, 0);
        if (enemy.transform.localEulerAngles.y > 240)
        {
            enemy.SwitchState(enemy.RotateNegativeState);
            Debug.Log("sada");
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
