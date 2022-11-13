using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Distance : MonoBehaviour
{
    public float distanceMultiplier;
    [SerializeField] string result;
    void Start()
    {
        GameObject canvas = gameObject.transform.GetChild(0).gameObject;
        TextMeshProUGUI distanceText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        distanceText.text = "" + result;
        if (result == "+")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.9f, 0.4f);
        }
        if (result == "-")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.9f, 0.2f, 0.2f, 0.4f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        BoxCollider firstGun = FindObjectOfType<PlayerStateManager>().GetComponent<BoxCollider>();
        firstGun.size = new Vector3(firstGun.size.x, firstGun.size.y, firstGun.size.z + distanceMultiplier);
        firstGun.center = new Vector3(firstGun.center.x, firstGun.center.y, firstGun.size.z / 2);
    }
}
