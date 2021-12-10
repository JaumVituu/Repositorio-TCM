using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    Animator animacao;
    Rigidbody2D movimento;
    SpriteRenderer imagem;
    public Text vidas;
    float vida;
    bool invulnerabilidade = false;

    bool isGrounded;
    public Transform groundCheck;

    private float velocidadeandar = 6.0f;
    private float velocidadepular = 7.0f;

    public string Cena;
    void Start()
    {
        animacao = GetComponent<Animator>();
        movimento = GetComponent<Rigidbody2D>();
        imagem = GetComponent<SpriteRenderer>();
        vida = 3;
    }

    private void Update()
    {
        if (gameObject.tag == "Jogador")
        {
            vidas.text = vida.ToString("0");

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
                movimento.velocity = new Vector2(velocidadeandar, movimento.velocity.y);

                if (isGrounded)
                    //animacao.Play("");

                    transform.localScale = new Vector2(0.2f, 0.2f);
            }
            else if (Input.GetKey("a"))
            {
                movimento.velocity = new Vector2(-velocidadeandar, movimento.velocity.y);

                if (isGrounded)
                    //animacao.Play("");

                    transform.localScale = new Vector2(-0.2f, 0.2f);
            }
            else
            {
                if (isGrounded)
                    animacao.Play("Persona_parada");

                movimento.velocity = new Vector2(0, movimento.velocity.y);
            }
            if (Input.GetKey("space") && isGrounded)
            {
                movimento.velocity = new Vector2(movimento.velocity.x, velocidadepular);
                //animacao.Play("");
            }


        }
    }

    IEnumerator Invulneravel() {
        for (float i = 0; i < 1; i += 0.1f) {
            imagem.enabled = false;
            yield return new WaitForSeconds(0.1f);
            imagem.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invulnerabilidade = false;
    }
        void Dano()
        {
            invulnerabilidade = true;
            vida = vida - 1;
            StartCoroutine (Invulneravel());

            if (vida < 1)
            {
                SceneManager.LoadScene(Cena);
             }
        }
        void OnTriggerEnter2D(Collider2D colisao) {

        if (colisao.CompareTag("Cachorro")){
            if (!invulnerabilidade) {
                Dano();
            }
        }
        }
    }
