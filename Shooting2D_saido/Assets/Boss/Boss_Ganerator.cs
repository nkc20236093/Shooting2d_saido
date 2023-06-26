using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ganerator : MonoBehaviour
{
    Transform player;
    public float yurayura;


    void Start()
    {
        yurayura = this.transform.position.y;
        player = GameObject.Find("Player").transform;
    }



    void Update()
    {
        // X�����̈ړ�
        float speed = 5f;
        Vector3 dir = Vector3.zero;
        dir.x = -speed;


        //���Ɍ��؂ꂽ��E����o��
        if (transform.position.x <= -8f)
        {
            Vector3 pos = transform.position;
            pos.x = 9f;
            transform.position = pos;
        }

        //transform.position = new Vector3(transform.position.x, yurayura + Mathf.PingPong(Time.time, 0.3f), transform.position.z);

        // Y�����̈ړ�
        // -1 <= Mathf.Sin(Time.time * 5f) <= 1
        //dir.x = 5f * Mathf.Cos(Time.time * 5f);
        dir.y = 2f * Mathf.Sin(Time.time * 5f);
        //Debug.Log(Time.time);

        // �G�̈ړ��������v���[���[�̂�������ɂ���
        //dir = player.position - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pleyr�Əd�Ȃ��������
        if (collision.gameObject.tag == "Player")
        {
            // �������Ԃ��P�O�b���炷
            GameDirector.lastTime -= 10f;

            //���j�̃G�t�F�N�g

            //������j��
            Destroy(gameObject);
        }

        //Shoot�Əd�Ȃ��������
        if (collision.gameObject.tag == "Shoot")
        {
            //���j�̃G�t�F�N�g
            
            //������j��
            Destroy(gameObject);
        }
    }
}