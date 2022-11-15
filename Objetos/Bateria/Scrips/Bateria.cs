using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bateria : MonoBehaviour
{
    [SerializeField] PlayerStads Player;
    [SerializeField] GameObject Camara;
    [SerializeField] Panel PanelInstrucciones;
    [SerializeField] GameObject PanelDatos;


    [SerializeField] Toggle NoMostrar;





    bool interactuando;


    [Header("Partes")]
    [SerializeField] AudioSource AudioDeBateria;
    [SerializeField] GameObject Kick;
    [SerializeField] GameObject HitHats;
    [SerializeField] GameObject Crash;
    [SerializeField] GameObject Tombs;
    [SerializeField] GameObject Snare;
    [SerializeField] GameObject FlorTom;


    private void Awake()
    {
        Camara.SetActive(false);
    }
    private void Update()
    {
        if(interactuando == true)
        {
            TocarBateria(); 
        }
    }
    // Update is called once per frame
    public void Interactuar()
    {

        if(NoMostrar.isOn == true)
        {
            EmpezarAtocar();
        }
        else
        {
            PanelInstrucciones.Mostrar();

        }
        Camara.SetActive(true);
        Player.gameObject.SetActive(false);





        PanelDatos.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        

    }
    public void EmpezarAtocar()
    {
        interactuando = true;

    }
    void salir()
    {
        interactuando = false;

        PanelDatos.SetActive(true);
        Player.gameObject.SetActive(true);
        Camara.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void TocarBateria()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Snare.GetComponent<PartesBateria>().Interactuar(AudioDeBateria);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HitHats.GetComponent<PartesBateria>().Interactuar(AudioDeBateria);


        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Tombs.GetComponent<PartesBateria>().Interactuar(AudioDeBateria);


        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Crash.GetComponent<PartesBateria>().Interactuar(AudioDeBateria);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FlorTom.GetComponent<PartesBateria>().Interactuar(AudioDeBateria);

           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kick.GetComponent<PartesBateria>().Interactuar(AudioDeBateria);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            salir();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camara.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.gameObject.GetComponent<PartesBateria>() != null)
                {

                    PartesBateria Objeto = hit.collider.gameObject.GetComponent<PartesBateria>();
                    Objeto.Anim.SetTrigger("Tocar");
                    Objeto.Interactuar(AudioDeBateria); 
                }
            }

        }
       



    }
}
