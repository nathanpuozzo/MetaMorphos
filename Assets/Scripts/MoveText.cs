using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MoveText : MonoBehaviour
{
    public GameObject centralObject;
    public InterestPointConstructor[] points;
    public InterestPointGroup pointGroup;
   
    


    void Start()
    {
        pointGroup = new InterestPointGroup(centralObject, 15, points);

    }


    void Update()
    {
        pointGroup.OnMove();

    }

}

