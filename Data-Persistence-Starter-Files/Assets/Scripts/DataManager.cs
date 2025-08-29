using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public string playerName;
    public int bestScore;

    public static DataManager Instance
    { 
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<DataManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject("DataManager");
                    instance = go.AddComponent<DataManager>();
                    DontDestroyOnLoad(go);
                }
            }

            return instance;
        }
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);


        LoadUserRecord();
    }

    private void OnDestroy()
    {
        if(instance==this)
        {
            instance = null;
        }
    }


    [System.Serializable]
    class UserData
    {
        public string playerName;
        public int bestScore;
    };


    public void SaveUserRecord(in string name, in int score)
    {
        UserData data = new UserData();
        data.playerName = name;
        data.bestScore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/usersavefile.json" , json);

    }


    public void LoadUserRecord()
    {
        string path = Application.dataPath + "/usersavefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);

            playerName = data.playerName;
            bestScore = data.bestScore;
        }
    }

}
