using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //クリックした位置が星の上であれば始点位置でポジションを設定
    //ドラッグ時は現在のマウスポジションを取得して直線を引く
    //クリックを離す位置が星の上であれば終点位置としてポジションを設定
    //2点間の直線を引く

    public GameObject star;
    public GameObject temporaryLine;
    LineRenderer temporaryRender;
    public GameObject solidLine;
    private Vector3 startPos;
    private Vector3 endPos;
    //フラグの変数
    private bool createLineFlag;
    private bool createLineOverCheck;
    private bool temporaryCheck;
    private bool temporaryStartPos;
    private bool temporaryEndPos;
    //ラインの重複チェック用のリスト
    public static List<GameObject> existingLines = new List<GameObject>();

    CheckConstellation checkConstellation;

    // Start is called before the first frame update
    void Start()
    {
        temporaryRender = temporaryLine.GetComponent<LineRenderer>();

        createLineFlag = false;
        createLineOverCheck = false;
        temporaryCheck = false;
        temporaryStartPos = false;
        temporaryEndPos = false;
        checkConstellation = GameObject.Find("GameManager").GetComponent<CheckConstellation>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    public void Controller()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit.collider)
            {
                temporaryLine.SetActive(true);
                if (existingLines.Count == 0)
                {
                    startPos = hit.collider.transform.position;
                }
                createLineFlag = true;
            }
        }

        if (createLineFlag)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // 2点の位置を設定
                temporaryRender.SetPosition(0, startPos);
                temporaryRender.SetPosition(1, mousePos);
                //マウスカーソルの位置からRayを飛ばす
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                if (hit.collider)
                {
                    endPos = hit.collider.transform.position;
                    if (!startPos.Equals(endPos))
                    {
                        LineRenderer temporaryRender = hit.collider.GetComponent<LineRenderer>();
                        //線の重複チェック
                        if (existingLines.Count > 0)
                        {
                            Vector3 createLineDis = startPos + endPos;
                            foreach (GameObject obj in existingLines)
                            {
                                Vector3 existingLinesDis = new Vector3(0, 0, 0);
                                LineRenderer solidRenderer = obj.GetComponent<LineRenderer>();
                                for (int i = 0; i < solidRenderer.positionCount; i++)
                                {
                                    Vector3 position = solidRenderer.GetPosition(i);
                                    existingLinesDis += position;
                                }
                                if (existingLinesDis.Equals(createLineDis))
                                {
                                    createLineOverCheck = true;
                                }
                            }
                        }

                        //下線が繋がれているかどうか判定
                        for (int i = 0; i < temporaryRender.positionCount; i++)
                        {
                            if (startPos == temporaryRender.GetPosition(i))
                            {
                                temporaryStartPos = true;
                            }
                            if (endPos == temporaryRender.GetPosition(i))
                            {
                                temporaryEndPos = true;
                            }
                        }

                        if (temporaryStartPos && temporaryEndPos)
                        {
                            temporaryCheck = true;
                        }
                        if (!createLineOverCheck && temporaryCheck)
                        {
                            CreateSolidLine(startPos, endPos);
                            startPos = endPos;
                            temporaryCheck = false;
                            temporaryStartPos = false;
                            temporaryEndPos = false;
                        }
                    }
                }
                else
                {
                    createLineOverCheck = false;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                temporaryLine.SetActive(false);
                createLineFlag = false;
                temporaryCheck = false;
                temporaryStartPos = false;
                temporaryEndPos = false;
            }

        }
    }
    //実線を生成
    public void CreateSolidLine(Vector2 sPos, Vector2 ePos)
    {
        LineRenderer solidRenderer = solidLine.GetComponent<LineRenderer>();

        solidRenderer.SetPosition(0, sPos);
        solidRenderer.SetPosition(1, ePos);

        Instantiate(solidLine);

        existingLines.Add(solidLine);
        checkConstellation.CheckDiamondCons(existingLines);

    }
}


/*if (Input.GetMouseButtonUp(0))
           {
               //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

               if (hit.collider)
               {       
                   endPos = hit.collider.transform.position;
                   //同じ位置に生成しようとしていないか確認
                   if (!startPos.Equals(endPos))
                   {
                       if (existingLines != null)
                       {
                           Vector3 createLineDis = startPos + endPos;
                           foreach (GameObject obj in existingLines)
                           {
                               Vector3 existingLinesDis = new Vector3(0, 0, 0);
                               LineRenderer solidRenderer = obj.GetComponent<LineRenderer>();
                               for (int i = 0; i < solidRenderer.positionCount; i++)
                               {
                                   Vector3 position = solidRenderer.GetPosition(i);
                                   existingLinesDis += position;
                               }
                               //1つ1つ取り出して見ているからいけない！
                               if (existingLinesDis.Equals(createLineDis))
                               {
                                   createLineOverCheck = true;
                               }
                           }
                       }
                       if (!createLineOverCheck)
                       {
                           CreateSolidLine(startPos, endPos);
                       }
                   }
               }
               temporaryLine.SetActive(false);
               createLineFlag = false;
               createLineOverCheck = false;
               Debug.Log(existingLines.Count);
           }*/
