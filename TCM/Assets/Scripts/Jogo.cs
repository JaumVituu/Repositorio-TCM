using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour
{
    public string Cena;

    void OnTriggerEnter2D(Collider2D fase) {
        if (fase.gameObject.tag == "Jogador") {
            MudarCena();
        }
    }
    public void MudarCena()
    {
        SceneManager.LoadScene(Cena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
