using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{

    public float Speed;
    public float lifeTime;
    public GameObject explosion;
    public int damage;
    
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);  
    }

   
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }


    void DestroyProjectile() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.tag == "Inimigo")
        {
            colission.GetComponent<inimigo>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
