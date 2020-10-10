using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoveChicken : MonoBehaviour
{
    public Vector3 currentPositionC = new Vector3();
    public Vector3 currentRotationC;
    public GameObject chiken;
    public bool press = false;
    public Vector2 startPos;
    public Vector2 endPos;
    public bool itMove;
    public TerrainGenerator TerrainGenerator;
    public GameObject board;
    public GameObject endGame;
    public AudioSource audiosor;
    public AudioClip audioClip;
    public CameraMove cameraMove;

    public bool onGrund;
    public float power;
    public float dur;

    public SaveSystem saveSystem;
    public int coins;
    public Text con;
    void Start()
    {
        currentPositionC = chiken.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "board" && board == null)
        {
            board = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ground" || other.gameObject.tag == "board") 
        {
            onGrund = true;
        }
        if (other.gameObject.tag == "coin") 
        {
            coins++;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground" || other.gameObject.tag == "board") 
        {
            onGrund = false;
        }
    }
    void Update()
    {
        con.text = coins.ToString();
        if (board != null && onGrund) 
        {
            transform.position = board.transform.position;
            currentPositionC.x = (int)board.transform.position.x;
            if (currentPositionC.x > 5 || currentPositionC.x < -5) 
            {
                endGame.SetActive(true);
                Die();
                Destroy(gameObject.GetComponent<Rigidbody>());
                transform.DOScale(new Vector3(1.5f, 0.09f, 1), 0.3f);
                transform.DOMoveX(currentPositionC.x>0?10:-10,1,false);
                this.enabled = false;
            }
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    chiken.transform.DOScaleY(0.7f, 0.2f);
                    break;

                case TouchPhase.Moved:
                    itMove = true;
                    endPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    chiken.transform.DOScaleY(1f, 0.2f);
                    MoveChiken();
                    break;
            }
        }
    }
    public void MoveChiken()
    {
        if (onGrund)
        {
            board = null;
            if (itMove)
            {
                int c = get_angle();
                if (c > 45 && c < 135)
                {
                    if (currentPositionC.x < 4)
                    {
                        if (board != null && board.GetComponent<board>().Right) { currentPositionC.x += board.GetComponent<board>().speed*2; }
                        if (board != null && !board.GetComponent<board>().Right) { currentPositionC.x -= board.GetComponent<board>().speed*2; }
                        currentPositionC.x++;
                        currentRotationC.y = 270;
                    }
                }
                else
                if (c > 135 && c < 225)
                {
                    TerrainGenerator.checkStep();
                    currentPositionC.z++;
                    currentRotationC.y = 180;
                }
                else
                if (c > 225 && c < 315)
                {
                    if (board != null && board.GetComponent<board>().Right) { currentPositionC.x -= board.GetComponent<board>().speed*2; }
                    if (board != null && !board.GetComponent<board>().Right) { currentPositionC.x += board.GetComponent<board>().speed*2; }
                    if (currentPositionC.x > -4)
                    {
                        currentPositionC.x--;
                        currentRotationC.y = 90;
                    }
                }
                else
                if (c > 315 || c < 45)
                {
                    currentPositionC.z--;
                    currentRotationC.y = 0;
                }
                itMove = false;
            }
            else
            {
                TerrainGenerator.checkStep();
                currentRotationC.y = 180;
                currentPositionC.z++;
            }
            chiken.transform.DORotate(currentRotationC, 0.2f);
            if (chiken.transform.position != currentPositionC) 
            {
                chiken.transform.DOJump(currentPositionC, power, 1, dur, false);
                audiosor.Play();
            }
        }
    }
    public void Die() 
    {
        saveSystem.Save();
        audiosor.clip = audioClip;
        audiosor.Play();
        cameraMove.start = false;
    }
    int get_angle()
    {
        var x = endPos.x - startPos.x;
        var y = endPos.y - startPos.y;
        if (x == 0) return (y > 0) ? 180 : 0;
        var a = Mathf.Atan(y / x) * 180 / Mathf.PI;
        a = (x > 0) ? a + 90 : a + 270;
        return (int)a;
    }
}
