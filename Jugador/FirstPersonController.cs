using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    //1)Variables que veo en el Inspector de unity (Las puedo cambiar para variar el comportamiento de mi perosnaje)
    [Header("Cam Stads")]

    public float sensibilty = 1;//Guardo en una variable la sensibilidad (velocidad de movimiento de la camara

    public float lookXLimit = 45;//Angulo maximo de vision en la rotacion de camara en el eje X (arriba y abajo)

    [Header("Player Stads")]

    public float WalkSpeed = 2;//Guardo en una varible la velocidad de caminar

    public float RunSpeed = 4;//Guardo en una variable la velociad de correr

    public float JumpForce = 5;//Guardo en un variable la fuerza de salto

    [Range(0, 1)] [SerializeField] private float JumpRate;//Tiempo que tiene que pasar entre salto y salto

    private float GroundedTime;// Variable para saber cuanto tiempo estoy en el suelo (la uso para saber si puedo o no saltar)

    [Header("General")]

    public float gravity = 9.8f;//Guardo en una variable la gravedad (sirve para variar la velociadd de caida)

    public LayerMask GroundLayer;//Guardo en una variable cual es la Layer del suelo (sirve para ejecutar sonidos correctamente)


    //***//

    //2)Variables no visibles en el inspector (No las puedo cambiar desde Unity pero sirven para que funcione correctamente el personaje)

    private CharacterController Player; //Creo una variable con un charcter controller para asi poder controlar el movimiento

    private Transform Player_Camera; //Creo una variable con las trasformaciones de la camara de mi juegador (posion rotacion y escala)(Me sirve para controlar la camara con el mouse)

    private Vector3 movement; //Creo un Vector3 que se referirar a las cornedas en las que se mueve personaje

    [HideInInspector] public float MoveSpeed;//Creo una variable para determinar la velocidad de movimiento actual.

    private float rotationX;//Creo una variable con un valor que me determinara el angulo de rotacion maximo y minimo de mi camara

    [HideInInspector] public bool Jump;//Variable que me ayuda a saber en que momento salto (me ayuda para reproducir los sonidos de salto)

    [HideInInspector] public bool Midle_Air;


    private void Awake()
    {
        Player_Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //Asigno a mi variable la trasformacion de la camara con el tag "Main Camera", por eso es muy imporante que la camara de mi jugador sea la que tiene ese tag "MainCamera"

        Player = GetComponent<CharacterController>();
        //A la variable player le asigno el valor de mi character Controller

    }//Esto re Ejecuta al comiezo de mi juego (antes del void start)
    
    void Start()
    {
        MoveSpeed = WalkSpeed;
        //Seteo la velocidad de movieminto en la velociadd de caminado

        Cursor.lockState = CursorLockMode.Locked;
        //Esta linea es para que mi cursor se bloquee en el centro de mi pantalla

        Cursor.visible = false;
        //Esta linea e spara que mi cursor sea invisible

    }//Esto se reproduce 1 sola vez al comienzo de mi juego



    void Update()
    {
        Movement();
        //Ejecuto la tarea Movement, es la que se encarga de todo el movimiento de mi jugador

        GroundCheck();
 
    }//Esto se reproduce cada frame de mi juego
   
    void Movement()
    {
        MouseMov();
        // Ejecuto la tarea mouse Mov, es la que se encarga unicamnete del movimiento de mi camara

        MoveSpeed = WalkSpeed;
        //Por defecto la velocidad de moviminto va a ser la velocidad de caminar

        if (Player.isGrounded)//Si estoy tocando el piso (is grounded es una funcion unica del charactercontroller, por eso esta bueno crear un perosnaje con charcter controller)
        {
            GroundedTime += Time.deltaTime;
            //Empiezo a contar cuanto tiempo toco el piso

            float Horizontal = Input.GetAxis("Horizontal");
            //Variable que sabe que tecla aprieto en el eje horiznatal (w,s,Flecha Arriba, flecha abajo etc)
            
            float Vertical = Input.GetAxis("Vertical");
            //Lo mismo pero en el eje vertical

            if (Input.GetKey(KeyCode.LeftShift))//Si mantengo apretado el Shift Izquierdo
            {
                MoveSpeed = RunSpeed;
                //Mi velocidad de movimiento es la velocidad de correr

            }

            movement = transform.TransformDirection(new Vector3(Horizontal, 0, Vertical))*MoveSpeed;
            //movement (que es mi direccion de moviemnto) toma los valores de Horizontal(en el eje x) y vertical (en el eje y).
            //Si nos fijamos multiplico la direccion de moviemnto por la velocidad para que asi pueda cambiar segun la tecla que aprieto
            
            if (Input.GetAxisRaw("Jump")==1 && GroundedTime>JumpRate)//Si aprieto el boton para saltar y ademas el tiempo que llevo en el piso (GroundedTime) es mayor al Jump Rate
            {
            
                Jump = true;
                //Jump vale verdadero

                movement.y = JumpForce;
                // la direccion de moviemnto en el eje "y" sera la fuerza de salto

                GroundedTime = 0;
                //Reseteo el contador a 0

            }

        }

        movement.y -= gravity * Time.deltaTime;
        //Esto es para que mi personaje caiga

        Player.Move(movement * Time.deltaTime);
        //Con esta linea mi personaje se mueve en la direccion movement (arriba le doy los valores)
    }
    
    void MouseMov()
    {
        rotationX -= Input.GetAxis("Mouse Y") * sensibilty;
        //Guardo en una variable los valores del mouse del eje Y
        //Se lo llama Rotacion X porque si nosotros en una escena 3D rotamos en el eje x la camara va para arriba y para abajo.

        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //Esto sirve para redonder el valor de rotacion x con un angulo maximo y minimo
        //PUEDEN BORRAR LA LINEA PARA VER QUE SUCEDE, ES LA MEJOR MANERA DE DARSE CUENTA DE LO QUE HACE CADA COSA
        
        Player_Camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //Esta linea se encarga de mover la camara
        
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensibilty, 0);
        //Esta lien se encarga de rotar el perosonje
        //Es importnate rotar el personaje porque sino puedo girar la camara de mi juego pero el perosnaje siempre ira en la misma deireccion
        //Borren esa linea para ver lo que sucede si quieren.

    }//Esto se encarga solamente del moviemento de la camara

    
    void GroundCheck()
    {

        if (Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - Player.height / 3, transform.position.z), Player.radius, GroundLayer))
            //Creo una esfera a los pies de mi personaje. para poder determinar con certeza si estoy o no en el aire
        {

            Midle_Air = false;//Seteo la variable en falto si objetos con la Layer Ground no estan dentro de ella


        }
        else
        {
            Midle_Air = true;//Seteo verdaro si no pasa lo anterior

        }

    }

}


