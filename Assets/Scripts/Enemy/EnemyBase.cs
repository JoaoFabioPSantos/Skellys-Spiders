using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;

    public string triggerAttack = "Attack";
    public string triggerKill = "Death";
    public HealthBase health;
    //essa vari�vel foi redundante, health base j� tem isso:
    public float timeToDestroy = 1f;

    private void Awake()
    {
        if (health != null)
        {
            health.OnKill += OnEnemyKill;
        }
        //precisamos destruir o callback para ele n�o ficar na mem�ria.
    }

    private void OnEnemyKill()
    {
        health.OnKill -= OnEnemyKill;
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
        }

    }

    public void Damage(int amount)
    {
        health.Damage(amount);
    }
}
