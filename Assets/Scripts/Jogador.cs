using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade;
    public Rigidbody rb;
    private float movimentoX;
    private float movimentoZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarJogador();
    }

    private void MovimentarJogador()
    {
        movimentoX = Input.GetAxis("Horizontal") * velocidade;
        movimentoZ = Input.GetAxis("Vertical") * velocidade;

        rb.AddForce(movimentoX, 0f, movimentoZ);
    }
}
