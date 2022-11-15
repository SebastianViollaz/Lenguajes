using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEstadistica : MonoBehaviour
{
    public Slider BarraSlider;
    public  PlayerStads Player;
    public Image Fill;
    // Start is called before the first frame update
    void Start()
    {
        BarraSlider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (BarraSlider.value > 50)
        {
            Fill.color = Color.green;
        }
        else if (BarraSlider.value > 20)
        {
            Fill.color = Color.yellow;

        }
        if (BarraSlider.value < 20)
        {
            Fill.color = Color.red;

        }
    }
}
