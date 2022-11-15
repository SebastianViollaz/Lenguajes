using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{

    [SerializeField] PanelIncial PanelInicial;

    [SerializeField] PlayerStads Estadisticas;
    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerPrefs.GetInt("NuevoJuego") == 1)
        {
            PanelInicial.Mostrar();

        }
        else
        {
            CargarJuego();
        }
    }
    void CargarJuego()
    {

        Estadisticas.LoadData();
        PanelInicial.Ocultar();
    }
   
}
