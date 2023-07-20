using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelManager : MonoBehaviour
{
    /*este script cuando acemos click en la imagen donde le pusimos el buttom y 
    añadimos este script a un game object vacio para darselo al buttom y seleccionar la 
    funcion del script*/
    public void irNiveles()
    {
        SceneManager.LoadScene(3);
    }

    public void ButtomExit(){
        Application.Quit();
    }
}
