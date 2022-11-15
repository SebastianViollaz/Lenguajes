using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonGuardarPartida : MonoBehaviour
{

    [SerializeField] PlayerStads Estadisticas;
    public void GuardarPartida()
    {
        Estadisticas.SaveData();
    }
}
