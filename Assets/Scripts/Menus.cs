using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name == "Gameover")
        {
            GameController.instance.moedas = 0;
            GameController.instance.vidas = 3;
            SceneManager.LoadScene("FaseUm");
        }
        
    }
}
