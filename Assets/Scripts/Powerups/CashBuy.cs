using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashBuy : MonoBehaviour
{
    public static CashBuy cash;
    public int cashCost;
    public float cashLevel;
    private void Awake()
    {
        cash = this;
    }
}
