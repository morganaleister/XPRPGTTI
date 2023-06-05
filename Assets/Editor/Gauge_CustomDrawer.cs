using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Gauge))]
public class Gauge_CustomDrawer : PropertyDrawer
{
    //GetValues from Gauge class
    SerializedProperty ME, SP_Current, SP_Max;
    float _current, _max;

    //For math use on control drawings
    //private bool
    //mainFoldout = false,
    //eventsFoldout = false;


    private static float lnHeight = EditorGUIUtility.singleLineHeight;
    private static float lblWidth = EditorGUIUtility.labelWidth;


    //private readonly float vspace = 2f;
    //private readonly float hoffset = 22f;
    private float
        currentWidth, currentIndent,
        eventValueHeight, eventStateHeight,
        eventValueExtraHeight, eventStateExtraHeight;

    //private int eventValueSubs, eventStateSubs;
    //---*


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //currentIndent = EditorGUI.IndentedRect(position).x - position.x - vspace;
        Initialize(position, property, label);

        //Draw the PrefixLabel
        //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        GUI.backgroundColor = Color.cyan;


        var totalpos = EditorGUI.PrefixLabel(position, label);
        var ff1pos = new Rect(totalpos.x, totalpos.y, totalpos.width, totalpos.height);

        _current = EditorGUI.FloatField(totalpos, SP_Current.floatValue);
        SP_Current.floatValue = _current;


        //EditorGUILayout.LabelField("/");
        //EditorGUILayout.FloatField(SP_Max.floatValue);



        ////EditorGUI.PropertyField(position, SP_Current);


        //EditorGUI.ProgressBar


        EndProperty();
    }



    private void Initialize(Rect position, SerializedProperty property, GUIContent label)
    {
        //self reference made accesible outside OnGUI
        if (ME == null) ME = property;

        //Set references to serialized properties inside client
        if (SP_Max == null) SP_Max = property.FindPropertyRelative("_max");
        if (SP_Current == null) SP_Current = property.FindPropertyRelative("_current");

        //Check again and throw the right error
        if (SP_Max == null) throw new ArgumentNullException("Couldn't find relative property mainG_max");
        if (SP_Current == null) throw new ArgumentNullException("Couldn't find relative property mainG_current");
        UpdateValues();

        EditorGUI.BeginProperty(position, label, property);
    }

    private void UpdateValues()
    {
        _current = SP_Current.floatValue;
        _max = SP_Max.floatValue;
    }

    private void EndProperty()
    {
        EditorGUI.EndProperty();
    }

}


