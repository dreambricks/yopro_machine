using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ThankWindow : MonoBehaviour
{

    [SerializeField] private CTAWindow ctaWindow;
    [SerializeField] private Player player;
    public Button finalize;

    private string xmlString;
    private string folderOutput;
    private string dataToEncrypt;
    private string fileName;
    private string stringEncrypted;


    public float totalTime = 25;
    private float currentTime;

    void Start()
    {
        finalize.onClick.AddListener(()=> GoToMainWindow());
    }

    private void OnEnable()
    {
        currentTime = totalTime;

        EncryptData();

        StartCoroutine(RunMachine());
    }

    private void Update()
    {
        Countdown();
    }

    public void Countdown()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            ctaWindow.Show();
            WindowTimer.SendLog(StatusEnum.AcaoConcluida);
            Hide();
        }
    }

    private void GoToMainWindow()
    {
        player.Hide();
        WindowTimer.SendLog(StatusEnum.AcaoConcluida);
        ctaWindow.Show();
        Hide();
    }

    private void EncryptData()
    {
        DateTime today = DateTime.Now;

        string dateTimeToFormat = today.ToString("yyyyMMdd HH:mm:ss");

        string formattedDate = today.ToString("MM/dd/yyyy");

        string formattedDateTime = FormatDateTimeString(dateTimeToFormat);

        player.timePlayed = formattedDate;

        XmlDocument xmlDoc = new XmlDocument();
        string xmlFolder = Path.Combine(Application.persistentDataPath, "keys");

        if (!Directory.Exists(xmlFolder))
        {
            Directory.CreateDirectory(xmlFolder);
        }

        string xmlPath = Path.Combine(xmlFolder, "public_key.xml");
        Debug.Log(xmlPath);

        xmlDoc.Load(xmlPath);

        xmlString = xmlDoc.OuterXml;

        Debug.Log("XML as string:\n" + xmlString);

        dataToEncrypt = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}\n",player.firstName, player.lastName, player.email, player.phone, player.campaingName, player.brandName, player.alreadyDrink, player.playExercise, player.timePlayed);
        Debug.Log(dataToEncrypt);

        stringEncrypted = RSAUtil.Encrypt(xmlString, dataToEncrypt);

        folderOutput = Path.Combine(Application.persistentDataPath, "user_data");

        if (!Directory.Exists(folderOutput))
        {
            Directory.CreateDirectory(folderOutput);
        }

        string telHash = player.phone.GetHashCode().ToString();

        PlayerBL playerbl = PlayerBL.LoadFromJson();

        if (playerbl != null)
        {
            playerbl.AddTelList(telHash);
            PlayerBL.SaveToJson(playerbl);
        }
        else
        {
            PlayerBL playerblnew = new PlayerBL();
            playerblnew.AddTelList(telHash);
            PlayerBL.SaveToJson(playerblnew);
        }

        fileName = string.Format("{0}_{1}.enc", telHash, formattedDateTime);

        string fullPath = Path.Combine(folderOutput, fileName);
        Debug.Log(fullPath);

        using (StreamWriter writer = new StreamWriter(fullPath))
        {
            writer.Write(stringEncrypted);
        }


    }

    private string FormatDateTimeString(string input)
    {
        DateTime parsedDateTime;
        if (DateTime.TryParseExact(input, "yyyyMMdd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out parsedDateTime))
        {
            string formatted = parsedDateTime.ToString("yyyyMMdd_HHmmss");
            return formatted;
        }
        else
        {
            Debug.LogError("Failed to parse input date and time.");
            return string.Empty;
        }
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    IEnumerator RunMachine()
    {
        string url = "http://localhost/dispensegift"; // Substitua pela URL desejada

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log($"Error: {www.error}");
            }
            else
            {
                Debug.Log($"Received: {www.downloadHandler.text}");
            }
        }
    }
}
