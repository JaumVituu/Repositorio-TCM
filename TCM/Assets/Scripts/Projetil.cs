using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    Vector3 velocidade;
    float tempoRestante;
    public GameObject inimigo;
    int direcao;

    void Start()
    {
        tempoRestante = 0f;   
    }

    // Update is called once per frame
    void Update()
    {
        direcao = inimigo.GetComponent<Inimigo>().direcao;
        Mover();
        Sumir();
        Debug.Log(direcao);
    }
    void Sumir()
    {
        tempoRestante += Time.deltaTime;
        if (tempoRestante >= 2f)
        {
            Destroy(gameObject);
        }
    }
    void Mover()
    {

        
        //Debug.Log(dir);
        if (direcao == 1)
        {
            
            velocidade.x = 0.06f;
            //Debug.Log("direita");
        }
        if (direcao == 0)
        {
            velocidade.x = -0.06f;
            //Debug.Log("esquerda");
        }
        transform.Translate(velocidade);
    }

}
