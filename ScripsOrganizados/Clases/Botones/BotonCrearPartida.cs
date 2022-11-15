using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonCrearPartida : MonoBehaviour
{
    [SerializeField] PanelIncial PanelInicial;
    [SerializeField] PlayerStads Player;
    [Header("Nombre")]
    [SerializeField] InputField NombreInputField;
    [SerializeField] GameObject NombreInvalido;

    [Header("Edad")]
    [SerializeField] InputField EdadInputField;
    [SerializeField] GameObject EdadInvalida;

    [Header("Genero")]
    [SerializeField] Dropdown GeneroDropdown;


    public void CrearPartida()
    {
        if(NombreValido(NombreInputField.text) && EdadValida(Int16.Parse(EdadInputField.text)))
        {
            PlayerPrefs.SetString("Nombre", NombreInputField.text);
            PlayerPrefs.SetInt("Edad", Int16.Parse(EdadInputField.text));
            PlayerPrefs.SetString("Genero", GeneroDropdown.GetComponentInChildren<Text>().text);
            VincularDatos();
            StartGame();
        }
        else
        {
            CheckState();
        }
    }

    void StartGame()
    {
        Player.gameObject.SetActive(true);
        PanelInicial.Ocultar();
    }
    void VincularDatos()
    {
        Player.SettAll(NombreInputField.text, Int16.Parse(EdadInputField.text), GeneroDropdown.GetComponentInChildren<Text>().text);
    }


    void CheckState()
    {
            NombreInvalido.SetActive(!NombreValido(NombreInputField.text));

            EdadInvalida.SetActive(!EdadValida(Int16.Parse(EdadInputField.text)));
        
    }


    bool NombreValido(string Nombre)
    {
        return NombreInputField.text != " " && NombreInputField.text.Length > 0;
    }

    



    bool EdadValida(int edad)
    {
        return edad<100 && edad >= 18;
    }
}
