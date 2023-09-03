using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RegisterWindow : MonoBehaviour
{
    [SerializeField] private AlreadyDrinkWindow alreadyDrinkWindow;
    [SerializeField] private Player player;
    [SerializeField] private CTAWindow cTAWindow;
    [SerializeField] private ErrorPlayerExistsWindow errorPlayerExistsWindow;

    public InputField firstName;
    public InputField email;
    public InputField phone;

    public Text isValidEmailTxt;
    public Text isValidPhoneTxt;
    public Text errorTxt;

    private bool isValidEmail;
    private bool isValidPhone;

    public Button advance;

    public float totalTime = 180;
    private bool resultExists;
    private float currentTime;

    private static int[] validDDDs = {
        11, 12, 13, 14, 15, 16, 17, 18, 19, 21,
        22, 24, 27, 28, 31, 32, 33, 34, 35, 37,
        38, 41, 42, 43, 44, 45, 46, 47, 48, 49,
        51, 53, 54, 55, 61, 62, 63, 64, 65, 66,
        67, 68, 69, 71, 73, 74, 75, 77, 79, 81,
        82, 83, 84, 85, 86, 87, 88, 89, 91, 92,
        93, 94, 95, 96, 97, 98, 99
    };

    private void Start()
    {
        advance.onClick.AddListener(()=> GetRegisterData());
        email.onValueChanged.AddListener(ValidateEmail);
    }

    private void OnEnable()
    {
        currentTime = totalTime;

        isValidEmailTxt.gameObject.SetActive(false);
        isValidPhoneTxt.gameObject.SetActive(false);
        errorTxt.gameObject.SetActive(false);


        firstName.text = "";
        email.text = "";
        phone.text = "";


        isValidEmailTxt.gameObject.SetActive(false);
        isValidPhoneTxt.gameObject.SetActive(false);
        isValidEmail = false;
        isValidPhone = false;
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
            cTAWindow.Show();
            WindowTimer.SendLog(StatusEnum.CadastroNaoConcluido);
            Hide();
        }
    }

    private void GoToAleadyDrink()
    {
        alreadyDrinkWindow.Show();
        Hide();
    }

    private void GetRegisterData()
    {

        if (isValidEmail && isValidPhone && firstName.text != "")
        {
            string fullName = firstName.text;
            string[] nameParts = fullName.Split(' ');

            if (nameParts.Length == 1)
            {
                player.firstName = nameParts[0];
            }
            else
            {
                player.firstName = string.Join(" ", nameParts, 0, nameParts.Length - 1);
                player.lastName = nameParts[nameParts.Length - 1];
            }

            player.email = email.text;
            player.phone = phone.text.Replace("(", "").Replace(")", " ").Replace("-", " ");

            CheckPlayer();
        }
        else
        {
            StartCoroutine(ShowErrorText());
        }
    }

    private void CheckPlayer()
    {
        PlayerBL playerbl = PlayerBL.LoadFromJson();

        if (playerbl != null)
        {
            if (playerbl.telHash.Contains(player.phone.GetHashCode().ToString()))
            {
                ExecuteMethodIfTrue();
            }
            else
            {
                GoToAleadyDrink();
            }
        }
        else
        {
            GoToAleadyDrink();
        }

    }

    private IEnumerator ShowErrorText()
    {
        errorTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        errorTxt.gameObject.SetActive(false);
    }


    private void ValidateEmail(string text)
    {
        if (!IsValidEmail(text))
        {
            isValidEmailTxt.gameObject.SetActive(true);
            isValidEmail = false;
        }
        else
        {
            isValidEmailTxt.gameObject.SetActive(false);
            isValidEmail = true;
        }
    }

    public void ValidatePhone(string text)
    {
        if (!IsPhoneValid(text))
        {
            isValidPhoneTxt.gameObject.SetActive(true);
            isValidPhone = false;
        }
        else
        {
            isValidPhoneTxt.gameObject.SetActive(false);
            isValidPhone = true;
        }
    }

    public static bool IsPhoneValid(string phone)
    {
        string pattern = @"^\(\d{2}\)[89]\d{4}\-\d{4}$";

        if (!Regex.IsMatch(phone, pattern)) return false;

        int ddd = int.Parse(phone.Substring(1, 2));

        return IsDDDValid(ddd);
    }

    public static bool IsDDDValid(int ddd)
    {
        return validDDDs.Contains(ddd);
    }

    public static bool IsValidEmail(string email)
    {

        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        bool isMatch = Regex.IsMatch(email, pattern);

        return isMatch;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    //IEnumerator CheckIfExists()
    //{
    //    string fullUrl = urlExists + player.phone.GetHashCode();
    //    Debug.Log(fullUrl);
    //    using (UnityWebRequest www = UnityWebRequest.Get(fullUrl))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            Debug.LogError($"Error: {www.error}");
    //        }
    //        else
    //        {

    //            bool result = bool.Parse(www.downloadHandler.text);
    //            Debug.Log("RETORNOU " + result);
    //            if (result)
    //            {
    //                Debug.Log("Server returned true, executing another method...");
    //                ExecuteMethodIfTrue();
    //            }
    //            else
    //            {
    //                GoToAleadyDrink();
    //            }
    //        }
    //    }
    //}


    private void ExecuteMethodIfTrue()
    {
        errorPlayerExistsWindow.Show();
        Hide();
    }
    
}
