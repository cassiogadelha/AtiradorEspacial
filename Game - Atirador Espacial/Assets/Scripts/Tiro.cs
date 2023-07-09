using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    Rigidbody2D meuRB;
    [SerializeField] float velocidade;

    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        meuRB.velocity = new Vector2(0f, velocidade);    
    }
}
