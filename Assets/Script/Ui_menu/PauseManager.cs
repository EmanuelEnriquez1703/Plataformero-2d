using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject cuadroPausa;
    public bool enPausa;
    public void PausarButtom()
    {
        enPausa = true;
        cuadroPausa.SetActive(true);
    }

    public void continuar()
    {
        enPausa = false;
        cuadroPausa.SetActive(false);
    }
}
