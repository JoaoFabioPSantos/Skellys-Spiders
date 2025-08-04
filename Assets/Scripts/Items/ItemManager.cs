using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Studio.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TMP_Text textHud;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;

    }

    //caso não seja passado no parametro, ele vai ser naturalmente 1
    public void AddCoins(int amount = 1)
    {
        coins += amount;
        textHud.text = "X " + coins;
    }
}
