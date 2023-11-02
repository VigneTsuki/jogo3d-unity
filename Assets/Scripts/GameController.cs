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

    public void DescontarMoeda()
    {
        moedas--;
        if(moedas <= 0 && SceneManager.GetActiveScene().name == "FaseUm")
        {
            SceneManager.LoadScene("FaseUm");
        }
        else if (moedas <= 0 && SceneManager.GetActiveScene().name != "FaseUm")
        {
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
