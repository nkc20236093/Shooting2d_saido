using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot_Generator : MonoBehaviour
{
    public GameObject Shoot_Pre;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {

        //�X�y�[�X�L�[�������ꂽ��e�𔭎�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Shoot_Pre,Player.transform);
        }
    }
}
