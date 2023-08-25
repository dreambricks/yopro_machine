using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlreadyDrinkWindow : MonoBehaviour
{

    [SerializeField] private ThankWindow thankWindow;
    public Button adavance;


    void Start()
    {
        adavance.onClick.AddListener(() => GoToThankWindow());    
    }

    private void GoToThankWindow() 
    {
        thankWindow.Show();
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
