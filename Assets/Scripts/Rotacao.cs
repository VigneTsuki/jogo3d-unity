using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour
{
    // referência ao gameObject "Personagem FPS"
    public Transform corpoDoJogador;

    // controla a velocidade com que giramos a câmera
    public float sensibilidadeDoMouse;

    // armazena e controla a rotação horizontal do jogador
    private float rotacaoX;

    // Start is called before the first frame update
    void Start()
    {
        // trava o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // roda o método "RotacionarJogador"
        RotacionarJogador();
    }

    private void RotacionarJogador()
    {
        // armazena os movimentos "Horizontais" e "Verticais" do mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * sensibilidadeDoMouse * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensibilidadeDoMouse * Time.deltaTime;

        // calcula a rotação x do mouse e a limita
        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        // rotaciona a câmera e o corpo do jogador (fazendo com que ele "encare" a direção da câmera)
        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        corpoDoJogador.Rotate(Vector3.up * mouseX);
    }
}
