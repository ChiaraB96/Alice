using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other) {
        player.transform.position = respawnPoint.transform.position;
    }


}
