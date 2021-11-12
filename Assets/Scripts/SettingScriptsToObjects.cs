using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScriptsToObjects : MonoBehaviour {

    public GameObject damagingSpikes;
    public GameObject instakillSpikes;
    public GameObject smallSpikes;
    public GameObject bigSpikes;
    public GameObject cameraBorder1;
    public GameObject cameraBorder2;
    public GameObject levelEnd1;
    public GameObject levelEnd2;
    public GameObject colorObjects;
    public GameObject colorObjects2;


    void Awake () {

        cameraBorder1 = GameObject.FindWithTag("Camera Collider");
        cameraBorder2 = cameraBorder1.transform.Find("Collision").gameObject;
        cameraBorder2.gameObject.AddComponent<StopCameraFollow>();

        levelEnd1 = GameObject.FindWithTag("Level End");
        levelEnd2 = levelEnd1.transform.Find("Collision").gameObject;
        levelEnd2.gameObject.AddComponent<LevelLoader>();

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach(GameObject go in allObjects)
        {
            if (go.name == "Tileset")
            {
                if(go.transform.parent.gameObject.name == "Ground" || go.transform.parent.gameObject.name == "Camera Collider" || go.transform.parent.gameObject.name == "Level End")
                {
                    go.gameObject.AddComponent<MakeInvis>();
                }
            }
        }
    }
}
