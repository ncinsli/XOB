using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProperiesHandler : MonoBehaviour{
    
    [Tooltip("Particle properties")] [SerializeField] private ParticleProperties particleProperties;
    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;
    
    private void Start(){
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;
        mainModule.maxParticles = particleProperties.maxParticles;

        if (particleProperties.onlyOnBackground) 
            gameObject.transform.position = Vector3.forward * 15f;
        else gameObject.transform.position = Vector3.forward * 8f;
    }
}
