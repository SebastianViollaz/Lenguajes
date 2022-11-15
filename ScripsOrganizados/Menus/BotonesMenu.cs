using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BotonesMenu : MonoBehaviour
{
    

    public void NuevoJuego(string Nombre)
    {
        PlayerPrefs.SetInt("NuevoJuego", 1);
        SceneManager.LoadScene(Nombre);

    }
    public void CargarScena(string Nombre)
    {
        PlayerPrefs.SetInt("NuevoJuego", 0);
        SceneManager.LoadScene(Nombre);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
