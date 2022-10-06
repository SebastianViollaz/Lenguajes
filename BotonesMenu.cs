using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BotonesMenu : MonoBehaviour
{
    
    public void CargarScena(string Nombre)
    {
        SceneManager.LoadScene(Nombre);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
