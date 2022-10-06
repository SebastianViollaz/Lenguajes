using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonContinuar : MonoBehaviour
{


    [SerializeField] GameObject PanelInicial;
    [SerializeField] GameObject PanelDeDatos;
    [SerializeField] GameObject Mira;
    [Header("Nombre")]
    [SerializeField] InputField NombreInputField;
    [SerializeField] GameObject NombreInvalido;

    [Header("Edad")]

    [SerializeField] InputField EdadInputField;
    [SerializeField] GameObject EdadInvalida;

    [Header("Genero")]
    [SerializeField] Dropdown GeneroDropdown;
    string Genero;



    [SerializeField] GameObject Player;
    PlayerStads PlayerConfig;

    bool datosvalidos;
    int Numero;
    private void Awake()
    {
        Mira.SetActive(false);
        PanelDeDatos.SetActive(false);
        NombreInvalido.SetActive(false);
        EdadInvalida.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continuar()
    {

        datosvalidos = int.TryParse(EdadInputField.text, out Numero) && (NombreInputField.text != " " && NombreInputField.text.Length>0);
        EdadInvalida.SetActive(!int.TryParse(EdadInputField.text, out Numero));
        NombreInvalido.SetActive(!(NombreInputField.text != " " && NombreInputField.text.Length > 0));
        Genero = GeneroDropdown.GetComponentInChildren<Text>().text;
        if (datosvalidos)
        {
            PanelInicial.SetActive(false);
            Player.SetActive(true);
            Player.GetComponent<PlayerStads>().Sett(NombreInputField.text, EdadInputField.text,Genero);
            PanelDeDatos.SetActive(true);
            Mira.SetActive(true);



        }
    }
}
