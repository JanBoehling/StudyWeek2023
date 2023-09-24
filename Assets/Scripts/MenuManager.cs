using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(int sceneId) => SceneManager.LoadScene(sceneId);
    public void ExitGame() => Application.Quit();
    public void OpenLink(string link) => Debug.Log($"Opening {new Uri(link)}");
}
