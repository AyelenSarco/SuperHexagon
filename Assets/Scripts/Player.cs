using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    public Transform target;
    [SerializeField] private float speed = 35f;

    void Start()
    {
        
    }

    void Update() {
        CheckInput();    
    }

    private void CheckInput(){
        
        if(Input.GetKey(KeyCode.A)){
            transform.RotateAround(target.transform.position, target.forward, 20 * Time.deltaTime * speed);
        } else if( Input.GetKey(KeyCode.D)) {
            transform.RotateAround(target.transform.position, target.forward, -20 * Time.deltaTime * speed);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        manager.OnLose();
    }
}

