using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour{

    [SerializeField] [Range(0f,0.01f)] private float delta = 0.05f;
    [SerializeField] private Transform player;

    private Vector3 path;

    private void Start(){
        
    }

    private void Update(){
        path = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, path, delta);
    }
}
