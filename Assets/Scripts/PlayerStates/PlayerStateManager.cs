using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    public float moveSpeed;
    public float spawnSpeed;
    public int rangeCost;
    public float rangeLevel;
    public int rateFireCost;
    public float rateFireLevel;
    public Image lifeBar;
    public GameObject player;
    public FirstGunSpawn firstGun;

    public PlayerBaseState currentState;
    public PlayerMoveState MoveState = new PlayerMoveState();
    public PlayerSpawnState SpawnState = new PlayerSpawnState();
    public PlayerDieState DieState = new PlayerDieState();
    void Start()
    {
        currentState = MoveState;
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
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
