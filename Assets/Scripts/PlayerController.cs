using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("プレイヤーの能力値")]

    public float speed = 3.0f;//プレイヤーのスピードを調整
    public float jumpPower = 9.0f;//ジャンプ力

    [Header("地面判定の対象となるレイヤー")]

    public LayerMask groundLayer;//地面レイヤーを指定するための変数

    Rigidbody2D rbody;//PlayerについているRigidbody2Dを扱うための変数

    Animator animetor;//Animetorコンポーネントを扱うための変数

    float axisH;//入力の方向を記憶するための変数

    bool gojump = false;//ジャンプフラグ（true:真on false:偽off）
    bool onGround = false;//地面にいるかどうかの判定（地面にいる：true、地面にいない：false）

    // Start is called once before the first executiigion of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();//Playerについているコンポーネント情報を取得

        animetor = GetComponent<Animator>();

    }
    void Update()
    {

        //velocityの元となる値の取得（右なら１．０ｆ、左なら-１．０ｆ、なにもなければ０）
        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0)
        {
            //右を向く
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axisH < 0)
        {
            //左を向く
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //GetButtonDownメソッド→引数に指定したボタンが押されたらtrueを返す、押されていなければfalseを返す
        if (Input.GetButtonDown("Jump"))
        {
            Jump();//Jmpメソッドの発動
        }
    }

    //一秒間に５０回(50fps)繰り返すように制御しながら行う繰り返しメソッド
    private void FixedUpdate()
    {
        //地面判定をサークルキャストで行って、その結果を変数onGroundに代入
        onGround = Physics2D.CircleCast(
            transform.position, //発射位置＝プレイヤーの位置（基準点）
            0.2f,//調査する円の半径
            new Vector2(0, 1.0f),//発射方向*下方向
            0,//発射距離
            groundLayer//対象となるレイヤー情報*LayerMask


            );
        //velocityに値を代入する
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        if (gojump)
        {
            //ジャンプさせる→プレイヤーを上に押し出す
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            gojump = false;//フラグをoffに戻す

        }
       // if (onGround)//地面にいる時
       // {
            if (axisH == 0)//左右が押されていない
            {
                animetor.SetBool("Run",false);//idleアニメに切り替え

            }
            else//左右が押されている
            {
                animetor.SetBool("Run",true);//Runアニメに切り替え
            }
      //  }
    }
    //ジャンプボタンが押された時に呼び出されるメソッド
    void Jump()
    {
        if (onGround)
        {
            gojump = true;//ジャンプフラグをon
            animetor.SetTrigger("Jump");
        }
    }
}
