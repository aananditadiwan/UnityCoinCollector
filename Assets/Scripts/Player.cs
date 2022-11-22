using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;


    private bool jumpKeyWasPressed; 
    private float horizontalInput;

    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space) == true) {
            jumpKeyWasPressed=true;
        }

        horizontalInput= Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {

        rigidbodyComponent.velocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().velocity.y,0 );  

        // if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1) {
        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length ==0) {
            return ;
        }
        if( jumpKeyWasPressed) {
            rigidbodyComponent.AddForce(Vector3.up * 7 , ForceMode.VelocityChange);
            jumpKeyWasPressed = false ; 
        }

    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.layer == 7){
            CoinCounter.coinAmount +=1;
            Destroy(other.gameObject);
        }
    }
}
