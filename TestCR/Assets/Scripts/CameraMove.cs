using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public Vector3 cameraDis;
    public float high;
    public float zLength = 0.002f;
    public bool start = false;
    private void Start()
    {
        cameraDis = transform.position - Player.transform.position;
        high = transform.position.y;
    }
    void Update()
    {
        if(start)
        if (Player.transform.position.x > 5 || Player.transform.position.x < -6)
        {
            transform.position = new Vector3(transform.position.x > 0 ? 6 : -6, high, Player.transform.position.z + cameraDis.z);
        }
        else
        {
                if (transform.position.z+2 < Player.transform.position.z + cameraDis.z)
                {
                    transform.DOMove(new Vector3(Player.transform.position.x + cameraDis.x, high, Player.transform.position.z + cameraDis.z),1f,false);
                }
                else
                {
                    transform.position = new Vector3(Player.transform.position.x + cameraDis.x, high, transform.position.z + zLength);
                }
                if (transform.position.z>Player.transform.position.z) 
                {
                    Player.gameObject.GetComponent<MoveChicken>().endGame.SetActive(true);
                    Player.gameObject.GetComponent<MoveChicken>().Die();
                    Player.gameObject.GetComponent<MoveChicken>().enabled = false;
                    Destroy(Player.gameObject.GetComponent<Rigidbody>());
                    start = false;
                }

            }

    }
}
