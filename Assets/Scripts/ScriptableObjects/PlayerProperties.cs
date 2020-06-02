using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName = "Properties/PlayerProperties", order = 0)]
public class PlayerProperties : ScriptableObject{
    [Tooltip("Keycodes")] public KeyCode[] KeyCodes = {KeyCode.A, KeyCode.D, KeyCode.Space};
    [Tooltip("Keycodes for rotating")] public KeyCode[] KeyRotate = {KeyCode.Q, KeyCode.R};
    [Tooltip("Jump vector")] public Vector2 jumpPower;
    [Tooltip("Speed")] public float speed; 
    [Tooltip("LightPower")] public float lightPower;
}
