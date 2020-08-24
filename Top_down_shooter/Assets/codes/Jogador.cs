using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jogador : MonoBehaviour
{


    
    public float speed;

    private Rigidbody2D rb;

    private Vector2 moveAmount;

    private Animator anim;

    public float Health;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       


    }

    private void Update()
    {


        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;   

        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);

         if (moveInput != Vector2.zero)
        {
            anim.SetBool("TaAndando", true);
        }
         else {
            anim.SetBool("TaAndando", false);
        }      
    }


    public void TakeDamage(int damageAmout)
    {
        Health -= damageAmout;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }





}