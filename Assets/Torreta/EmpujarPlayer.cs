using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujarPlayer : MonoBehaviour
{
    [SerializeField] int speed;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(speed * Vector3.left, ForceMode.Impulse);
        }
    }
}
