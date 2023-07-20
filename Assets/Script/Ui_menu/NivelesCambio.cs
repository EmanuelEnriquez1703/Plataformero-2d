using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelesCambio : MonoBehaviour
{
    public void nivel_1()
    {
        SceneManager.LoadScene(1);
    }
    public void nivel_2()
    {
        SceneManager.LoadScene(2);
    }
}
