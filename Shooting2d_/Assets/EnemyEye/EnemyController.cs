//----------------------------------------------------------------------------------------
// 科目：ゲームプログラミング
// 内容：敵制御スクリプト
// 担当：Ken.D.Ohishi 2023.06.06
//----------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject ShotPre_2;
    public GameObject ExploPre; // 爆発のプレハブを保存
    public GameObject ShotPre;  // 弾のプレハブを保存
    float speed;                // 移動速度を保存
    Vector3 dir;                // 移動方向を保存
    int enemyType;              // 敵の種類を保存
    float rad;                  // 敵の動きサインカーブ用
    float shotTime;             // 弾の発射間隔計算用
    float shotInterval = 2f;    // 弾の発射間隔
    GameDirector gd;            // GameDirectorコンポーネントを保存

    void Start()
    {
        Destroy(gameObject, 8);		    // 寿命
        enemyType = Random.Range(0, 5); // 敵の種類
        speed = 5;                      // 移動速度
        dir = Vector3.left;             // 移動方向
        rad = Time.time;                // サインカーブの動きをずらす用
        shotTime = 0;                   // 弾発射間隔計算用

        // GameDirectorコンポーネントを保存
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

    }

    void Update()
    {
        //// エネミータイプ２だけ縦移動（サインカーブ）追加
        if (enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f);
            // 敵の弾の生成
            shotTime += Time.deltaTime;
            if (shotTime > shotInterval)
            {
                shotTime = 0;
                Instantiate(ShotPre, transform.position, transform.rotation);
            }
        }
        if (enemyType == 3)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f);
            // 敵の弾の生成
            shotTime += Time.deltaTime;
            if (shotTime > shotInterval)
            {
                shotTime = 0;
                Instantiate(ShotPre, transform.position, transform.rotation);
                Invoke("rennsya1", 0.1f);
                Invoke("rennsya2", 0.2f);
            }
        }
        if (enemyType == 4)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f);
            // 敵の弾の生成
            shotTime += Time.deltaTime;
            if (shotTime > shotInterval)
            {
                shotTime = 0;
                Instantiate(ShotPre_2, transform.position, transform.rotation);
                Invoke("rennsya3", 0.1f);
                Invoke("rennsya4", 0.2f);
            }
        }

        // 移動処理
        transform.position += dir.normalized * speed * Time.deltaTime;

        // 敵の弾の生成
        //shotTime += Time.deltaTime;
        //if (shotTime > shotInterval)
        //{
        //    shotTime = 0;
        //    Instantiate(ShotPre, transform.position, transform.rotation);
        //}
    }

    public void rennsya1()
    {
        Instantiate(ShotPre, transform.position, transform.rotation);
    }
    public void rennsya2()
    {
        Instantiate(ShotPre, transform.position, transform.rotation);
    }
    public void rennsya3()
    {
        Instantiate(ShotPre_2, transform.position, transform.rotation);
    }
    public void rennsya4()
    {
        Instantiate(ShotPre_2, transform.position, transform.rotation);
    }
    // 重なり判定処理
    void OnTriggerEnter2D(Collider2D other)
    {
        // 重なった相手のタグが【Player】だったら
        if (other.tag == "Player")
        {
            // 距離を減らす
            GameDirector.kyori -= 1000;

            // 重なった相手が衝突爆発を生成
            Instantiate(ExploPre, transform.position, transform.rotation);

            // 自分（敵）削除
            Destroy(gameObject);
        }

        // 重なった相手のタグが【PlayerShot】だったら
        if (other.tag == "PlayerShot")
        {
            // 距離を増やす
            GameDirector.kyori += 200;

            // 重なった相手が衝突爆発を生成
            Instantiate(ExploPre, transform.position, transform.rotation);

            // 自分（敵）削除
            Destroy(gameObject);
        }
    }
}