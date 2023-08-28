using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThankWindow : MonoBehaviour
{

    [SerializeField] private MainWindow mainWindow;
    [SerializeField] private Player player;
    public Button finalize;

    void Start()
    {
        finalize.onClick.AddListener(()=> GoToMainWindow());
    }
    
    private void GoToMainWindow()
    {
        player.Hide();
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
