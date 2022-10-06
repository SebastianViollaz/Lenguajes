using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControllerSounds : MonoBehaviour
{
    //Variables visibles en el inspector
    [Header("Audio Clips")]
    
    [SerializeField] private AudioClip[] walkSounds;//Lista de sonidos de pasos

    [SerializeField] private AudioClip JumpSound;//Sonido de salto (podria ser una lista pero hay que hacer mas complejo el codigo)
    
    [SerializeField] private AudioClip LandingSound;//Sonido de aterrizaje


    [Header("Sound Setings")]

    [Range(0, 1)] [SerializeField] private float StepTimeOffset = 0; //Tiempo que tiene que transcurrir para ejecutar el siguiente paso

    [Range(0,1)][SerializeField] private float AirTimeNedded; //Tiempo que tiene uqe trascurrir en el aire para reproducir el sonido de aterrizaje


    //Variable no visibles en el inspector
    private float StepTime = 0; //Me ayuda a saber cuanto tiempo transcurrio desde el ultimo paso

    private float AirTime; //Me ayuda a saber cuanto tiempo llevo en el aire

    private FirstPersonController Player; //Variable que hace referencia al Scrip "FirsPersonController
    
    private CharacterController PlayerCh; //Variable que hace referencia al charactercontroller de mi perosnje
    
    private AudioSource Audio; //Variable que hace referencia al AudioSource de mi personaje, me ayuda a reproducir audios



    //Esto se reproduce antes del void Start
    private void Awake()
    {
        try
        {
            Player = GetComponent<FirstPersonController>();

            Audio = GetComponent<AudioSource>();

            PlayerCh = GetComponent<CharacterController>();
        }
        catch
        {
            print("El personaje nececita CharacterController, Audio Source y el scrip de FirstPersonController");
        }
    
        //Asigno a las variables los componentes correspondientes
       
    }
    void Start()
    {
        AirTime = 0; 
        
        StepTime = 0;

        //Setteo el tiempo que estoy en el aire y el tiempo que llevo con los pasos en 0

    }

    void Update()
    {
        if (PlayerCh.velocity.magnitude > 0 && !Player.Midle_Air)//Si me muevo y no estoy en el aire
        {
            

            StepTime += Time.deltaTime;//Empiezo a contar el tiempo que llevo caminando
            
            if (Audio.isPlaying == false && StepTime > StepTimeOffset)//Si no estoy reproduciuoendo otro audio y el tiempo que llevo caminando supera el de la configuracion
            {
                SetAudioVelocity(); //Elijo con la velocidad con la que voy a reproducir el audio

                Audio.clip = walkSounds[Random.Range(0, walkSounds.Length)];//Elijo un audio de pasos al azar para ejecutar
                
                Audio.PlayOneShot(Audio.clip);//Reproduzco el audio
                
                StepTime = 0;//Reseteo el tiempo que llevo si nhacer un paso
            
            }
        }
        else //Si estoy en el aire
        {
            StepTime = 0;//Seteo en 0 el tiempo que llevo sin hacer un paso

            Audio.pitch = 1;//La velocidad de reproduccion es 1 (normal)

            if (Player.Jump)//Si mi jugador salta
            {
                Audio.Stop();//Paro todos los audios

                Audio.clip = JumpSound;//Elijo el clip de audio de salto

                Audio.Play();//Lo reproduzco

                Player.Jump = false; //Seteo salto en falso
                //El objetivo de Jump o salto es saber unicamnete el frame en el que aprieto el boton para saltar, por eso lo vuelvo a poner en falso

            }
            if (Player.Midle_Air)//Si mi jugador esta en el aire
            {
                StartCoroutine(Landing());//Reproduzco esta tarea (Mirar abajo del todo)

            }
        }
    }

    void SetAudioVelocity()
    {
        if (Player.MoveSpeed <= Player.WalkSpeed)//Si mi jugador esta caminando
        {
            Audio.pitch = 1;//La velociudad es 1
        }
        else
        {
            if(Player.MoveSpeed <= Player.RunSpeed)///Si estoy corriendo
            {
                Audio.pitch = 1.5f;//La velocidad es  1.5 (Un poco mas rapido)
            }
        }
    }
    IEnumerator Landing() //Tarea de aterrizaje
    {
        AirTime += Time.deltaTime;//Cuento cuanto tiempo llevo en el aire
        
        yield  return new WaitUntil(() => !Player.Midle_Air);//Espeo hasta qeu toque el piso
        
        if (AirTime > AirTimeNedded)//Si pase mucho tiempo en el aire
        {
        
            Audio.clip = LandingSound;//Elijo el sonido de caida
            
            Audio.Play();//Reproduzco el sonido
        }
        
        AirTime = 0;//Air time vuelve a 0 (Porque ya toque el piso)
        
    }

}
