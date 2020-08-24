using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{

    public int Health;

    [HideInInspector]
    public Transform player;
    public float speed;
    public float timer;
    public int damage;


    public virtual void Start() {
         player= GameObject.FindGameObjectWithTag("player").transform;
    }

    public void TakeDamage(int damageAmout)
    {
        Health-=damageAmout;

        if (Health <=0)
        {
            Destroy(gameObject);
        }
    }
    
}
