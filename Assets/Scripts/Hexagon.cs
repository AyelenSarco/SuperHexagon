using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    private GameManager manager;
    private Vector3 scaleChange;
    private Vector3 targetScale;
    [SerializeField] float speed = 1f;
    public bool rotate = false;
    [SerializeField] float speedRotation = 20f;

    
    void Start(){
        scaleChange = new Vector3 (-0.01f, -0.01f, -0.01f);
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Vector3 newScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, speed * Time.deltaTime);
        this.transform.localScale = newScale;
        CheckRotation();
        DestroyHexagon(newScale);
       
    }


    private void CheckRotation(){
        if (this.rotate) {
            transform.RotateAround(transform.position, Vector3.forward, speedRotation * Time.deltaTime);
        }
    }

    private void DestroyHexagon(Vector3 newScale){
        if (newScale.x <= 0.011f) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ( other.tag == "Center"){
            // Debug.Log("Hexagon collides with Center");
            manager.AddScore();
        }
    }


    public void SetRotateBool(bool rotateBoolean, float direction){
        this.rotate = rotateBoolean;
        if (rotate) {
            speedRotation = speedRotation * direction;
        }
        
    }


}

