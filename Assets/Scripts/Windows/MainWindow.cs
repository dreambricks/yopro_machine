using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{

    [SerializeField] private TermsWindow termsWindow;
    [SerializeField] private Player player;
    [SerializeField] private CTAWindow cTAWindow;

    public Button advanceButton;

    public float totalTime = 20;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = totalTime;
    }

    void Start()
    {
        advanceButton.onClick.AddListener(() => GoToTerms());   
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
            Hide();
        }
    }

    private void GoToTerms()
    {
        termsWindow.Show();
        player.Show();
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
