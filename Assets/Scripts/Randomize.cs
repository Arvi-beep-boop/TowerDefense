using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Randomize : EditorWindow
{
    bool randomZ, randomX, randomY, randomLocZ, randomLocX, randomLocY, randomScale, randomizeLocation;
    float minScale, maxScale, minLocX, maxLocX, minLocY, maxLocY, minLocZ, maxLocZ;
    [MenuItem("Tools/Randomize")]
    static void Init()
    {
        Randomize window = (Randomize)GetWindow(typeof(Randomize));
        window.Show();

    }

    private void OnGUI()
    {

        GUILayout.Label("Randomize object's location, rotation or scale", EditorStyles.boldLabel);


        if (GUILayout.Button("Randomize"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                go.transform.rotation = Quaternion.Euler(GetRandomRotation(go.transform.rotation.eulerAngles));
                if (randomScale)
                {
                    float scaleValue = Random.Range(minScale, maxScale);
                    go.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
                }
               
                if (randomizeLocation)
                {
                    go.transform.localPosition = go.transform.localPosition + GetRandomLocation(go.transform.localPosition);
                }

        
            }


        }


        GUILayout.Label("1. Rotation");
        randomX = EditorGUILayout.Toggle("Randomize X", randomX);
        randomY = EditorGUILayout.Toggle("Randomize Y", randomY);
        randomZ = EditorGUILayout.Toggle("Randomize Z", randomZ);

        GUILayout.Label("2. Scale");
        randomScale = EditorGUILayout.Toggle("Randomize Scale", randomScale);
        if (randomScale)
        {
            minScale = EditorGUILayout.FloatField("Min Scale", minScale);
            maxScale = EditorGUILayout.FloatField("Max Scale", maxScale);
        }


        GUILayout.Label("3. Location");
        randomizeLocation = EditorGUILayout.Toggle("Randomize Location", randomizeLocation);
            if (randomizeLocation)
        {
            randomLocX = EditorGUILayout.Toggle("Randomize X Location", randomLocX);
            randomLocY = EditorGUILayout.Toggle("Randomize Y Location", randomLocY);
            randomLocZ = EditorGUILayout.Toggle("Randomize Z Location", randomLocZ);

            minLocX = EditorGUILayout.FloatField("Min X offset", minLocX);
            maxLocX = EditorGUILayout.FloatField("Max X offset", maxLocX);
            minLocY = EditorGUILayout.FloatField("Min Y offset", minLocY);
            maxLocY = EditorGUILayout.FloatField("Max Y offset", maxLocY);
            minLocZ = EditorGUILayout.FloatField("Min Z offset", minLocZ);
            maxLocZ = EditorGUILayout.FloatField("Max Z offset", maxLocZ);
        }


    }
    private Vector3 GetRandomRotation(Vector3 currentRotation)
    {
        float z = randomZ ? Random.Range(0f, 360f) : currentRotation.z;
        float x = randomX ? Random.Range(0f, 360f) : currentRotation.x;
        float y = randomY ? Random.Range(0f, 360f) : currentRotation.y;
        return new Vector3(x, y, z);
    }
    private Vector3 GetRandomLocation(Vector3 currentLocation)
    {
        float LocZ = randomLocZ ? Random.Range(minLocZ, maxLocZ) : currentLocation.z;
        float LocX = randomLocX ? Random.Range(minLocX, maxLocX) : currentLocation.x;
        float LocY = randomLocY ? Random.Range(minLocY, maxLocY) : currentLocation.y;
        return new Vector3(LocX, LocY, LocZ);
    }
}
