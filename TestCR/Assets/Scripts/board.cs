using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class board : MonoBehaviour
{
    public bool Right;
    public Vector3 curPos;
    public float time =-1;
    public float speed;
    private void Start()
    {
        curPos = transform.position;
        if (this.gameObject.tag == "car")if(curPos.x<0) {
            transform.DORotate(new Vector3(0, 90, 0), 1, RotateMode.Fast);
        }
        else transform.DORotate(new Vector3(0, -90, 0), 1, RotateMode.Fast);
    }
    void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (Right)
            {
                curPos.x += speed;
                this.transform.DOMoveX(curPos.x, 1f, false);
                time = 0.25f;
            }
            else
            {
                curPos.x -= speed;
                this.transform.DOMoveX(curPos.x, 1f, false);
                time = 0.25f;
            }
            if (curPos.x > 15 || curPos.x < -16) Destroy(this.gameObject);
        }
        
    }
}
