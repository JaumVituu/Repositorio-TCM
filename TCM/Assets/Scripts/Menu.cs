using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Cena;

    public void MudarCena()
    {
        SceneManager.LoadScene(Cena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
