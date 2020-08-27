using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AsteroidSpawnWindow : EditorWindow
{
    GameLogic gameLogic;
    GameObject asteroidrfab;
    [SerializeField] Vector3 asteroidNewPosition;
    [SerializeField] Quaternion quaternion;

    [MenuItem("Tools/Asteroid Spawn")]
    //Need to open window first...
    public static void Open()
    {
        GetWindow<AsteroidSpawnWindow>();
    }
    //Let's do some stuff...
    private void OnGUI() 
    {
        //Let's go one on top of the other
        EditorGUILayout.BeginVertical("Box");
        //We need references if we are to do same
        // things as prefab in GameLogic
        FindReferences();
        //We will hava a button
        DrawButton();
        //and proporeties under it.
        DrawProperties();
        EditorGUILayout.EndVertical();

    }
    private void DrawProperties()
    {
        //position is easy
        asteroidNewPosition = EditorGUILayout.Vector3Field("Position of new Asteroid", asteroidNewPosition);
        //rotation takes a liitle more work
        Vector3 rotToEuler = quaternion.eulerAngles;
        rotToEuler = EditorGUILayout.Vector3Field("Rotation In Euler",rotToEuler);
        quaternion = Quaternion.Euler(rotToEuler);
    }
    private void FindReferences()
    {
        //we need the same prefab as one used in game it self
        gameLogic = GameObject.FindObjectOfType<GameLogic>();
        asteroidrfab = gameLogic.GetAsteroidPrefab();
    }

    private void DrawButton()
    {
        if(GUILayout.Button("Create Asteroid"))
        {
            CreateAsteroid();
        }
    }
    private void CreateAsteroid()
    {
        //let us create new asteroid form prefab
        GameObject newAsteroid;
        //it will be created in place set from editor window
        //and rotation set in editor window
        newAsteroid = Instantiate(asteroidrfab, asteroidNewPosition, quaternion);
        //select newly crated asteroid for convinience
        Selection.activeGameObject = newAsteroid;
        

    }
    void OnInspectorUpdate()
    {
        
        this.Repaint();
    }
}
