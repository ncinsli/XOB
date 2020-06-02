using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMechanism : MonoBehaviour{
    void Activate(){}
    void DeActivate(){}
    bool isActive{get; set;}
}
