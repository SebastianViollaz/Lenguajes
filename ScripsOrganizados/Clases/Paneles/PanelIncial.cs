using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelIncial : Panel
{

    public override void Mostrar()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        CanvasPanel.SetActive(true);

        PanelDatos.SetActive(false);
        
        Player.SetActive(false);
    }
    public override void Ocultar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CanvasPanel.SetActive(false);

        PanelDatos.SetActive(true);

        Player.SetActive(true);

    }
}
