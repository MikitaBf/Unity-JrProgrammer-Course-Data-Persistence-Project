using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] GameObject noNameWarning;
    [SerializeField] TextMeshProUGUI highScoreText;

    public void Start()
    {
        highScoreText.text = $"High score: {DataManager.HighScore}";

        if (DataManager.Name != "")
        {
            nameInput.text = DataManager.Name;
        }
    }

    // Start playing
    public void StartGame()
    {
        if (nameInput.text != "")
        {
            DataManager.Name = nameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            StartCoroutine(ShowNoNameWarning());
        }
    }

    IEnumerator ShowNoNameWarning()
    {
        noNameWarning.SetActive(true);
        yield return new WaitForSeconds(2);
        noNameWarning.SetActive(false);
    }

    // Quit the app
    public void QuitApp()
    {
        DataManager.Instance.SaveInfo();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
