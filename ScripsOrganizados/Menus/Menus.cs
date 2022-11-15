using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PanelPausa;
    [SerializeField] GameObject PanelDatos;
 
    bool MenuActivo;
    void Start()
    {
        PanelPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MenuActivo = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }
    void Pausar()
    {
        if (PuedoPausar())
        {
            if (Cursor.lockState == CursorLockMode.Locked) Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = !Cursor.visible;
            PanelPausa.SetActive(!PanelPausa.activeSelf);
            PanelDatos.SetActive(!PanelDatos.activeSelf);
            Player.SetActive(!Player.activeSelf);
            MenuActivo = !MenuActivo;
        }
        
    }
    bool PuedoPausar()
    {
        if (Player.activeSelf == true || MenuActivo ==true) return true;
        return false;
    }
}
