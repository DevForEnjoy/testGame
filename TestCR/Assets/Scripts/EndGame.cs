using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponent<MoveChicken>().endGame.SetActive(true);
            other.gameObject.GetComponent<MoveChicken>().Die();
            other.gameObject.GetComponent<MoveChicken>().enabled = false;
            other.gameObject.GetComponent<MoveChicken>().cameraMove.enabled = false;
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.GetComponent<Transform>().DOScale(new Vector3(1.5f,0.09f,1), 0.3f);

            audioSource.clip = audioClip;
            audioSource.loop = false;
            audioSource.volume = 1;
            audioSource.Play();
        }
        
    }
}
