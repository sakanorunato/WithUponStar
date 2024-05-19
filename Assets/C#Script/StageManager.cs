using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    CreateStar createStar;
    CheckConstellation checkConstellation;

    void Start()
    {
        createStar = GameObject.Find("CreateStar").GetComponent<CreateStar>();
        checkConstellation = GetComponent<CheckConstellation>();
    }

    public void Stage001()
    {
        switch (checkConstellation.consClearNo)
        {
            case 1:
                createStar.DiamondStarsCreate();
                break;
            case 2:
                createStar.ResetStar();
                createStar.StarConstellation();
                break;
            default:
                createStar.ResetStar();
                Debug.Log("クリアしました");
                break;
        }
    }
    
}
