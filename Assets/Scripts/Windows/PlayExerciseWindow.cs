using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayExerciseWindow : MonoBehaviour
{

    [SerializeField] private ThankWindow thankwindow;
    [SerializeField] private Player player;    

    public Button adavance;
    public Button[] buttons;
    private string answer;
    private int selectedBtn;
    public Text error;


    void Start()
    {
        adavance.onClick.AddListener(() => GoToThankWindow());

        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => Check(buttonIndex));
        }
    }

    private void OnEnable()
    {
        error.gameObject.SetActive(false);
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
    }

    private void GoToThankWindow()
    {

        if (buttons[0].GetComponent<Image>().enabled == true)
        {
            answer = "1 ou 2 vezes";
            player.playExercise = answer;
            thankwindow.Show();
            Hide();
        }
        else if (buttons[1].GetComponent<Image>().enabled == true)
        {
            answer = "3 a 5 vezes";
            player.playExercise = answer;
            thankwindow.Show();
            Hide();
        }
        else if (buttons[2].GetComponent<Image>().enabled == true)
        {
            answer = "+5 vezes";
            player.playExercise = answer;
            thankwindow.Show();
            Hide();
        }
        else if (buttons[3].GetComponent<Image>().enabled == true)
        {
            answer = "Não pratico atividades físicas";
            player.playExercise = answer;
            thankwindow.Show();
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

