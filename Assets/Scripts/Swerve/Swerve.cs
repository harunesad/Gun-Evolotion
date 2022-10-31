using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swerve : MonoBehaviour
{
    SwerveControl swerveControl;
    public float swerveSpeed = 1f;
    public GameObject playerObject;
    private void Awake()
    {
        swerveControl = GetComponent<SwerveControl>();
    }
    private void Update()
    {
        if (Collect.collect.isStart)
        {
            Move();
        }
    }
    public void Move()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveControl.MoveFactorX;
        playerObject.transform.Translate(x: swerveAmount, y: 0, z: 0);
        Limit();
    }
    void Limit()
    {
        float posX = Mathf.Clamp(playerObject.transform.position.x, -4, 4);
        playerObject.transform.position = new Vector3(posX, 0, playerObject.transform.position.z);
    }
}
