using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateStar : MonoBehaviour
{
    public GameObject star;
    public GameObject solidLine;
    //三角形の星座の位置変数
    Vector3[] trianglePositions = new Vector3[]
   {
        new Vector3(0f, 3f, 0f),
        new Vector3(-3f, 0f, 0f),
        new Vector3(3f, 0f, 0f)
   };

    //四角形の星座の位置変数
    Vector3[] rectanglePositions = new Vector3[]
    {
        new Vector3(-2f, 1f, 0f),
        new Vector3(-2f, -2f, 0f),
        new Vector3(2f, 1f, 0f),
        new Vector3(2f, -2f, 0f)
    };

    //星座が作れているかカウントする変数
    //int clearCount;

    //三角形の生成
    public void TriangleStarCleate()
    {
        foreach (Vector3 position in trianglePositions)
        {
            Instantiate(star, position, Quaternion.identity);
        }
    }

    //四角形の生成
    public void RectangleStarCleate()
    {
        foreach (Vector3 position in rectanglePositions)
        {
            Instantiate(star, position, Quaternion.identity);
        }
    }

    //オブジェクトのリセット
    public void ResetStar()
    {
        GameObject[] solidLineToDestroy = GameObject.FindGameObjectsWithTag("solidLine");
        GameObject[] starToDestroy = GameObject.FindGameObjectsWithTag("star");

        // 実線のオブジェクトを破棄
        foreach (GameObject obj in solidLineToDestroy)
        {
            Destroy(obj);
        }

        // 星のオブジェクトを破棄
        foreach (GameObject obj in starToDestroy)
        {
            Destroy(obj);
        }

    }

}
