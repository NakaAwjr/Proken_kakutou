using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MoveSpeed = 20.0f;         // 移動値

    private float moveDirection = 1.0f;    // 弾の移動方向（1: 正の方向, -1: 負の方向）

    public void SetDirection(float direction)
    {
        moveDirection = direction;
    }

    void Update()
    {
        // 位置の更新
        transform.Translate(MoveSpeed * moveDirection * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<Status>();
        if (target != null)
        {
            target.Damage(10);
        }

    }
}
