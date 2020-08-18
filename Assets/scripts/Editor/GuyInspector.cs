using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(mainchar))]

public class GuyInspector : Editor
{
    mainchar _target;

    public override void OnInspectorGUI()
    {
        if (_target == null) _target = target as mainchar;

        if (GUILayout.Button("데미지")) _target.OnDmg(1000);

        base.OnInspectorGUI();

    }
}
