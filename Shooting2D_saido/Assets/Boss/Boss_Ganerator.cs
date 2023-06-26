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
        // X方向の移動
        float speed = 5f;
        Vector3 dir = Vector3.zero;
        dir.x = -speed;


        //左に見切れたら右から登場
        if (transform.position.x <= -8f)
        {
            Vector3 pos = transform.position;
            pos.x = 9f;
            transform.position = pos;
        }

        //transform.position = new Vector3(transform.position.x, yurayura + Mathf.PingPong(Time.time, 0.3f), transform.position.z);

        // Y方向の移動
        // -1 <= Mathf.Sin(Time.time * 5f) <= 1
        //dir.x = 5f * Mathf.Cos(Time.time * 5f);
        dir.y = 2f * Mathf.Sin(Time.time * 5f);
        //Debug.Log(Time.time);

        // 敵の移動方向をプレーヤーのいる方向にする
        //dir = player.position - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pleyrと重なったら消去
        if (collision.gameObject.tag == "Player")
        {
            // 制限時間を１０秒減らす
            GameDirector.lastTime -= 10f;

            //爆破のエフェクト

            //自分を破壊
            Destroy(gameObject);
        }

        //Shootと重なったら消去
        if (collision.gameObject.tag == "Shoot")
        {
            //爆破のエフェクト
            
            //自分を破壊
            Destroy(gameObject);
        }
    }
}