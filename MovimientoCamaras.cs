using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamaras : MonoBehaviour
{
    [SerializeField] float velocidad;


    [SerializeField] float Interpolates;
    float Rot;
    Vector3 RotInicial;
    bool Ida = true;

    // Start is called before the first frame update
    void Start()
    {
        RotInicial = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Rot += Time.deltaTime;

        if (Ida == true)
        {
            transform.localEulerAngles += new Vector3(0, Time.deltaTime, 0)*velocidad;
        }
        else
        {
            transform.localEulerAngles -= new Vector3(0, Time.deltaTime, 0)*velocidad;
        }

                //280                   - 270       >= 10
        if (transform.localEulerAngles.y-RotInicial.y >= Interpolates)
        {
            print("cambio");
            Rot = 0;
            Ida = false;
        }         //260                     -  270     >= -10
        else if(transform.localEulerAngles.y - RotInicial.y <= -Interpolates)
        {
            print("cambio");
            Rot = 0;
            Ida = true;
        }


    }
}
