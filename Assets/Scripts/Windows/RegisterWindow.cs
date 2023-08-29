using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class RegisterWindow : MonoBehaviour
{
    [SerializeField] private AlreadyDrinkWindow alreadyDrinkWindow;
    [SerializeField] private Player player;

    public InputField firstName;
    public InputField email;
    public InputField phone;

    public Text isValidEmailTxt;
    public Text isValidPhoneTxt;
    public Text errorTxt;

    private bool isValidEmail;
    private bool isValidPhone;

    public Button advance;

    private void Start()
    {
        advance.onClick.AddListener(()=> GetRegisterData());
        email.onEndEdit.AddListener(ValidateEmail);
        phone.onEndEdit.AddListener(ValidatePhone);
    }

    private void OnEnable()
    {
        isValidEmailTxt.gameObject.SetActive(false);
        isValidPhoneTxt.gameObject.SetActive(false);
        errorTxt.gameObject.SetActive(false);


        firstName.text = "";
        email.text = "";
        phone.text = "";

        isValidEmail = false;
        isValidPhone = false;
    }

    private void GoToAleadyDrink()
    {
        alreadyDrinkWindow.Show();
        Hide();
    }

    private void GetRegisterData()
    {
  
        if (isValidEmail && isValidPhone && firstName.text != "" )
        {
            player.firstName = firstName.text;
            string[] names = firstName.text.Split(" ");
            player.lastName = names.Last();
            player.email = email.text;
            player.phone = phone.text.Replace("(","").Replace(")", " ").Replace("-", " ");

            GoToAleadyDrink();
        }
        else
        {
            StartCoroutine(ShowErrorText());
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

    private void ValidatePhone(string text)
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
        string pattern = @"^\(\d{2}\)\d{5}\-\d{4}$";

        bool isMatch = Regex.IsMatch(phone, pattern);

        return isMatch;
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
}
