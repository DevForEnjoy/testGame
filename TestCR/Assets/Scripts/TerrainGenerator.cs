using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TerrainGenerator : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(-2.25f, 0, -4);
    public Transform chickenTrans;
    public float currentZ;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();
    public List<GameObject> terrainsOnGame = new List<GameObject>();
    public Text stepNow;
    public Text stepRec;
    public int steps=0;
    public int record;
    public GameObject coin;
   
    private void Start()
    {
        genStartTerrain();
    }
    private void Update()
    {
        stepRec.text ="РЕКОРД :"+ record.ToString();
        if (steps > record) record = steps;
        if(terrainsOnGame.Count>0)
        if (terrainsOnGame[0].transform.position.z+10 < currentZ) 
        {
            terrainsOnGame.RemoveAt(0);
        }
    }
    public void checkStep() 
    {
        if (currentZ < chickenTrans.position.z)
        {
            SpawnT();
            currentZ = chickenTrans.position.z;
            steps++;
            stepNow.text = steps.ToString();
        }
    }
    int terrainIndex = 0;
    public void SpawnT() {
        int hT = Random.Range(0, terrains.Count);
        terrainIndex++;
        currentPosition.z++;
        terrains[hT].gameObject.name = "terrain "+terrainIndex;
        GameObject t = Instantiate(terrains[hT], currentPosition, Quaternion.identity);
        genCoins(currentPosition);
        terrainsOnGame.Add(t);
        if (terrainsOnGame.Count-20 > 10) 
        {
            Destroy(terrainsOnGame[0]);
            terrainsOnGame.RemoveAt(0);
        }
    }
    private void genCoins(Vector3 pos) 
    {
        int countC = Random.Range(0, 2);
        for (int i = 0; i < countC; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-4, 4), 0.1f, pos.z),Quaternion.identity);
        }
    }
    private void genStartTerrain() 
    {
        for (int i = 0; i < 5; i++)
        {
            terrainIndex++;
            currentPosition.z++;
            terrains[0].gameObject.name = "terrain " + terrainIndex;
            GameObject t = Instantiate(terrains[0], currentPosition, Quaternion.identity);
            terrainsOnGame.Add(t);
        }
        for (int i = 0; i < 28; i++)
        {
            int hT = Random.Range(0, terrains.Count);
            terrainIndex++;
            currentPosition.z++;
            terrains[hT].gameObject.name = "terrain " + terrainIndex;
            GameObject t = Instantiate(terrains[hT], currentPosition, Quaternion.identity);
            genCoins(currentPosition);
            terrainsOnGame.Add(t);
        }
    }
    
}
