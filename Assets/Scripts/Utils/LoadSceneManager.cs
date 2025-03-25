using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void Load(int numberLevel)
    {
        SceneManager.LoadScene(numberLevel);
    }

    public void Load(string level)
    {
        SceneManager.LoadScene(level);
    }
}
