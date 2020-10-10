using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadScene : MonoBehaviour
{
    public SaveSystem save;
    public GameObject endPanel;
    public GameObject endtext;
    public GameObject conv;
    public Transform cam;
    public float timer = 2f;
    bool end = false;
    public void LaodScene()
    {
        conv.SetActive(false);
        endPanel.SetActive(true);
        endtext.SetActive(true);
        endPanel.transform.DOMoveX(-0.4f+cam.position.x,1.5f);
        endtext.transform.DOMoveX(-0.8f+cam.position.x,1.5f);
        end = true;
        save.Save();
        
    }
    private void Update()
    {
        if (end) 
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0) SceneManager.LoadScene(0);
    }
}
