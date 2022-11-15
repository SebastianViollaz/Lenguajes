using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEscondido : Objeto_Interactivo
{
    [SerializeField] Transform UbicacionDeseada;
    [SerializeField] ObjetosNecesarios ConjuntoDeObjetos;
    [SerializeField] AudioClip SonidoAgarrar;
    [SerializeField] AudioSource AudioGeneral;
    bool ubicado;
    // Start is called before the first frame update
    void Start()
    {
        ubicado = false;
    }

    // Update is called once per frame
    public override void Interactuar()
    {
        
        if(ubicado == false)
        {
            for (int i = 0; i < ConjuntoDeObjetos.ItemsNecesarios.Length; i++)
            {
                if (ConjuntoDeObjetos.ItemsConseguidos[i] == null && ubicado == false)
                {
                    ubicado = true;
                    AudioGeneral.PlayOneShot((SonidoAgarrar));
                    gameObject.transform.position = UbicacionDeseada.position;
                    gameObject.transform.rotation = UbicacionDeseada.rotation;
                    transform.parent = UbicacionDeseada.parent;
                    ConjuntoDeObjetos.ItemsConseguidos[i] = gameObject;
                }
            }
        }
       

    }
}
