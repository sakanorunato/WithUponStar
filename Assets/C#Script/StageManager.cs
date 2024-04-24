using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    CreateStar createStar;
    //CheckConstellation checkConstellation = new CheckConstellation();

    void Start()
    {
        createStar = GameObject.Find("CreateStar").GetComponent<CreateStar>();
    }

    public void Stage001()
    {
        createStar.TriangleStarCleate();
    }
    
}
