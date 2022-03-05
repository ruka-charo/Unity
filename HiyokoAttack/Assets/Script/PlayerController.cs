using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float moveableRange = 5.5f;
    public float power = 1000f;
    public GameObject cannonBall;
    public Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        // プレイヤーを動かす処理(入力に対してどっちに動くか)
        transform.Translate(
            Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0
            );

        // 移動範囲を制限する処理(x軸のmin, maxの値を指定)
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -moveableRange, moveableRange),
            transform.position.y
            );

        // スペースキーを押したら砲弾が発射される
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // 砲弾発射のスクリプト
    void Shoot()
    {
        // 砲弾の生成
        GameObject newBullet = Instantiate(cannonBall, spawnPoint.position,
                               Quaternion.identity) as GameObject;
        // 砲弾の飛んでいく処理(方向 × 強さ)
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power);
    }
}
