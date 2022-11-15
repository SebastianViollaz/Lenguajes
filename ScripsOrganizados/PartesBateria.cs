using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PartesBateria : MonoBehaviour
{

    public Animator Anim;
    [SerializeField] AudioClip SonidoPrincipal;
    [SerializeField] AudioClip SonidoSecundario;
    // Start is called before the first frame update
    AudioClip GetSoundToPlay()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && SonidoSecundario!= null)
        {
            return SonidoSecundario;
        }
        return SonidoPrincipal;
    }
    public void Interactuar(AudioSource AudioParent)
    {
        AudioParent.PlayOneShot(GetSoundToPlay());
        Anim.SetTrigger("Tocar");
    }
}
