using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    Animator imagem;


    public Transform jogador;
    float campodevisao;
    float velocidade;
    Rigidbody2D rb2d;
    float escalaX;
    float escalaY;
    float intervaloAtaque;
    float distancia;
    public int direcao;
    public int vida;
    public int vidaatual;
    bool ChefeVivo = true;
    float intervaloDano;
    public string Cena;
    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        intervaloAtaque = 0f;
        intervaloDano = 1f;
        vida = 100;
        vidaatual = vida;
    }

    // Update is called once per frame
    void Update()
    {
        intervaloDano += Time.deltaTime;
        distancia = Vector2.Distance(transform.position, jogador.position);
        if (gameObject.tag == "Inimigo")
        {

            campodevisao = 15.0f;
            if (distancia < campodevisao)
            {
                if (transform.position.x < jogador.position.x)
                {
                    escalaX = 4.5f;
                    escalaY = 4.5f;
                    rotacao();
                    imagem.Play("soldado_atento");
                    direcao = 1;
                }
                else
                {
                    escalaX = -4.5f;
                    escalaY = 4.5f;
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
            campodevisao = 10.0f;
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
            campodevisao = 100.0f;
            if (distancia < campodevisao && distancia > 4)
            {
                intervaloAtaque = 0;
                if (transform.position.x < jogador.position.x)
                {
                    velocidade = 3.0f;
                    escalaX = 0.2f;
                    escalaY = 0.2f;
                    movimento();
                    rotacao();
                    imagem.Play("Veio_andando");
                }
                else if(transform.position.x > jogador.position.x)
                {
                    velocidade = -3.0f;
                    escalaX = -0.2f;
                    escalaY = 0.2f;
                    movimento();
                    rotacao();
                    imagem.Play("Veio_andando");
                }

            }
            if (distancia <= 3)
            {
                
                
                intervaloAtaque += Time.deltaTime;
                if (intervaloAtaque >= 2f)
                {
                    imagem.Play("Veio_batendo");
                    if (intervaloAtaque >= 4f)
                    {
                        intervaloAtaque = 0;
                    }
                }
                else
                {
                    imagem.Play("Veio_parado");
                }
            }
        }
        else {
            velocidade = 0;
            movimento();
            imagem.Play("Veio_parado");
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
    public void PerderVida()
    {
        if (gameObject.tag == "Chefe")
        {
            vidaatual -= 10;

            if (vidaatual <= 0)
            {
                morte();
                SceneManager.LoadScene(Cena);
            }
        }
    }
    void Atacar()
    {
        float distancia = Vector2.Distance(transform.position, jogador.position);
        campodevisao = 10.0f;
        if (gameObject.tag == "Inimigo")
        {    
            intervaloAtaque += Time.deltaTime;
            if (distancia < campodevisao)
            {

                if (intervaloAtaque >= 1.7f)
                {
                    if (direcao == 0)
                    {
                        GameObject TiroPrefab = Resources.Load<GameObject>("Tiro");
                        float projetilY = 1.7f;
                        Instantiate(TiroPrefab, transform.position + new Vector3(0, projetilY, 0), Quaternion.identity);
                        Debug.Log("Resetou");
                        intervaloAtaque = 0f;
                    }                    
                }
            }
            else
            {
                intervaloAtaque = 0f;
            }
        }
    }
    
}
