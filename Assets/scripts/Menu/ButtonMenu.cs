using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(CustomButton))]
public class UIButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CustomButton t = (CustomButton)target;
    }
}
