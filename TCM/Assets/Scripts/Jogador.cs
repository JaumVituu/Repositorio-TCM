using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    Animator animacao;
    Rigidbody2D movimento;

    bool isGrounded;
    public Transform groundCheck;

    public Text tempo;
    float tempomorte;
    float velocidadeandar;
    float velocidadepular = 7.0f;
    float escalaX;
    float escalaY;
    public Transform ataqueCheck;
    float areadoataque = 1.2f;
    public LayerMask CamadaInimigos;

    public string Cena;
    void Start()
    {
        animacao = GetComponent<Animator>();
        movimento = GetComponent<Rigidbody2D>();
        tempomorte = 3;
    }

    private void Update()
    {
        if (Input.GetKey("z")) {

            ataque();
        }
        
            if (tempomorte < 0) {

                SceneManager.LoadScene(Cena);
            }
            tempomorte = tempomorte - Time.deltaTime;
            tempo.text = tempomorte.ToString("0");
            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                //animacao.Play("");
            }
            if (Input.GetKey("d"))
            {
                tempomorte = 3;
                escalaX = 0.2f;
                escalaY = 0.2f;
                velocidadeandar = 7.0f;
                movimentacao();

                if (isGrounded)
                    //animacao.Play("");

                    rotacao();
            }
            else if (Input.GetKey("a"))
            {
                tempomorte = 3;
                escalaX = -0.2f;
                escalaY = 0.2f;
                velocidadeandar = -7.0f;
                movimentacao();

                if (isGrounded)
                    //animacao.Play("");

                    rotacao();
            }
            else
            {
                if (isGrounded)
                    animacao.Play("Persona_parada");
                velocidadeandar = 0f;
                movimentacao();
            }
            if (Input.GetKey("space") && isGrounded)
            {
                pulo();
                //animacao.Play("");
            }
            if (!isGrounded) {
                tempomorte = 3;
            }

    }
        void movimentacao() {
        movimento.velocity = new Vector2(velocidadeandar, movimento.velocity.y);
        }
        void rotacao() {
        transform.localScale = new Vector2(escalaX, escalaY);
        }
        void pulo() {
        movimento.velocity = new Vector2(movimento.velocity.x, velocidadepular);
        }
        void OnTriggerEnter2D(Collider2D colisao) {

        if (colisao.CompareTag("Cachorro") || colisao.CompareTag("Projetil") || colisao.CompareTag("GolpeBoss")){
            SceneManager.LoadScene(Cena);
            }
        }
        void ataque() {
        Collider2D[] acertouInimigo = Physics2D.OverlapCircleAll(ataqueCheck.position, areadoataque, CamadaInimigos);

        foreach (Collider2D Inimigo in acertouInimigo) {

            Inimigo.GetComponent<Inimigo>().morte();
        }
        }
        }
