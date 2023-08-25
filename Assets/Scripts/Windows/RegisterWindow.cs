using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterWindow : MonoBehaviour
{
    [SerializeField] private AlreadyDrinkWindow alreadyDrinkWindow;

    public InputField nome;
    public InputField email;
    public InputField tel;

    public Button advance;

    private void Start()
    {
        advance.onClick.AddListener(()=> GoToAleadyDrink());
    }

    private void OnEnable()
    {
        nome.text = "";
        email.text = "";
        tel.text = "";
    }

    private void GoToAleadyDrink()
    {
        alreadyDrinkWindow.Show();
        Hide();
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
