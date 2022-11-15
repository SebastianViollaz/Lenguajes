using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichadeLuz : Objeto_Interactivo
{
    [SerializeField] Light[] Luces;

    // Update is called once per frame
    public override void Interactuar()
    {
        for(int i = 0; i < Luces.Length; i++)
        {
            Luces[i].gameObject.SetActive(!Luces[i].gameObject.activeSelf);
        }
    }
}
