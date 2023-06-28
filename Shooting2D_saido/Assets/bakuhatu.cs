using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakuhatu : MonoBehaviour
{
    private void Start()
    {
        Animator animator = GetComponent<Animator>();
    }

    // アニメーションの最後に呼び出すメソッド
    // 爆発のアニメーションクリップにイベントとして登録
    public void ExepDelete()
    {
        //Animator animator = 
        // 自分（爆発）削除
        Destroy(gameObject);
    }
}
