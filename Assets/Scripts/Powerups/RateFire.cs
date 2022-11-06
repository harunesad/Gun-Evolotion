using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RateFire : MonoBehaviour
{
    PlayerStateManager playerState;
    public float rateFireMultiplier;
    [SerializeField] string result;
    void Start()
    {
        GameObject canvas = gameObject.transform.GetChild(0).gameObject;
        TextMeshProUGUI rateFireText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        rateFireText.text = "" + result;
        playerState = FindObjectOfType<PlayerStateManager>();
        //if (rateFireMultiplier >= 1)
        //{
        //    gameObject.GetComponent<Renderer>().material.color = new Color(0.2f, 0.9f, 0.2f, 0.4f);
        //}
        //else
        //{
        //    gameObject.GetComponent<Renderer>().material.color = new Color(0.9f, 0.2f, 0.2f, 0.4f);
        //}
        if (result == "+")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.9f, 0.4f);
        }
        if (result == "-")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.9f, 0.2f, 0.2f, 0.4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GunProperties gunProperties = FirstGunSpawn.first.firstGunObj.GetComponent<GunProperties>();
        gunProperties.spawnSpeed += rateFireMultiplier;
        playerState.spawnSpeed = gunProperties.spawnSpeed;
    }
}
