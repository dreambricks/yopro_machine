using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermsWindow : MonoBehaviour
{
    [SerializeField] private CTAWindow cTAWindow;
    [SerializeField] private RegisterWindow registerWindow;

    public Button accept;
    public Button refuse;

    public float totalTime = 40;
    private float currentTime;

    void Start()
    {
        accept.onClick.AddListener(()=> GotoRegisterWindow());
        refuse.onClick.AddListener(()=> GoToCTAWindow());
    }

    private void OnEnable()
    {
        currentTime = totalTime;
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
            WindowTimer.SendLog(StatusEnum.TermosNaoAceito);
            Hide();
        }
    }


    private void GoToCTAWindow()
    {
        cTAWindow.Show();
        WindowTimer.SendLog(StatusEnum.TermosNaoAceito);
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
