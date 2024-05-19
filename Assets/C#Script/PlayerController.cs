using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�N���b�N�����ʒu�����̏�ł���Ύn�_�ʒu�Ń|�W�V������ݒ�
    //�h���b�O���͌��݂̃}�E�X�|�W�V�������擾���Ē���������
    //�N���b�N�𗣂��ʒu�����̏�ł���ΏI�_�ʒu�Ƃ��ă|�W�V������ݒ�
    //2�_�Ԃ̒���������

    public GameObject star;
    public GameObject temporaryLine;
    LineRenderer temporaryRender;
    public GameObject solidLine;
    private Vector3 startPos;
    private Vector3 endPos;
    //�t���O�̕ϐ�
    private bool createLineFlag;
    private bool createLineOverCheck;
    private bool temporaryCheck;
    private bool temporaryStartPos;
    private bool temporaryEndPos;
    //���C���̏d���`�F�b�N�p�̃��X�g
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
            //���C���J������̃}�E�X�J�[�\���̂���ʒu����Ray���΂�
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
                // 2�_�̈ʒu��ݒ�
                temporaryRender.SetPosition(0, startPos);
                temporaryRender.SetPosition(1, mousePos);
                //�}�E�X�J�[�\���̈ʒu����Ray���΂�
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                if (hit.collider)
                {
                    endPos = hit.collider.transform.position;
                    if (!startPos.Equals(endPos))
                    {
                        LineRenderer temporaryRender = hit.collider.GetComponent<LineRenderer>();
                        //���̏d���`�F�b�N
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

                        //�������q����Ă��邩�ǂ�������
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
    //�����𐶐�
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
               //���C���J������̃}�E�X�J�[�\���̂���ʒu����Ray���΂�
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

               if (hit.collider)
               {       
                   endPos = hit.collider.transform.position;
                   //�����ʒu�ɐ������悤�Ƃ��Ă��Ȃ����m�F
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
                               //1��1���o���Č��Ă��邩�炢���Ȃ��I
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
