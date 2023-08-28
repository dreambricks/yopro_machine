using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    // Start is called before the first frame update
    public string firstName;
    public string lastName;
    public string email;
    public string phone;
    public string campaingName;
    public string brandName;
    public string alreadyDrink;
    public string freeYopro;
    public string date;

    public Player() { }

    private void OnEnable()
    {
        firstName = "";
        lastName = "";
        email = "";
        phone = "";
        campaingName = "";
        brandName = "";
        alreadyDrink = "";
        freeYopro = "";
        date = "";
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
