using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermsWindow : MonoBehaviour
{
    [SerializeField] private MainWindow mainWindow;
    [SerializeField] private RegisterWindow registerWindow;
    public Button accept;
    public Button refuse;
    void Start()
    {
        accept.onClick.AddListener(()=> GotoRegisterWindow());
        refuse.onClick.AddListener(()=> GoToMainWindow());
    }


    private void GoToMainWindow()
    {
        mainWindow.Show();
        Hide();
    }

    private void GotoRegisterWindow()
    {
        registerWindow.Show();
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
