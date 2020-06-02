using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Must be abstract
public abstract class AActivator : MonoBehaviour{
    public event Action OnActivatorTriggered;
    public event Action OnActivatorDeTriggered;
}
