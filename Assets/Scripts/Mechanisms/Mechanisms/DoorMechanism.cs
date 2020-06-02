using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class DoorMechanism : AMechanism{
    public bool isActive{get; set;}
    [SerializeField] private float yStart;
    [SerializeField] private float doorSize;
    public AActivator activator;

    private void Start(){
        activator.OnActivatorTriggered += Activate;
        activator.OnActivatorDeTriggered += DeActivate;
        doorSize = transform.localScale.y;
        yStart = transform.position.y;
        Debug.Log("Must be assigned now");
    }

    public void Activate(){
        Debug.Log("Activated door mechanism");
        transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(transform.localScale.y));
        transform.position = new Vector3(transform.position.x, yStart, transform.position.z);
        StartCoroutine(Activator());
    }

    public void DeActivate(){
        Debug.Log("Deactivated door mechanism");
        transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(transform.localScale.y));

        StartCoroutine(DeActivator());
    }


    private IEnumerator Activator(){
        for (int i = 0; i < 24; i++){
            transform.localScale += Vector3.down * (doorSize / 24);
            transform.localScale = new Vector2(transform.localScale.x, Mathf.Clamp(transform.localScale.y, -doorSize, doorSize));
            yield return new WaitForSeconds(0.001f);
        }
    }

    private IEnumerator DeActivator(){
        for (int i = 0; i < 24; i++){
            transform.localScale += Vector3.down * (doorSize / 24);
            transform.localScale = new Vector2(transform.localScale.x, Mathf.Clamp(transform.localScale.y, -doorSize, doorSize));
            yield return new WaitForSeconds(0.001f);
        }
    }
}
