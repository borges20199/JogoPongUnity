using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    
    private static SaveController _instance;

    public string namePlayer;
    public string nameEnemy;

    private string saveWinnerKey = "SavedWinner";

   

    public static SaveController Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            _instance = FindObjectOfType<SaveController>();

            if (_instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                _instance = singletonObject.AddComponent<SaveController>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public string GetName(bool isPlayer)
    {
        string playerName = isPlayer ? namePlayer : nameEnemy;
        Debug.Log("GetName: " + playerName);
        return playerName;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);

    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }

     public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}