using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OffText : MonoBehaviour
{
    public CameraMove cameraMove;
    public bool check;
    void Update()
    {
        if (check && Input.touchCount > 0)
        {
            this.gameObject.GetComponent<Transform>().DOMoveX(6, 2, false);
            cameraMove.start = true;
        }
        if (this.gameObject.GetComponent<Transform>().position.x >= 3)
        {
            gameObject.SetActive(false);
            this.gameObject.GetComponent<Transform>().DOMoveX(-7f, 3, false);
            Destroy(this);
        }
    }
}
