using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public PlayerBasic player;

    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
