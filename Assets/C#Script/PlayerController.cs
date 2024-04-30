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
    private Vector2 startPos;
    private Vector2 endPos;
    //�t���O�̕ϐ�
    private bool createLineFlag;
    //
    private List<GameObject> existingLines = new List<GameObject>();

    CheckConstellation checkConstellation;

    // Start is called before the first frame update
    void Start()
    {
        temporaryRender = temporaryLine.GetComponent<LineRenderer>();

        createLineFlag = false;

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
                startPos = hit.collider.transform.position;
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
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //���C���J������̃}�E�X�J�[�\���̂���ʒu����Ray���΂�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit.collider)
            {       
                endPos = hit.collider.transform.position;
                if (!startPos.Equals(endPos))
                {
                    if (existingLines != null)
                    {
                        foreach (GameObject obj in existingLines)
                        {
                            LineRenderer solidRenderer = obj.GetComponent<LineRenderer>();
                            for (int i = 0; i < solidRenderer.positionCount; i++)
                            {
                                Vector3 position = solidRenderer.GetPosition(i);
                                Debug.Log("Position of point " + i + ": " + position);
                            }
                        }
                    }
                    CreateSolidLine(startPos, endPos);
                }
            }
            temporaryLine.SetActive(false);
            createLineFlag = false;

        }

    }

    //�����𐶐�
    public void CreateSolidLine(Vector2 sPos, Vector2 ePos)
    {
        LineRenderer solidRenderer = solidLine.GetComponent<LineRenderer>();

        solidRenderer.SetPosition(0, sPos);
        solidRenderer.SetPosition(1, ePos);

        Instantiate(solidLine);

        checkConstellation.CheckTriangleCons(solidLine);

        existingLines.Add(solidLine);

    }
}
