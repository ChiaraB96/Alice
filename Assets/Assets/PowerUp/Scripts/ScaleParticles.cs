using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour {
    ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void Update () {
        var main = ps.main;
        main.startSize = transform.lossyScale.magnitude;
    }
}
