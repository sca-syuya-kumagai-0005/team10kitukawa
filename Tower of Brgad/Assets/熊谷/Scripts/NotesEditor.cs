using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotesEditor : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas; //�L�����o�X
    [SerializeField]
    private float speed;   //���������R�}���h�̈ړ����x
    public static float s;     //�C���X�y�N�^�[����A�^�b�`���ꂽCSV�t�@�C�����i�[���铮�I�z��//���X�g�ɕϊ��������̃f�[�^���i�[���铮�I�z��
    [SerializeField]
    private GameObject[] notes;        //�R�}���h�̉摜���i�[����z��
    [SerializeField]
    private string skillName;

    public enum NotesType
    {
        w=0,
        a=1,
        s=2,
        d=3,
        L=4,
        U=5,
        R=6,
        D=7
    }

    public enum NotesDirection
    {
        Left=0,
        Up,
        Right,
        Down
    }

    public static NotesDirection direction;

    void Start()
    {
    }

    void Update()
    {
        s = speed;
        var notesDatas = Resources.Load<TextAsset>(skillName);
        if (Input.GetKeyDown(KeyCode.Return)) //�����I�ɁAEnter�L�[���͂ŃC���X�y�N�^�[�ɃA�^�b�`������ڂ̃X�L�������s
        {
            StartCoroutine(NotesCreater(notesDatas));
        }
    }

    IEnumerator NotesCreater(TextAsset TAD) //�����ɓ��͂��ꂽ���X�g���m�[�c�Ƃ��Đ�������֐�
    {
        List<string[]> csvDatas = new List<string[]>();
        StringReader reader = new StringReader(TAD.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
        var notesData=csvDatas;
        for (int i = 1; i != -1; ++i)
        {
            NotesType c=NotesType.w;
            float t = 0.0f;
            Vector3 pos = new Vector3(0, 0, 0);
            string[] data = new string[notesData[i].Length]; //��s���܂Ƃ߂Ċi�[����z��

            for (int j = 0; j < notesData[0].Length; ++j)
            {
                if (notesData[i][j] == (-1).ToString()) //-1��������֐��I��
                {
                    yield break;
                }

                data[j] = notesData[i][j]; //��s��z��Ɋi�[
            }

            switch (data[0]) //�z��̈�ڂɓ����Ă��镶������Đ�������R�}���h������
            {
                case "w":
                    c = NotesType.w;
                    break;

                case "a":
                    c = NotesType.a;
                    break;

                case "s":
                    c = NotesType.s;
                    break;

                case "d":
                    c = NotesType.d;
                    break;

                case "L":
                    c = NotesType.L;
                    break;

                case "U":
                    c = NotesType.U;
                    break;

                case "R":
                    c = NotesType.R;
                    break;

                case "D":
                    c = NotesType.D;
                    break;
            }�@�@�@�@//���ڂ̒l�ɂ���ăm�[�c�̎�ނ�����
            t = float.Parse(data[1]);�@//���ڂ̒l�ɂ���ăm�[�c������ė���܂ł̎��Ԃ�����
            switch (data[2]) 
            {
                case "L":
                    {
                        pos = new Vector3(1010 + canvas.pixelRect.width / 2, canvas.pixelRect.height / 2, 0);
                        direction = NotesDirection.Left;
                    }
                    break;

                case "U":
                    {
                        pos = new Vector3(canvas.pixelRect.width / 2, -590 + canvas.pixelRect.height / 2, 0);
                        direction = NotesDirection.Up;
                    }
                    break;

                case "R":
                    {
                        pos = new Vector3(-1010 + canvas.pixelRect.width / 2, canvas.pixelRect.height / 2, 0);
                        direction = NotesDirection.Right;
                    }
                    break;

                case "D":
                    {
                        pos = new Vector3(canvas.pixelRect.width / 2, 590 + canvas.pixelRect.height / 2, 0);
                        direction = NotesDirection.Down;
                    }
                    break;
            }�@     //�O��ڂ̒l�ɂ���ăm�[�c�̌���������
            yield return new WaitForSeconds(t); //���ڂ̒l�������ҋ@
            Instantiate(notes[(int)c], pos, Quaternion.identity, transform); //����
        }
    }

}
