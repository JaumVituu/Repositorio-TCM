using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Animator imagem;


    public Transform jogador;

    float campodevisao;
    float velocidade = 3.0f;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector2.Distance(transform.position, jogador.position);
        if (gameObject.tag == "Inimigo")
        {
            campodevisao = 10.0f;
            if (distancia < campodevisao)
            {
                if (transform.position.x < jogador.position.x)
                {
                    transform.localScale = new Vector2(3.5f, 3.5f);
                    imagem.Play("soldado_atento");
                }
                else
                {
                    transform.localScale = new Vector2(-3.5f, 3.5f);
                    imagem.Play("soldado_atento");
                }
            }
            else
            {
                imagem.Play("soldado_parado");
            }
        }
        if (gameObject.tag == "Cachorro")
        {
            campodevisao = 6.0f;
            if (distancia < campodevisao)
            {
                if (transform.position.x < jogador.position.x)
                {
                    rb2d.velocity = new Vector2(velocidade, 0);
                    transform.localScale = new Vector2(-3, 3);
                    imagem.Play("Cachorro_andando");
                }
                else
                {
                    rb2d.velocity = new Vector2(-velocidade, 0);
                    transform.localScale = new Vector2(3, 3);
                    imagem.Play("Cachorro_andando");
                }
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
                imagem.Play("Cachorro_parado");
            }
        }
        if (gameObject.tag == "Chefe")
        {
            campodevisao = 10.0f;
            if (distancia < campodevisao)
            {

                if (transform.position.x < jogador.position.x)
                {

                    rb2d.velocity = new Vector2(velocidade, 0);
                    transform.localScale = new Vector2(0.4f, 0.4f);
                    imagem.Play("Veio_andando");
                }
                else
                {

                    rb2d.velocity = new Vector2(-velocidade, 0);
                    transform.localScale = new Vector2(-0.4f, 0.4f);
                    imagem.Play("Veio_andando");
                }

            }
            else {
                rb2d.velocity = new Vector2(0, 0);
                imagem.Play("Veio_parado");
            }
        }
    }
}