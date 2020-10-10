using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int record;
    public int coins;
    public bool sound;
    public SaveData(int record,int coins, bool sound)
    {
        this.record = record;
        this.sound = sound;
        this.coins = coins;
    }
}
