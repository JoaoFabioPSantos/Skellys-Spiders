using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitApp : MonoBehaviour
{
    public void Quit()
    {
        // usado para a build: Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
