using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOIntUpdate : MonoBehaviour
{
    public SOInt SOInt;
    public TMP_Text uiTextValue;

    void Update()
    {
        uiTextValue.text = "X "+SOInt.value.ToString();
    }
}
