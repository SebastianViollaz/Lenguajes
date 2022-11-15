using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonEmpezar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Panel Panel;
    public void Empezar()
    {
        Panel.Ocultar();

    }
}
