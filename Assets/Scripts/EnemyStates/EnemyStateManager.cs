using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyStateManager : MonoBehaviour
{
    //public float bulletSpeed;
    public GameObject parent;
    public float spawnSpeed;
    public int needKillBullet;
    public TextMeshProUGUI needKillBulletText;
    public TextMeshProUGUI levelText;
    public Animator enemyAnim;
    public EnemySpawn enemySpawn;
    public float rotX;
    public int rotate;
    public int enemyLevel;
    //public int startLevel;

    EnemyBaseState currentState;
    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemySpawnState SpawnState = new EnemySpawnState();
    public EnemyDieState DieState = new EnemyDieState();
    public EnemyRotateNegativeState RotateNegativeState = new EnemyRotateNegativeState();
    public EnemyRotatePozitiveState RotatePozitiveState = new EnemyRotatePozitiveState();
    void Start()
    {
        //needKillBullet *= (GameEnd.end.levelNumber + 1);
        currentState = IdleState;
        currentState.EnterState(this);
    }
    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(this, other);
    }
    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(this, other);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
