using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : inimigo
{

   

    private Animator anim;

    public float timeBetweenSummons;
    private float summonTime;
    public inimigo minion;
    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("player").transform;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player !=null)
        {
            if(Time.time >= summonTime)
            {
                summonTime = Time.time + timeBetweenSummons;
                anim.SetTrigger("summon");
            }
        }
    }

     public void summon()
    {
        Instantiate(minion, transform.position, transform.rotation);
    }

}


