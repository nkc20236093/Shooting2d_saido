using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakuhatu : MonoBehaviour
{
    private void Start()
    {
        Animator animator = GetComponent<Animator>();
    }

    // �A�j���[�V�����̍Ō�ɌĂяo�����\�b�h
    // �����̃A�j���[�V�����N���b�v�ɃC�x���g�Ƃ��ēo�^
    public void ExepDelete()
    {
        //Animator animator = 
        // �����i�����j�폜
        Destroy(gameObject);
    }
}
