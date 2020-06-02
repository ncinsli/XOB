using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParticleProperties", menuName = "Properties/ParticleProperties", order = 0)]
public class ParticleProperties : ScriptableObject {
    [Tooltip("OnlyOnBackground")] public bool onlyOnBackground;
    [Tooltip("Max particles")] [Range(0,2000)] public int maxParticles;
    [Tooltip("Particle gravity speed")] [Range(0,1)] public float gravitySpeed;
}