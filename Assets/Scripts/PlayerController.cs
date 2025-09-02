using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;//PlayerについているRigidbody2Dを扱うための変数

    float axisH;//入力の方向を記憶するための変数
    public float speed = 3.0f;//プレイヤーのスピードを調整


    // Start is called once before the first executiigion of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();//Playerについているコンポーネント情報を取得
    }

    // Update is called once per frame
    void Update()
    {

        //velocityの元となる値の取得（右なら１．０ｆ、左なら-１．０ｆ、なにもなければ０）
        axisH = Input.GetAxisRaw("Horizontal");


    }
    //一秒間に５０回(50fps)繰り返すように制御しながら行う繰り返しメソッド
    private void FixedUpdate()
    {
        //velocityに値を代入する
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);
    }
}
