using System;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ThankWindow : MonoBehaviour
{

    [SerializeField] private CTAQWindow ctaWindow;
    [SerializeField] private Player player;
    public Button finalize;

    private string xmlString;
    private string folderOutput;
    private string dataToEncrypt;
    private string fileName;
    private string stringEncrypted;

    void Start()
    {
        finalize.onClick.AddListener(()=> GoToMainWindow());
    }

    private void OnEnable()
    {
        EncryptData();
    }

    private void GoToMainWindow()
    {
        player.Hide();
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

        fileName = string.Format("{0}.enc", formattedDateTime);

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
}
