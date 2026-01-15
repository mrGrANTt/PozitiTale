using System;
using System.IO;
using UnityEngine;

public static class Vareables
{
    public static float Sound = 1f;
    public static float Music = 1f;
    public static bool FirstRun = true;
    public static bool TalkWith = false;

    public static string path = Application.persistentDataPath 
        + "/player.json";

    [Serializable]
    public class Data
    {
        public float Sound;
        public float Music;
        public bool FirstRun;

        public Data(float sound, float music, bool firstRun, bool talkWith)
        {
            Sound = sound;
            Music = music;
            FirstRun = firstRun;
        }
        public Data() : this(1f, 1f, true, false) { }
    }

    public static void loadData() 
    {
        Data newData;
        try {
            string data = File.ReadAllText(path);
            newData = JsonUtility.FromJson<Data>(data);
        } catch (Exception e) {
            Debug.LogException(e);
            Debug.Log("Generate default values");
            newData = new Data();
        }

        Sound = newData.Sound;
        Music = newData.Music;
        FirstRun = newData.FirstRun;
    }

    public static void saveData()
    {
        Data data = new Data(Sound, Music, FirstRun, TalkWith);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }
}
