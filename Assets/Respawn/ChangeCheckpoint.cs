using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;
    
    void OnCollisionEnter(Collision plyr)
    {
        if (plyr.gameObject.tag == "Player")
            Destroy(checkpoint);
    }
}
