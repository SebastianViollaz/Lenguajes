using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PanelDiaSiguiente : Panel
{

    [SerializeField] Text TextoDias;

    [SerializeField] Text TextoConocimiento;

    [SerializeField] Text TextoVidaSocial;

    [SerializeField] Text TextoDiversion;



    public override void Mostrar()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Actulaizar();

        CanvasPanel.SetActive(true);
        Player.SetActive(false);


    }
    public override void Ocultar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CanvasPanel.SetActive(false);
        Player.SetActive(true);


    }
    // Start is called before the first frame update
    public void Actulaizar()
    {
        TextoDias.text = Player.GetComponent<PlayerStads>().NumeroDeDias.ToString();
        TextoConocimiento.text = Player.GetComponent<PlayerStads>().Conocimiento.ToString();
        TextoVidaSocial.text = Player.GetComponent<PlayerStads>().VidaSocial.ToString();
        TextoDiversion.text = Player.GetComponent<PlayerStads>().Diversion.ToString();
    }
}
