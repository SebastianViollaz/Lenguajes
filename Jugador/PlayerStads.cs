using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStads : MonoBehaviour
{
    [SerializeField] private string Nombre;
    [SerializeField] private int Edad;
    [SerializeField] private string Genero;

    [Header("Student Stads")]

    public float Energia;

    public float Diversion;
    public float Conocimiento;
    public float VidaSocial;


    [Header("Scene Stads")]
    public int NumeroDeDias;
    public void SettAll(string Nombre,int Edad,string Genero)
    {
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.Genero = Genero;
    }
    private void LateUpdate()
    {
        Diversion = Limitar(Diversion);
        Energia = Limitar(Energia);
        Conocimiento = Limitar(Conocimiento);
        VidaSocial = Limitar(VidaSocial);
        if (Energia > 100)
        {
            Energia = 100;
        }


    }
    float Limitar(float numero)
    {
        if (numero < 0)
        {
            numero = 0;
        }
        return numero;
    }


    public void LoadData()
    {
        SettAll(PlayerPrefs.GetString("Nombre"),PlayerPrefs.GetInt("Edad"),PlayerPrefs.GetString("Genero"));

        Energia = PlayerPrefs.GetFloat("Energia");
        Conocimiento = PlayerPrefs.GetFloat("Conocimiento");
        VidaSocial = PlayerPrefs.GetFloat("VidaSocial");
        Diversion = PlayerPrefs.GetFloat("Diversion");
        NumeroDeDias = PlayerPrefs.GetInt("NumeroDeDias");
        Genero = PlayerPrefs.GetString("Genero");
    }
    public void SaveData()
    {
        PlayerPrefs.SetString("Nombre",Nombre);
        PlayerPrefs.SetInt("Edad", Edad);
        PlayerPrefs.SetString("Genero", Genero);


        PlayerPrefs.SetFloat("Energia", Energia);
        PlayerPrefs.SetFloat("Conocimiento", Conocimiento);
        PlayerPrefs.SetFloat("VidaSocial", VidaSocial);
        PlayerPrefs.SetFloat("Diversion",Diversion);


        PlayerPrefs.SetInt("NumeroDeDias", NumeroDeDias);

    }
}
