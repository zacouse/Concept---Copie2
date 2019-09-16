using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public abstract class Enemy : MonoBehaviour, Damagable {

    public int HP = 1;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP<=0)
        {
            Die();
        }
    }

    public abstract void Die();

    protected void SetLife(int newLife)
    {
        HP = newLife;
    }
}
