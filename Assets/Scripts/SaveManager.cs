using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private string saveFilePath;

    public int currentLevel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            saveFilePath = Application.persistentDataPath + "/save.dat";
            LoadGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(saveFilePath);

        SaveData data = new SaveData();
        data.currentLevel = currentLevel;

        formatter.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(saveFilePath, FileMode.Open);

            SaveData data = (SaveData)formatter.Deserialize(file);
            currentLevel = data.currentLevel;

            file.Close();
        }
        else
        {
            currentLevel = 2;
        }
    }
}

[System.Serializable]
class SaveData
{
    public int currentLevel;
}
