using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class SaveSystem : MonoBehaviour
{
    public MoveChicken moveChicken;
    public TerrainGenerator terrainGenerator;
    public SoundOff soundOff;
    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/SVDT.fun"))
        {
            try
            {
                SaveDT(new SaveData(0, 0, true));
            }
            catch (System.Exception e) 
            {
                print(e.ToString());
            }
        }
        else {
            try
            {
                SaveData s = LoadDT();
                moveChicken.coins = s.coins;
                terrainGenerator.record = s.record;
                soundOff.SoundActive(s.sound);
            }
            catch (System.Exception e) 
            {
                print("ext:" + e.ToString());
            }
        }
    }
    public void Save() 
    {
        SaveData s = new SaveData(terrainGenerator.record, moveChicken.coins,soundOff.audioListener.enabled);
        SaveDT(s);
    }
    public static void SaveDT(SaveData save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SVDT.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(save.record,save.coins,save.sound);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadDT()
    {
        string path = Application.persistentDataPath + "/SVDT.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            print("save file not found in" + path);
            return null;
        }
    }
}
