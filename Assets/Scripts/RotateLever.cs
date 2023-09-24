using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RotateLever : MonoBehaviour
{
    [SerializeField] private Transform leverHandle;
    [SerializeField] private Transform leverPivot;
    [SerializeField] private float rotateAngle;
    [SerializeField] private bool lever;

    public bool Lever { get => lever; }

    public void ToggleLever()
    {
        leverHandle.transform.RotateAround(leverPivot.position, Vector3.forward, lever ? rotateAngle : -rotateAngle);
        lever = !lever;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(RotateLever))]
public class TestRotateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (RotateLever)target;

        base.OnInspectorGUI();

        if (GUILayout.Button("Toggle Lever"))
        {
            script.ToggleLever();
        }
    }
}
#endif
