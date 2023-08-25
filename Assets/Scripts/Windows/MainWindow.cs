using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{

    [SerializeField] private TermsWindow termsWindow;
    public Button advanceButton;

    void Start()
    {
        advanceButton.onClick.AddListener(() => GoToTerms());   
    }

    private void GoToTerms()
    {
        termsWindow.Show();
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
