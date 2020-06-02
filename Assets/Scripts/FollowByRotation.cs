using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowByRotation : MonoBehaviour{

    [SerializeField] private Transform target;
    private void FixedUpdate(){
        transform.rotation = target.rotation;
    }
}
