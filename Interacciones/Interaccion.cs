using UnityEngine;

public class Interaccion : Objeto_Interactivo
{
    [SerializeField] PlayerStads PlayerStads;
    [SerializeField] float ConsumoDeEnergia;
    [Header("Variantes")]
    [SerializeField] float Diversion;
    [SerializeField] float Conocimiento;
    [SerializeField] float VidaSocial;

    [SerializeField] bool Limitar_Usos;
    [SerializeField] int LimiteDeUsos;
    int CantidadDeUsos;

    // Start is called before the first frame update
    public override void Interactuar()
    {
        if(PlayerStads.Energia>= ConsumoDeEnergia)
        {
            if (Limitar_Usos == true)
            {
                if (CantidadDeUsos < LimiteDeUsos)
                {
                    Accion();
                    CantidadDeUsos++;
                }
            }
            else
            {
                Accion();
            }
        }
        else
        {
            Debug.Log("No hay energia");
        }         
    }

    void Accion()
    {
        PlayerStads.Conocimiento += Conocimiento;
        PlayerStads.VidaSocial += VidaSocial;
        PlayerStads.Diversion += Diversion;
        PlayerStads.Energia -= ConsumoDeEnergia;
    }

    public void Set_CantidadDeUsos(int CantidadDeUsos)
    {
        this.CantidadDeUsos = CantidadDeUsos;
    }
}
