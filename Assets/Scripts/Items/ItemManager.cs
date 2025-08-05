using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Studio.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt slimePoint;
    public TMP_Text textHud;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        slimePoint.value = 0;
    }

    //caso não seja passado no parametro, ele vai ser naturalmente 1
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    public void AddSlimePoint(int amount = 1)
    {
        slimePoint.value += amount;
    }
}
