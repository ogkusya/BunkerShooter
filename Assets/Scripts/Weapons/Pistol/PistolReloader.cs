using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolReloader : MonoBehaviour
{
    [SerializeField] private int amountMax;

    private float currentAmount;

    private void Awake()
    {
        Reload();
        GetComponent<ShotSystem>().Shooted += ReduceBullet;
    }

    public void Reload()
    {
        currentAmount = amountMax;
    }

    public void ReduceBullet()
    {
        currentAmount--;
    }

    public bool IsMagFull()
    {
        return currentAmount == amountMax;
    }
    public bool CheckAmount()
    {
        return currentAmount > 0;
    }
}
