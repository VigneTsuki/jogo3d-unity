using UnityEngine;

public class Jogador : MonoBehaviour
{
    public CharacterController oCharacterController;
    public float velocidadeDoJogador;
    public Rigidbody rb;
    public float gravidadeDoJogador;
    private Vector3 velocidadeDeQueda;

    void Update()
    {
        MoverJogador();
        AplicarGravidade();
    }

    private void MoverJogador()
    {
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");

        Vector3 movimentoFinal = transform.right * movimentoX + transform.forward * movimentoZ;

        oCharacterController.Move(movimentoFinal * velocidadeDoJogador * Time.deltaTime);
    }

    private void AplicarGravidade()
    {
        velocidadeDeQueda.y += gravidadeDoJogador * Time.deltaTime;
        oCharacterController.Move(velocidadeDeQueda * Time.deltaTime);
    }
}
