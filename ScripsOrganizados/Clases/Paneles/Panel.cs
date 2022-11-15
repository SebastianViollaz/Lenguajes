using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    [SerializeField] protected GameObject CanvasPanel;
    [SerializeField] protected GameObject PanelDatos;
    [SerializeField] protected GameObject Player;
    // Start is called before the first frame update

    public abstract void Mostrar();

    public abstract void Ocultar();
}
