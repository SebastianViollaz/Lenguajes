using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendir : MonoBehaviour
{
    [SerializeField] PlayerStads PlayerStads;
    [SerializeField] GameObject PanelRendir;
    [SerializeField] GameObject PanelEstadisticas;
    // Start is called before the first frame update
    public void Examen()
    {
        Debug.Log("Rendir");
        PanelRendir.SetActive(true);
        PlayerStads.gameObject.SetActive(false);
        PanelEstadisticas.SetActive(false);
        PlayerStads.Energia=PlayerStads.Energia-40;
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
    }
}
