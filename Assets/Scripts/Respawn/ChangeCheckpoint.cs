using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(checkpoint);
    }
}
