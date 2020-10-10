using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartGame : MonoBehaviour
{
    public GameObject plan;
    public CameraMove cameraMove;
    public MoveChicken moveChicken;
    public GameObject cav;
    public OffText offText;
    float timer=1f;
    int loop = 0;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && loop == 0) 
        {
            plan.transform.DOMoveX(10, 1, false);
            timer = 1;
            loop = 1;
        }
        if (timer<0 && loop ==1) 
        {           
            plan.SetActive(false);
            plan.transform.DOMoveX(-7.2f, 1, false);
            cameraMove.enabled = true;
            moveChicken.enabled = true;
            cav.SetActive(true);
            offText.check = true;
            Destroy(this);
        }
    }
}
