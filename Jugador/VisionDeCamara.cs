using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDeCamara : MonoBehaviour
{

    [SerializeField] float distancia;
    [SerializeField] LayerMask PlayerLayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            Debug.DrawRay(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, distancia, PlayerLayer))
            {
                try
                {

                    Ejecuar_Interaccion(hitInfo.collider.gameObject.GetComponent<Objeto_Interactivo>());

                }
                catch
                {
                    Debug.Log(hitInfo.collider.name);

                }
            }
        }
        

    }
    void Ejecuar_Interaccion(Objeto_Interactivo Objeto)
    {
        Objeto.Interactuar();
    }
}
