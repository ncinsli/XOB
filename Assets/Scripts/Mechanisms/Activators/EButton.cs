using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EButton : AActivator{

    [SerializeField] private float PushForce;
    public event Action OnActivatorTriggered;    
    public event Action OnActivatorDeTriggered;
    private bool isActive;

    private void OnTriggerEnter2D(Collider2D collider) {
        PushForce += collider.GetComponent<Rigidbody2D>().mass;
        if (!isActive && PushForce > 0.9f){
            Debug.Log("Activating"); 
            StartCoroutine(DropDown());
            if (OnActivatorTriggered != null) OnActivatorTriggered();
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        PushForce -= collider.GetComponent<Rigidbody2D>().mass;
        if (isActive && PushForce < 1f){ 
            Debug.Log("Deactivating");
            StartCoroutine(DropUp());
            if (OnActivatorDeTriggered != null) OnActivatorDeTriggered();
            isActive = false;
        }
    }

    private IEnumerator DropDown(){
        for (int i = 0; i < 7; i++){
            transform.position += Vector3.down * 0.015f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator DropUp(){
        for (int i = 0; i < 7; i++){
            transform.position += Vector3.up * 0.015f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
