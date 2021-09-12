using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] int PuntosDeDano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int DarPuntosDeDano()
    {
        return PuntosDeDano;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;
        
        Destroy(this.gameObject);
        


    }
}
