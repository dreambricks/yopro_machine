using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPlayerExistsWindow : MonoBehaviour
{

    public Button backBtn;
    [SerializeField] private CTAWindow ctaWindow;

    public float totalTime = 25;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(()=> GotoCTAWindow());
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
            ctaWindow.Show();
            //WindowTimer.SendLog(StatusEnum.AcaoConcluida);
            Hide();
        }
    }


    private void GotoCTAWindow()
    {
        ctaWindow.Show();
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
