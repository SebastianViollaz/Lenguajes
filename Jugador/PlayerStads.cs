using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStads : MonoBehaviour
{
    // Start is called before the first frame update
    public string Nombre;
    public string Edad;
    public string Genero;

    [Header("Student Stads")]

    public float Energia;

    public float Diversion;
    public float Conocimiento;
    public float VidaSocial;


    [Header("Scene Stads")]
    public int NumeroDeDias;
    public void Sett(string Nombre,string Edad,string Genero)
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
}
