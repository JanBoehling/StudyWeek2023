#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject futureScene;
    [SerializeField] private GameObject pastScene;

    public bool IsPaused { get; private set; }
    public bool IsFutureActive { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        futureScene.SetActive(IsFutureActive);
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;

        Cursor.lockState = IsPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
    }

    public void ToggleFutureScene()
    {
        futureScene.SetActive(!IsFutureActive);
        pastScene.SetActive(IsFutureActive);

        IsFutureActive = !IsFutureActive;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (GameManager)target;

        base.OnInspectorGUI();

        if (GUILayout.Button("Toggle Time"))
        {
            script.ToggleFutureScene();
        }
    }
}
#endif
