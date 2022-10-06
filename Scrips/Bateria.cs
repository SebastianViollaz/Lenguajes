using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    [SerializeField] PlayerStads Player;
    [SerializeField] GameObject Camara;
    [SerializeField] GameObject PanelInstrucciones;
    [SerializeField] GameObject PanelDatos;

    bool interactuando;


    [Header("Partes")]
    [SerializeField] GameObject Bombo;
    [SerializeField] GameObject PlatilloDoble;
    [SerializeField] GameObject Platillo;
    [SerializeField] GameObject Tombs;
    [SerializeField] GameObject BomBoIz;
    [SerializeField] GameObject BomBoDer;



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
        Camara.SetActive(true);
        Player.gameObject.SetActive(false);
        PanelDatos.SetActive(false);
        interactuando = true;

    }
    void salir()
    {
        PanelDatos.SetActive(true);
        Player.gameObject.SetActive(true);
        Camara.SetActive(false);
    }
    void TocarBateria()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BomBoIz.GetComponent<AudioSource>().PlayOneShot(BomBoIz.GetComponent<AudioSource>().clip);
            BomBoIz.GetComponent<Animator>().SetTrigger("Tocar");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlatilloDoble.GetComponent<AudioSource>().PlayOneShot(PlatilloDoble.GetComponent<AudioSource>().clip);
            PlatilloDoble.GetComponent<Animator>().SetTrigger("Tocar");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Tombs.GetComponent<AudioSource>().PlayOneShot(Tombs.GetComponent<AudioSource>().clip);
            Tombs.GetComponent<Animator>().SetTrigger("Tocar");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Platillo.GetComponent<AudioSource>().PlayOneShot(Platillo.GetComponent<AudioSource>().clip);
            Platillo.GetComponent<Animator>().SetTrigger("Tocar");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            BomBoDer.GetComponent<AudioSource>().PlayOneShot(BomBoDer.GetComponent<AudioSource>().clip);
            BomBoDer.GetComponent<Animator>().SetTrigger("Tocar");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bombo.GetComponent<AudioSource>().PlayOneShot(Bombo.GetComponent<AudioSource>().clip);
            Bombo.GetComponent<Animator>().SetTrigger("Tocar");
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            interactuando = false;
            salir();
        }
    }
}
