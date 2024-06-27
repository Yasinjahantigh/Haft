using System;
using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private SQLiteConnection _connection;

    // Path to the database
    private string DatabasePath
    {
        get
        {
#if UNITY_EDITOR
            return Application.dataPath + "/Database/haft_database.db";
#elif UNITY_ANDROID
            return Application.persistentDataPath + "/haft_database.db";
#elif UNITY_IOS
            return Application.persistentDataPath + "/haft_database.db";
#else
            return Application.dataPath + "/haft_database.db";
#endif
        }
    }

    void Start()
    {
        _connection = new SQLiteConnection(DatabasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        _connection.CreateTable<PlayerData>();
    }

    public void InsertData(PlayerData data)
    {
        _connection.Insert(data);
    }

    public List<PlayerData> GetAllData()
    {
        return _connection.Table<PlayerData>().ToList();
    }

    public PlayerData GetDataById(int id)
    {
        return _connection.Table<PlayerData>().FirstOrDefault(x => x.Id == id);
    }

    public void UpdateData(PlayerData data)
    {
        _connection.Update(data);
    }

    public void DeleteData(PlayerData data)
    {
        _connection.Delete(data);
    }

    public string Get_value_By_key(string key)
    {
        var playerData = _connection.Table<PlayerData>().FirstOrDefault(x => x.key == key);
        if (playerData != null)
        {
            return playerData.value;
        }
        else
        {
            return "-1"; // peydaa nashod
        }
    }

}

public class PlayerData
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string key { get; set; }
    public string value { get; set; }
}
