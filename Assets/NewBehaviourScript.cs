using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var material in Resources.FindObjectsOfTypeAll<Material>())
        {
            if (material.shader.name.StartsWith("InternalErrorShader"))
            {
                material.shader = Shader.Find("Standard");
            }
        }
    }
}
