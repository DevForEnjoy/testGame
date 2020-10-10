using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSpawn : MonoBehaviour
{
    public bool Right;
    public Vector3 startSpawn;
    public GameObject board;
    public float timer = 0;
    private float speed;
    private void Start()
    {
        speed = Random.Range(0.2f, 0.4f);
        Right = randomBool();
        if (Right)
        {
            startSpawn = new Vector3(-6, 0, transform.position.z);
        }
        else startSpawn = new Vector3(6, 0, transform.position.z);
    }
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            GameObject doneBoard = new GameObject();
            doneBoard.name = "doneboard";
            doneBoard.transform.position = startSpawn;
            doneBoard.transform.rotation = Quaternion.identity;
            int len = Random.Range(1, 5);
            for (int i = 0; i < len; i++)
            {
                GameObject g = Instantiate(board, new Vector3((Right ? -1 : 1) * i, 0, 0), Quaternion.identity);
                g.transform.SetParent(doneBoard.transform, false);
            }
            doneBoard.AddComponent<board>();
            doneBoard.GetComponent<board>().Right = Right;
            doneBoard.GetComponent<board>().speed = speed;

            timer = Random.Range(3,5);
        }
    }
    bool randomBool() 
    {
        return Random.Range(0, 2) == 1;
    }
}
