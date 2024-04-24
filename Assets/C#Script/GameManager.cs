using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameProceesFlag;
    StageManager stageManager;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GetComponent<StageManager>();
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
    }

    void StartGame()
    {
        // ƒQ[ƒ€ŠJn‚Ìˆ—
        gameProceesFlag = true;
    }

}
