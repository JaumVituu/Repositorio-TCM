using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPersonagem2D : MonoBehaviour
{

   // Animator animacao;
    Rigidbody2D movimento;
    //SpriteRenderer imagens;

    bool isGrounded;
    [SerializeField]
    Transform groundCheck;

    private float velocidadeandar = 6.0f;
    private float velocidadepular = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        //animacao = GetComponent<Animator>();
        movimento = GetComponent<Rigidbody2D>();
        //imagens = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else {
            isGrounded = false;
            //animacao.Play("");
        }
        if (Input.GetKey("d"))
        {
            movimento.velocity = new Vector2(velocidadeandar, movimento.velocity.y);

            //if(isGrounded)
            //animacao.Play("");
            
            //imagens.flipX = true;
        }
        else if (Input.GetKey("a"))
        {
            movimento.velocity = new Vector2(-velocidadeandar, movimento.velocity.y);

            //if(isGrounded)
            //animacao.Play("");
            
            //imagens.flipX = false;
        }
        else
        {
            //if(isGrounded)
            //animacao.Play("");
            
            movimento.velocity = new Vector2(0, movimento.velocity.y);
        }
        if (Input.GetKey("w") && isGrounded)
        {
            movimento.velocity = new Vector2(movimento.velocity.x, velocidadepular);
            //animacao.Play("");
        }

    }
}
