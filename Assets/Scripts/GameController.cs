using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int moedas;
    public static GameController instance;
    public int vidas;

    /// <summary>
    /// Não perder o controller ao resetar a tela
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vidas = 3;
        moedas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            ReiniciarFase();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SairPartida();
        }
    }

    public void ContarMoedas()
    {
        moedas+=1;

        if(moedas == 10 && SceneManager.GetActiveScene().name == "FaseUm")
        {
            moedas = 0;
            SceneManager.LoadScene("FaseDois");
        }
        else if (moedas == 10 && SceneManager.GetActiveScene().name != "FaseUm")
        {
            moedas = 0;
            SceneManager.LoadScene("Vitoria");
        }
    }

    public void DescontarVida()
    {
        vidas -= 1;
        if(vidas == 0)
        {
            moedas = 0;
            SceneManager.LoadScene("Gameover");
        }
        else
        {
            ReiniciarFase();
        }
    }

    public void ReiniciarFase()
    {
        moedas = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SairPartida()
    {
        moedas = 0;
        Application.Quit();
    }
}
