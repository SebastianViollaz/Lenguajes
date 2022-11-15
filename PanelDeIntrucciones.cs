using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PanelDeIntrucciones : Panel
{


    [SerializeField] Bateria Bateria;
    public override void Mostrar()
    {

         CanvasPanel.SetActive(true);
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
        
        
    }




    // Update is called once per frame
    public override void Ocultar()
    {
        CanvasPanel.SetActive(false);
        Bateria.EmpezarAtocar();

    }
}
