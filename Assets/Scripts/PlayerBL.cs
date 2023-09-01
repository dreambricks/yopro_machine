using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerBL
{
    public List<string> telHash = new();

    public PlayerBL()
    { 
    }

    public void AddTelList(string phoneNumber)
    {
        telHash.Add(phoneNumber);
    }

    public void RemoveTelList(string phoneNumber)
    {
        telHash.Remove(phoneNumber);
    }

    public List<string> GetTelList()
    {
        return telHash;
    }

    public static void SaveToJson(PlayerBL playerBL)
    {

        string folderJson = Path.Combine(Application.persistentDataPath, "player_bl");

        if (!Directory.Exists(folderJson))
        {
            Directory.CreateDirectory(folderJson);
        }

        string filepath = Path.Combine(folderJson, "PlayerBL");
        
        string jsonData = JsonConvert.SerializeObject(playerBL);

        File.WriteAllText(filepath, jsonData);
    }

    public static PlayerBL LoadFromJson()
    {
        string folderJson = Path.Combine(Application.persistentDataPath, "player_bl");

        if (!Directory.Exists(folderJson))
        {
            return null;
        }
        Debug.Log("Passouaqui");

        string filepath = Path.Combine(folderJson, "PlayerBL");

        string jsonData = File.ReadAllText(filepath);

        PlayerBL player = JsonConvert.DeserializeObject<PlayerBL>(jsonData);

        return player;
    }
}