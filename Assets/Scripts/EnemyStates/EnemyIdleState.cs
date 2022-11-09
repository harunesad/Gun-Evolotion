using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.needKillBullet *= (GameEnd.end.levelNumber + 1);
        //enemy.startLevel = enemy.enemyLevel;
        GameObject canvas = enemy.needKillBulletText.transform.parent.gameObject;
        if (enemy.gameObject.layer == 14)
        {
            canvas.GetComponent<RectTransform>().localPosition = new Vector3(0, 1.25f, 0);
            enemy.needKillBulletText.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 100);
            enemy.needKillBulletText.fontSize = 100;
            enemy.needKillBulletText.color = Color.green;
            enemy.levelText.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 100);
            enemy.levelText.fontSize = 100;
            enemy.levelText.color = Color.black;
            enemy.levelText.text = "Level " + enemy.enemyLevel;
            enemy.needKillBulletText.text = "" + enemy.needKillBullet;
        }
        if (enemy.gameObject.layer == 13)
        {
            canvas.GetComponent<RectTransform>().localPosition = new Vector3(0f, 1f, 0f);
            enemy.needKillBulletText.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 100);
            enemy.needKillBulletText.fontSize = 100;
            enemy.needKillBulletText.color = Color.green;
            enemy.needKillBulletText.text = "" + enemy.needKillBullet;
        }
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider other)
    {

    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider other)
    {
        //enemy.SwitchState(enemy.SpawnState);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (enemy.needKillBullet == 0)
        {
            enemy.SwitchState(enemy.DieState);
        }
    }
}
