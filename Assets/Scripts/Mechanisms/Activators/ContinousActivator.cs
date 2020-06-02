using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Михаилу: Этот скрипт пока принял пастафарианство и не должен работать :D
[RequireComponent(typeof(Collider2D))]
public class ContinousActivator : AActivator{
/*
//  Always null because don't need those events (just for interface implementation)
    public event Action OnActivatorTriggered;
    public event Action OnActivatorDeTriggered;
    [SerializeField] private IMechanism pluggedMechanism;
    [SerializeField] private float timeActivating;
    private AActivator activatorAttached; //Activator, attached to mechanism
    private float timeLeft;

    private void Start(){
        timeLeft = timeActivating;
        //Disables connection between activator and mechanism & activates it anyway
        activatorAttached = pluggedMechanism.activator;
        pluggedMechanism.activator = null;
        pluggedMechanism.Activate();
    }


    private void FixedUpdate(){
        if (timeLeft > 0f) timeLeft -= Time.deltaTime;
        if (timeLeft < 0f && timeLeft > -1f){
            pluggedMechanism.DeActivate();
            pluggedMechanism.activator = activatorAttached;
            timeLeft = -2f;
        }
    }*/
}
