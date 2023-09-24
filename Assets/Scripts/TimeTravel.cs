#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravel : MonoBehaviour
{
    [SerializeField] private GameObject futureScene;
    [SerializeField] private GameObject pastScene;

    public bool IsFutureActive { get; private set; }

    private void Awake()
    {
        futureScene.SetActive(IsFutureActive);
    }

    public void ToggleFutureScene()
    {
        futureScene.SetActive(!IsFutureActive);
        pastScene.SetActive(IsFutureActive);

        IsFutureActive = !IsFutureActive;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(TimeTravel))]
public class TimeTravelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (TimeTravel)target;

        base.OnInspectorGUI();

        if (GUILayout.Button("Toggle Time"))
        {
            script.ToggleFutureScene();
        }
    }
}
#endif
