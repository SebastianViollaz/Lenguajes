using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamarasMenu : MonoBehaviour
{
    GameObject[] Cameras;
    [SerializeField]float tiempo;
    bool Reproduciendo;
    void Start()
    {
        Cameras = new GameObject[gameObject.transform.childCount];
        int i = 0;
        foreach (Transform camara in transform)
        {
            Cameras[i] = camara.gameObject;
            Cameras[i].gameObject.SetActive(false);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Reproduciendo == false)
        {
            StartCoroutine(PasajeDeCamaras());

        }
    }
    IEnumerator PasajeDeCamaras()
    {
        Reproduciendo = true;
        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i].SetActive(true);
            yield return new WaitForSeconds(tiempo);
            if(i == Cameras.Length - 1)
            {
                Cameras[0].SetActive(true);
            }
            else
            {
                Cameras[i + 1].SetActive(true);
            }
            Cameras[i].SetActive(false);

        }
        Reproduciendo = false;

    }
}
