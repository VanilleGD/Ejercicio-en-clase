using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] bool movingRight;
    [SerializeField] int PuntosDeVida;

    float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            Vector2 movimiento = new Vector2(Speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-Speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }


        if (transform.position.x >= maxX)
        {
            //va a hacer esto (quiero que se mueva a la izq)
            movingRight = false;

        }
        else if (transform.position.x <= minX)
        {
            //de lo contrario haga esto (quiero que se mueva a la der)
            movingRight = true;
        }
    }

    //para que se destruya con la bala
    //tiene que estar fuera del update para que funcione y de la opción

    private void OnCollisionEnter2D(Collision2D collision)
    {
         GameObject objeto = collision.gameObject;

        //este código se va a ejecutar en cada frame que el detecte una collision entre el animal y cualquier otra cosa que tenga collaider
        string etiqueta = objeto.tag;

        if (etiqueta == "disparo")
        {
            int puntos = collision.gameObject.GetComponent<bullet>().DarPuntosDeDano();
            PuntosDeVida = PuntosDeVida - puntos;

            if(PuntosDeVida<1)
            {
                (GameObject.Find("GameManager").GetComponent<GameManager>()).CaptureAnimal();
                Destroy(this.gameObject);
            }

        }

    }
}
   
