using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class MenuScript : MonoBehaviour
{
    
    public Text warningNameLengthText;

    public InputField playerInputName;
    
    public void Awake()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            PersistantData.instance.LoadCurrentName();
            playerInputName.text = PersistantData.instance.playerName;
        }
    }

    public void Update()
    {
        if (playerInputName.text.Length < 2 || playerInputName.text.Length > 6)
        {
            warningNameLengthText.gameObject.SetActive(true);
        }
        else
        {
            warningNameLengthText.gameObject.SetActive(false);
            PersistantData.instance.SetName();
            PersistantData.instance.SaveCurrentName();
        }

    }

    public void StartNewGame()
    {
        if (playerInputName.text.Length >= 2 && playerInputName.text.Length <= 6)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            warningNameLengthText.color = Color.red;
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
