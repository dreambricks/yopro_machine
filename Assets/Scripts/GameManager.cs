using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private MainWindow mainWindow;
    [SerializeField] private TermsWindow termsWindow;
    [SerializeField] private RegisterWindow registerWindow;
    [SerializeField] private AlreadyDrinkWindow alreadyDrink;
    [SerializeField] private PlayExerciseWindow playExerciseWindow;
    [SerializeField] private ThankWindow thankWindow;
    [SerializeField] private CTAWindow cTAWindow;
    [SerializeField] private ErrorPlayerExistsWindow errorPlayerExistsWindow;
    [SerializeField] private NotWorkingWindow notWorkingWindow;

    private void Start()
    {
        cTAWindow.Show();
        mainWindow.Hide();
        termsWindow.Hide();
        registerWindow.Hide();
        alreadyDrink.Hide();
        playExerciseWindow.Hide();
        thankWindow.Hide();
        errorPlayerExistsWindow.Hide();
        notWorkingWindow.Hide();
    }
}
