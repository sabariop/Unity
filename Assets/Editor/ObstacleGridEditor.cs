using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObstacleGridEditor : EditorWindow
{
    private ObstacleData obstacleData;
    private GUIStyle buttonStyle;

    [MenuItem("Tools/Obstacle Grid Editor")]
    public static void ShowWindow()
    {
        GetWindow<ObstacleGridEditor>("Obstacle Grid Editor");
    }

    private void OnEnable()
    {
        // Load the obstacle data from the Scriptable Object
        obstacleData = AssetDatabase.LoadAssetAtPath<ObstacleData>("Assets/ObstacleData.asset");
        if (obstacleData == null)
        {
            obstacleData = CreateInstance<ObstacleData>();
            AssetDatabase.CreateAsset(obstacleData, "Assets/ObstacleData.asset");
            AssetDatabase.SaveAssets();
        }
    }

    private void OnGUI()
    {
        if (obstacleData == null)
        {
            EditorGUILayout.LabelField("Obstacle Data not found!", EditorStyles.boldLabel);
            return;
        }

        DrawObstacleGrid();
        if (GUILayout.Button("Save Changes"))
        {
            EditorUtility.SetDirty(obstacleData);
            AssetDatabase.SaveAssets();
            Debug.Log("Obstacle data saved.");
        }
    }

    private void DrawObstacleGrid()
    {
        GUILayout.BeginVertical();
        for (int y = 0; y < 10; y++)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < 10; x++)
            {
                // Use GUILayout.Toggle to create a toggle button
                bool isObstacle = obstacleData.obstacleGrid[x, y];
                bool newObstacleState = GUILayout.Toggle(isObstacle, "", GUILayout.Width(20), GUILayout.Height(20));

                // Check if the state has changed
                if (newObstacleState != isObstacle)
                {
                    obstacleData.ToggleObstacle(x, y); // Toggle the obstacle state
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
}