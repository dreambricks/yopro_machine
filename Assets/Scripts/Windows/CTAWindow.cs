using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTAWindow : MonoBehaviour
{

    [SerializeField] MainWindow mainWindow;
    public Button advance;

    // Start is called before the first frame update
    void Start()
    {
        advance.onClick.AddListener(() => GoToMainWindow() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GoToMainWindow()
    {
        mainWindow.Show();
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
