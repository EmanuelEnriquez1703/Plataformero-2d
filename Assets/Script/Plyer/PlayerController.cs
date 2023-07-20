using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float velocidad;
    private bool orientacionPersonaje = true;
    public GameObject balaPrefab;
    public float tiempoVidaBala;
    public GameObject balaPadre;
    public float tiempoEspera;
    private bool puedoInstanciar = true;
    private int vidas = 3;
    public GameObject[] vidasPlayer;

    private float tiempoEntreColisiones = 20f;
    private float tiempoUltimaColision;
    public PauseManager pauseManager;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        tiempoUltimaColision = -tiempoEntreColisiones;
    }

    private void Update()
    {
        if(pauseManager.enPausa == true)
        {
            return;
        }
        Movimiento();

        if (puedoInstanciar && Input.GetKeyDown(KeyCode.R))
        {
            Disparar();
        }
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * velocidad, rigidBody.velocity.y);
        Orientacion(horizontal);
    }

    private void Orientacion(float inputMovimiento)
    {
        if ((orientacionPersonaje && inputMovimiento < 0) || (!orientacionPersonaje && inputMovimiento > 0))
        {
            orientacionPersonaje = !orientacionPersonaje;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Disparar()
    {
        Vector3 direccion;
        GameObject bala;

        if (transform.localScale.x == 1.0f)
        {
            direccion = Vector2.right;
        }
        else
        {
            direccion = Vector2.left;
        }

        bala = Instantiate(balaPrefab, transform.position + direccion * 0.1f, Quaternion.identity);
        bala.GetComponent<DisparoController>().SetDirection(direccion);
        bala.transform.SetParent(balaPadre.transform);
        Destroy(bala, tiempoVidaBala);

        puedoInstanciar = false;
        StartCoroutine(EsperarParaInstanciar());
    }

    private IEnumerator EsperarParaInstanciar()
    {
        yield return new WaitForSeconds(tiempoEspera);
        puedoInstanciar = true;
    }
    

    public void DesactivarVida(int indice)
    {
        if (indice >= 0 && indice < vidasPlayer.Length)
        {
            vidasPlayer[indice].SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(Time.time >= tiempoUltimaColision + tiempoEntreColisiones)
            {
                vidas--;
                DesactivarVida(vidas);
                if (vidas <= 0)
                {
                    SceneManager.LoadScene(0);
                }
            }
           
        }
    
    }
}

