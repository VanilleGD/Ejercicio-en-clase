using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject balaRafaga;
    [SerializeField] GameObject balaM;
    [SerializeField] GameObject arma;
    [SerializeField] float fireRate;

    GameObject BalaMatrix;

    float minX, maxX, minY, maxY;
    float NextFire = 0;
    float NextRafaga = 0;
    bool CambiarBala = true;

    // Start is called before the first frame update
    void Start()
    {
        new Vector2(1, 1);
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 puntoMinParaY = Camera.main.ViewportToWorldPoint(new Vector2(0,0.7f));

        maxX = esquinaSupDer.x - 0.7f;
        maxY = esquinaSupDer.y - 0.7f;
        minX = puntoMinParaY.x + 0.7f;
        minY = puntoMinParaY.y;

        Debug.Log(maxX);
        Debug.Log(maxY);
        Debug.Log(minX);
        Debug.Log(minY);


        //World space= el espacio de juego
        //screen space= La resolucion
        //viewport= la camara
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        if(CambiarBala)
        {
            Disparar();
        }
        else
        {
            DispararRafaga();
        }

        if (Time.timeScale == 0.5f)
        {
            DisparoMatrix();
        }
        


        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(CambiarBala)
            {
                CambiarBala = false;
            }
            else
            {
                CambiarBala = true;
            }
        }
        
    }

    void DispararRafaga()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= NextRafaga && Time.timeScale==1)
        {
            Debug.Log("Disparando rafaga");

            Instantiate(balaRafaga, arma.transform.position, transform.rotation);
            NextRafaga = Time.time + (fireRate/3);
        }
        


    }

    void Disparar()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= NextFire && Time.timeScale == 1)
        {
            Instantiate(bala, arma.transform.position, transform.rotation);
            NextFire = Time.time + fireRate;
        }

    }

    public void DisparoMatrix()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= NextFire)
        {
            Instantiate(balaM, arma.transform.position, transform.rotation);
            NextFire = Time.time + fireRate;
        }

    }


    void MoverNave()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * Time.deltaTime * Speed, movV * Time.deltaTime * Speed);
        //Aca se mueve
        transform.Translate(movimiento);

        //Aca se verifica la posicion
        if (transform.position.x > maxX)
        {
            //devuelvase a maxX
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x < minX)
        {
            //devuelvase a minX
            transform.position = new Vector2(minX, transform.position.y);
        }

        if (transform.position.y > maxY)
        {
            //devuelvase a maxY
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y < minY)
        {
            //devuelvase a minY
            transform.position = new Vector2(transform.position.x, minY);
        }
    }
     

    








}
