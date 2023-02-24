/*Objeto "Nivel" dentro de cada escena.

Cuando un gameObject con el tag player entra en el trigger del gameObject que tiene este script
se genera el cambio de escena a la escena con el nombre asignado en el public string
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string escena; //escena que se va a cargar

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(escena);
        }
    }
}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string escena; //escena que se va a cargar
    private GameObject inventario; // gameObject que contiene el inventario

    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Inventario");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DontDestroyOnLoad(inventario);
            SceneManager.LoadScene(escena);
        }
    }
}

*/