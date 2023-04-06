using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public float spawnTime = 5f;
    [SerializeField] public float sleepTime = 1f;
    [SerializeField] GameObject hexagonPrefab;
    [SerializeField] Vector2 position = Vector2.zero;

    private float direction = 1;

    private bool rotateHexagon;
   
    void Start()
    {
        rotateHexagon = false;
        InvokeRepeating("SpawnHexagon", sleepTime ,spawnTime);
    }

    public void SpawnHexagon(){
        GameObject newHexagon = Instantiate(hexagonPrefab, position, Quaternion.identity);
        newHexagon.transform.rotation = Quaternion.Euler(0,0,Random.Range(0f,360f));

        // Rotation
        newHexagon.GetComponent<Hexagon>().SetRotateBool(rotateHexagon,direction);
        
        // Random Color
        SpriteRenderer h_SpriteRenderer = newHexagon.GetComponent<SpriteRenderer>();
        Color randomColor = Color.HSVToRGB(Random.Range(0f,01),0.5f,0.9f);
        h_SpriteRenderer.color = randomColor;
    }

    public float GetSpawnTime() {
        return this.spawnTime;
    }
    
    public void SetSpawnTime(float otherSpawnTime){
        
        spawnTime = otherSpawnTime;
        CancelInvoke();
        InvokeRepeating("SpawnHexagon", sleepTime ,spawnTime);
    }

    public void SetRotate(bool rotate){
        this.rotateHexagon = rotate;
        this.direction = -direction;
    }

}
