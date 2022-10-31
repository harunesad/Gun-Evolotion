using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Distance : MonoBehaviour
{
    //public GameObject spawnPoint;
    public float distanceMultiplier;
    [SerializeField] string result;
    void Start()
    {
        //spawnPoint = GameObject.Find("Player").transform.GetChild(0).gameObject;
        GameObject canvas = gameObject.transform.GetChild(0).gameObject;
        TextMeshProUGUI distanceText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        distanceText.text = "" + result;
        //if (distanceMultiplier >= 1)
        //{
        //    gameObject.GetComponent<Renderer>().material.color = new Color(0.2f, 0.9f, 0.2f, 0.4f);
        //}
        //else
        //{
        //    gameObject.GetComponent<Renderer>().material.color = new Color(0.9f, 0.2f, 0.2f, 0.4f);
        //}
        if (result == "+")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.2f, 0.9f, 0.2f, 0.4f);
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
        BoxCollider firstGun = FindObjectOfType<PlayerStateManager>().GetComponent<BoxCollider>();
        firstGun.size = new Vector3(firstGun.size.x, firstGun.size.y, firstGun.size.z + distanceMultiplier);
        firstGun.center = new Vector3(firstGun.center.x, firstGun.center.y, firstGun.size.z / 2);
        //GameObject trigger = spawnPoint.transform.GetChild(1).gameObject;
        //var posZ = trigger.transform.localScale.z;
        //posZ *= distanceMultiplier;
        //Transform scale = trigger.transform;
        //scale.localScale = new Vector3(scale.localScale.x, scale.localScale.y, posZ);
    }
}
