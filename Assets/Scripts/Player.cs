using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour{

    [SerializeField] private PlayerProperties playerProperties;
    [SerializeField] private Transform navigatorRight; //Для независимого движения вправо
    [SerializeField] private Transform[] objectsToFollowPlayer;
    private Vector2 direction;
    private KeyCode[] KeyCodes = {KeyCode.A, KeyCode.D, KeyCode.Space}; //A, D, Space
    private KeyCode[] KeyRotate;
    private float speed;     
    private bool onGround;
    private Vector2 jumpForce;
    private Collider2D collider;
    private Rigidbody2D rigidbody;
    private Animator animationController;

    private void Start(){
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();  
        animationController = GetComponent<Animator>();  
         
        jumpForce = playerProperties.jumpPower;
        speed = playerProperties.speed;   
        KeyCodes = playerProperties.KeyCodes;   
        KeyRotate = playerProperties.KeyRotate;    
    }

    private float GetCustomAxis(){
        if (Input.GetKey(KeyCodes[0])) return -1f;
        if (Input.GetKey(KeyCodes[1])) return 1f;
        else return 0f;
    }

    private void FixedUpdate(){
        direction = (navigatorRight.position - transform.position).normalized;
        playerProperties.jumpPower = CrossVectorLeft(direction);
        jumpForce = new Vector2(-direction.y, direction.x);
        rigidbody.position += direction * speed * GetCustomAxis();
    }

    private Vector2 CrossVectorLeft(Vector2 origin) => new Vector2(origin.y, origin.x); 

    private void Update(){
        if (Input.GetKeyDown(KeyRotate[0])) StartCoroutine(RotateViewing(-1f));
        if (Input.GetKeyDown(KeyRotate[1])) StartCoroutine(RotateViewing(1f));


        if (Input.GetKeyDown(KeyCodes[2]) && onGround){
            rigidbody.velocity += jumpForce * 10f;
            animationController.SetInteger("AnimationId", 1);
        }
        if (Input.GetKeyUp(KeyCodes[2])){
            animationController.SetInteger("AnimationId", 0);
        }
    }

    private Vector2 chooseGravity(Vector2 gravity){
        if (gravity == new Vector2(0f, 9.81f)) return new Vector2(-9.81f, 0f); 
        else if (gravity == new Vector2(-9.81f, 0f)) return new Vector2(0f, -9.81f); 
        else if (gravity == new Vector2(9.81f, 0f)) return new Vector2(0f, 9.81f); 
        else if (gravity == new Vector2(0f, -9.81f)) return new Vector2(9.81f, 0f); 
        else return Vector2.zero;
    }

    private IEnumerator RotateViewing(float direction){
        float rotateStep = 0.6f * direction / Mathf.Abs(direction);
        for (int i = 0; i < 150; i++){
            Camera.main.transform.Rotate(0f, 0f, rotateStep);
            transform.Rotate(0f, 0f, rotateStep); 
            yield return new WaitForSeconds(0.0001f);
        }
        Physics2D.gravity = direction * chooseGravity(Physics2D.gravity);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) => onGround = true;
    private void OnCollisionExit2D(Collision2D collision) => onGround = false;
}
