using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosNecesarios : Objeto_Interactivo
{

    public GameObject[] ItemsNecesarios;
    public GameObject[] ItemsConseguidos;
    
    public override void Interactuar()
    {
        bool Cumple = Verificar();
        if(Cumple==true)
        {
            gameObject.GetComponent<Bateria>().Interactuar();

        }
        else
        {
            print("FaltanPartes");
        }
    }
    bool Verificar()
    {
        int ElementosNecesarios = ItemsNecesarios.Length;
        int ElementosIguales = 0;
        for(int i=0;i<ItemsConseguidos.Length;i++)
        {
            bool encontro = false;
            for (int j = 0; j < ItemsNecesarios.Length; j++)
            {
                if (ItemsConseguidos[i] == ItemsNecesarios[j] && encontro==false)
                {
                    encontro = true;
                    ElementosIguales++;
                }

            }
        }
        return ElementosIguales == ElementosNecesarios;
    }
}
