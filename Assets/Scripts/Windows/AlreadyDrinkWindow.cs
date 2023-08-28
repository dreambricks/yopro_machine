using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlreadyDrinkWindow : MonoBehaviour
{

    [SerializeField] private FreeYoPRO freeyopro;
    public Button adavance;
    public Button[] buttons;
    private string answer;
    private int selectedBtn;
    public Text error;

    private void OnEnable()
    {
        error.gameObject.SetActive(false);
    }


    void Start()
    {
        adavance.onClick.AddListener(() => GoToThankWindow());

        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => Check(buttonIndex));
        }
    }

    private void Check(int btnindex)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().enabled = false;
            buttons[i].GetComponent<CheckButtonBehavior>().isChecked = false;
        }
        buttons[btnindex].GetComponent<Image>().enabled = true;
        buttons[btnindex].GetComponent<CheckButtonBehavior>().isChecked = true;
        selectedBtn = btnindex;

    }

    private void GoToThankWindow()
    {
      
        if (buttons[0].GetComponent<Image>().enabled == true)
        {
            answer = "Yes";
            freeyopro.Show();
            Debug.Log(answer);
            Hide();
        }
        else if (buttons[1].GetComponent<Image>().enabled == true)
        {
            answer = "No";
            freeyopro.Show();
            Debug.Log(answer);
            Hide();
        }
        else
        {
            error.gameObject.SetActive(true);
        }

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
