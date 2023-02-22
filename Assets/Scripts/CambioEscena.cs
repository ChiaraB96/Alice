// Objeto "Nivel" dentro de cada escena.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string escena;
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
    public string escena;
    private GameObject inventario;

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