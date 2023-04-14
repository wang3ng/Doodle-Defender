#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(generalTurret))]
public class TurretInspector : Editor
{
    private static List<System.Type> _availableTypes;
    private static GUIContent[] _dropDownOptions;

}

#endif
