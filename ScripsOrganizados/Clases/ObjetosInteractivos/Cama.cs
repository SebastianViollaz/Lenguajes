using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cama : Objeto_Interactivo
{

    [SerializeField] Panel PanelPasoDeDia;


    [SerializeField] PlayerStads Player;
    [SerializeField] GameObject PanelAMostrar;
    [SerializeField] GameObject PanelEstadisticas;

    [SerializeField] bool ReiniciarInteracciones;

    public override void Interactuar()
    {
        PanelPasoDeDia.Mostrar();

        if (PanelAMostrar.GetComponent<PanelDiaSiguiente>() != null)
        {
            PanelAMostrar.GetComponent<PanelDiaSiguiente>().Actulaizar();
        }
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

        Player.SaveData();


    }
}
