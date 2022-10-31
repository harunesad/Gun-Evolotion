using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    public float followSpeed;
    void Start()
    {
        
    }
    void Update()
    {
        //Vector3 followPos = new Vector3(player.position.x, player.position.y, player.position.z);
        transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * followSpeed);
    }
}
