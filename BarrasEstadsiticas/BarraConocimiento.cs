using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraConocimiento : BarraEstadistica
{
    // Update is called once per frame
    void Update()
    {
        this.BarraSlider.value = Player.Conocimiento;
    }
}
