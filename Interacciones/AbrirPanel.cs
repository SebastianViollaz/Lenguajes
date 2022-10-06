using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirPanel : Objeto_Interactivo
{
    [SerializeField] PlayerStads Player;
    [SerializeField] GameObject PanelAMostrar;
    [SerializeField] GameObject PanelEstadisticas;

    [SerializeField] bool ReiniciarInteracciones;

    public override void  Interactuar()
    {
        Debug.Log("Dormir");
        PanelAMostrar.SetActive(true);
        Player.gameObject.SetActive(false);
        PanelEstadisticas.SetActive(false);
        Player.Energia = 100;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (ReiniciarInteracciones == true)
        {
            foreach (Interaccion Objeto in Resources.FindObjectsOfTypeAll(typeof(Interaccion)))
            {
                Objeto.Set_CantidadDeUsos(0);
            }
        }
       

    }
}
