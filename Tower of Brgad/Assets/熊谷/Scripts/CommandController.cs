using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CommandController : MonoBehaviour
{
    private float speed;//�m�[�c�̃X�s�[�h
    private string myName;//�������ꂽ�v���n�u�̖��O

    // Start is called before the first frame update

    private void OnEnable()
    {
       gameObject.tag=(NotesEditor.direction.ToString());//NotesEditor����������擾���đΉ��^�O�ɕύX
       myName=this.gameObject.name;//���g�̖��O���擾
       myName=this.gameObject.name.Replace("(Clone)","");//�������Ɏ����ŕt���iClone�j��؂���
       StartCoroutine(NotesDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        speed = NotesEditor.s;
        if(Input.GetKeyDown(KeyCode.Return))//��ŕύX�@�d�l�҂�
        {
            Debug.Log(this.gameObject.name);
        }
        switch (gameObject.tag)//�^�O�𔻒肵�đΉ���������փm�[�c�𗬂�
        {
            case "Left":
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                break;

            case "Up":
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                break;

            case "Right":
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                break;

            case "Down":
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                break;
        }
        if (Input.GetKeyDown(myName))
        {
        }
    }

    IEnumerator NotesDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
