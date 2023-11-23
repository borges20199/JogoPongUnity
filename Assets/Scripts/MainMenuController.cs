using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    // Start is called before the first frame update
    void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();

        if(lastWinner !="")
            uiWinner.text = "último vencedor:" + lastWinner;

        else
            uiWinner.text = "";
    }

}