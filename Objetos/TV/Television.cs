using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Television : Objeto_Interactivo
{
    [SerializeField] VideoPlayer Video;
    [SerializeField] Light luz;

    private void Start()
    {

        luz.enabled = false;    
    }

    // Update is called once per frame
    public override void Interactuar()
    {
        if(Video.isPlaying == false)
        {
            Video.Play();
            luz.enabled = true;

        }
        else
        {
            Video.Stop();
            luz.enabled = false;
        }
    }
}
