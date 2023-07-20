using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float velocidadBala;
    private Vector2 direccion;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = direccion * velocidadBala;
    }

    public void SetDirection(Vector2 direccion)
    {
        this.direccion = direccion;
    }
}

