using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject flag;
    Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = gameObject.transform.position;    
    }

    void Update()
    {
        gameObject.transform.position = spawnPoint;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            spawnPoint = flag.transform.position;
        }
    }
}
