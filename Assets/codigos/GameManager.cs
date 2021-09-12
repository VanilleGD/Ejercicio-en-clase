using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] int NumAnimals;

    public Animal PuntosDeVida2;

    float TeclaCamaraLenta, TiempoDeCámaraLenta = 3;
    int Oportunidades = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        Matrix();

    }

    //este se encanrga de que cargue la siguiente escena a la del menu

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    


    void PauseGame()
    {
        //pausar y despausar el juego o cambiarle la velocidad al juego, como matrix
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Matrix ()
    {
        if (Input.GetKeyDown(KeyCode.X) && Oportunidades >=1)
        {
            Time.timeScale = 0.5f;
            TeclaCamaraLenta = Time.time + TiempoDeCámaraLenta;

            

        }

        if(TeclaCamaraLenta <= Time.time && Time.timeScale == 0.5f)
        {
            Time.timeScale = 1;

            Oportunidades--;

          
        }



    }


    public void CaptureAnimal()
    {
        NumAnimals = NumAnimals - 1;
        if(NumAnimals < 1)
        {
            //ganó
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
    }

}
