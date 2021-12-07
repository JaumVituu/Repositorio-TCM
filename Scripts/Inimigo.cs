using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Animator imagem;

    [SerializeField]
    Transform jogador;

    [SerializeField]
    GameObject municao;

    float campodevisao = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector2.Distance(transform.position, jogador.position);

        if (distancia < campodevisao)
        {
            if (transform.position.x < jogador.position.x)
            {
                transform.localScale = new Vector2(4, 4);
                imagem.Play("soldado_atento");
            }
            else
            {
                transform.localScale = new Vector2(-4, 4);
                imagem.Play("soldado_atento");
            }
        }
        else
        {
            imagem.Play("soldado_parado");
        }
    }
}
