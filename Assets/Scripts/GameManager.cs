using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private MainWindow mainWindow;
    [SerializeField] private TermsWindow termsWindow;
    [SerializeField] private RegisterWindow registerWindow;
    [SerializeField] private AlreadyDrinkWindow alreadyDrink;
    [SerializeField] private SportsWindow sportsWindow;
    [SerializeField] private ThankWindow thankWindow;

    private void Start()
    {
        mainWindow.Show();
        termsWindow.Hide();
        registerWindow.Hide();
        alreadyDrink.Hide();
        sportsWindow.Hide();
        thankWindow.Hide();
    }
}
