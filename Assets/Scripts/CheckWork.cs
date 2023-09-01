using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckWork : MonoBehaviour
{
    [SerializeField] private CTAWindow ctaWindow;
    [SerializeField] private NotWorkingWindow notWorkingWindow;

    public int checkIntervalSeconds;
    public string apiUrl;

    private void Start()
    {

        StartCoroutine(Worker());
    }


    IEnumerator Worker()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkIntervalSeconds);

            using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogWarning("Erro na requisição: " + www.error);
                }
                else
                {
                    string response = www.downloadHandler.text;
                    Debug.Log("Resposta da API: " + response);

                    if (response == "yes")
                    {
                        ExecuteMethodIfYes();
                    }
                    else if (response == "no")
                    {
                        ExecuteMethodIfNo();
                    }
                    else
                    {
                        Debug.LogWarning("Resposta não reconhecida: " + response);
                    }
                }
            }

        }
    }

    private void ExecuteMethodIfYes()
    {
        ctaWindow.Show();
        notWorkingWindow.Hide();
    }

    private void ExecuteMethodIfNo()
    {
        notWorkingWindow.Show();
        ctaWindow.Hide();
    }
}
