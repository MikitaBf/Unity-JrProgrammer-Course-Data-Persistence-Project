using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenUIHandler : MonoBehaviour
{
    // Back to main menu button
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
