using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Animator imagem;


    public Transform jogador;
    float campodevisao;
    float velocidade;
    Rigidbody2D rb2d;
    float escalaX;
    float escalaY;
    float intervaloTiro;
    public float distancia;
    public int direcao;
    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        intervaloTiro = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        distancia = Vector2.Distance(transform.position, jogador.position);
        if (gameObject.tag == "Inimigo")
        {
            
            campodevisao = 10.0f;
            if (distancia < campodevisao)
            {
                if (transform.position.x < jogador.position.x)
                {
                    escalaX = 3.5f;
                    escalaY = 3.5f;
                    rotacao();
                    imagem.Play("soldado_atento");  
                    direcao = 1;
                }
                else
                {
                    escalaX = -3.5f;
                    escalaY = 3.5f;
                    rotacao();
                    imagem.Play("soldado_atento");
                    direcao = 0;
                }
                Atacar();
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
                    velocidade = 3.0f;
                    escalaX = -3.0f;
                    escalaY = 3.0f;
                    movimento();
                    rotacao();
                    imagem.Play("Cachorro_andando");
                }
                else
                {
                    velocidade = -3.0f;
                    escalaX = 3.0f;
                    escalaY = 3.0f;
                    movimento();
                    rotacao();
                    imagem.Play("Cachorro_andando");
                }
            }
            else
            {
                velocidade = 0;
                movimento();
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
                    velocidade = 3.0f;
                    escalaX = 0.4f;
                    escalaY = 0.4f;
                    movimento();
                    rotacao();
                    imagem.Play("Veio_andando");
                }
                else
                {
                    velocidade = -3.0f;
                    escalaX = -0.4f;
                    escalaY = 0.4f;
                    movimento();
                    rotacao();
                    imagem.Play("Veio_andando");
                }

            }
            else {
                velocidade = 0;
                movimento();
                imagem.Play("Veio_parado");
            }
        }
    }
    void movimento() {
        rb2d.velocity = new Vector2(velocidade, 0);
    }
    void rotacao() {
        transform.localScale = new Vector2(escalaX, escalaY);
    }
    public void morte() {
        Destroy(gameObject);
    }
    void Atacar()
    {
        float distancia = Vector2.Distance(transform.position, jogador.position);
        campodevisao = 10.0f;
        if (gameObject.tag == "Inimigo")
        {    
            intervaloTiro += Time.deltaTime;
            if (distancia < campodevisao)
            {
                if (intervaloTiro >= 1f)
                {
                    if (direcao == 0)
                    {
                        GameObject TiroPrefab = Resources.Load<GameObject>("Tiro");
                        float projetilY = 1.7f;
                        Instantiate(TiroPrefab, transform.position + new Vector3(0, projetilY, 0), Quaternion.identity);
                        Debug.Log("Resetou");
                        intervaloTiro = 0f;
                    }                    
                }
            }
            else
            {
                intervaloTiro = 0f;
            }
        }
    }

}