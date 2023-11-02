using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int moedas;
    public static GameController instance;

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

        if(moedas == 3 && SceneManager.GetActiveScene().name == "FaseUm")
        {
            moedas = 0;
            SceneManager.LoadScene("FaseUm");
        }
        else if (moedas == 3 && SceneManager.GetActiveScene().name != "FaseUm")
        {
            moedas = 0;
            SceneManager.LoadScene("FaseUm");
        }
    }

    public void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SairPartida()
    {
        Application.Quit();
    }
}
