using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadScene(int sceneId) => SceneManager.LoadScene(sceneId);
    public void ExitGame() => Application.Quit();
    public void OpenLink(string link) => System.Diagnostics.Process.Start(new Uri(link).ToString());
}
