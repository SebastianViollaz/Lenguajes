using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAvanzar : MonoBehaviour
{
    [SerializeField] GameObject PanelDeAvanze   ;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PanelEstadisticas;
    // Start is called before the first frame update
    public void Avanzar()
    {
        PanelDeAvanze.SetActive(false);
        PanelEstadisticas.SetActive(true);
        Player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
