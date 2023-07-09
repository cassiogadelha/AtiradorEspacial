using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    float velocidade = 5f;

    float tempoEntreTiros = 0f;
    float cronometroTiros;

    [SerializeField] GameObject tiroSimples;
    [SerializeField] Transform pontoDeCriacao;

    void Start()
    {
        cronometroTiros = 0.2f;
    }

    void Update()
    {
        if(tempoEntreTiros >= 0f) tempoEntreTiros -= Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2 (horizontal, vertical);
        movement.Normalize();
        transform.Translate(movement * Time.deltaTime * velocidade);

        ChecarLimites();
        Tiro();
    }

    private void Tiro()
    {
        if(Input.GetButton("Fire1"))
        {
            if (tempoEntreTiros <= 0f)
            {
                Instantiate(tiroSimples, transform.position, Quaternion.identity);
                tempoEntreTiros = cronometroTiros;
            }
        }
    }

    private void ChecarLimites()
    {
        if (transform.position.x > 8.3f)
        {
            transform.position = new Vector2(8.3f, transform.position.y);
        }
        if (transform.position.x < -8.3f)
        {
            transform.position = new Vector2(-8.3f, transform.position.y);
        }
        if (transform.position.y > 4.4f)
        {
            transform.position = new Vector2(transform.position.x, 4.4f);
        }
        if (transform.position.y < -4.4f)
        {
            transform.position = new Vector2(transform.position.x, -4.4f);
        }
    }
}
