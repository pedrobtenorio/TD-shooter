using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    // Start is called before the first frame update

    private Jogador script;
    private Vector2 targedPosition;
    public float speed;
    public int  damage;
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("player").GetComponent<Jogador>();
        targedPosition = script.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, targedPosition) > .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targedPosition, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D colission)
    {
        if(colission.tag == "player")
        {
            script.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
