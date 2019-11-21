using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGameObject: MonoBehaviour
{
    // Data
    public float Speed;

    void Update()
    {
        // Behaviour - Provides functionality to the GameObject
        // Uses Data
        transform.Rotate(0f, Speed * Time.deltaTime, 0f);
    }


}
