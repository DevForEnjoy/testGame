using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public bool Right;
    public Vector3 startSpawn;
    public List<GameObject> cars;
    public float timer = 0;
    private float speed;
    private void Start()
    {
        speed = Random.Range(0.2f, 0.4f);
        Right = randomBool();
        if (Right)
        {
            startSpawn = new Vector3(-10, 0, transform.position.z);
        }
        else startSpawn = new Vector3(10, 0, transform.position.z);
    }
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else 
        {
            int rCar = Random.Range(0, cars.Count);
            cars[rCar].GetComponent<board>().Right = Right;
            cars[rCar].GetComponent<board>().speed = speed;
            Instantiate(cars[rCar], startSpawn, Quaternion.identity);
            timer = Random.Range(5, 7);
        }
    }
    bool randomBool()
    {
        return Random.Range(0, 2) == 1;
    }
}
