using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameProceesFlag;
    StageManager stageManager;
    CheckConstellation checkConstellation;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GetComponent<StageManager>();
        checkConstellation = GetComponent<CheckConstellation>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameProceesFlag)
        {
            stageManager.Stage001();
            gameProceesFlag = false;
        }

        if (checkConstellation.nextFlag)
        {
            gameProceesFlag = true;
            checkConstellation.nextFlag = false;
        }

    }

    void StartGame()
    {
        // ÉQÅ[ÉÄäJénéûÇÃèàóù
        gameProceesFlag = true;
    }

}
