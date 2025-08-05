using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Studio.Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TMP_Text textCoinHud;

    public static void UpdateTextCoins(string s)
    {
        Instance.textCoinHud.text = s;
    }
}
