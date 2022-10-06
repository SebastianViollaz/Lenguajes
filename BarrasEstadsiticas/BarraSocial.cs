using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraSocial : BarraEstadistica
{

    // Update is called once per frame
    void Update()
    {
        this.BarraSlider.value = Player.VidaSocial;
    }
}
