using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerBasicSetup : ScriptableObject
{

    [Header("Movement")]
    public float speed;
    public float speedRun;
    public Vector2 friction = new Vector2(.1f, 0);
    public float forceJump = 2f;
    public float playerSwapduration = .1f;
}
