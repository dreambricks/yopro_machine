using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KBController : MonoBehaviour
{
    public Button btn;

    public KeyboardScript kb;

    void Start()
    {
        btn.onClick.AddListener(()=> HideKeyboard());
    }

    private void HideKeyboard()
    {
        kb.GetComponent<Animator>().Play("Down");
    }


}
