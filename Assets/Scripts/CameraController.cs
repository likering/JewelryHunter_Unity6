using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float x, y, z;//カメラの座標を決めるための変数

    [Header("カメラの限界値")]
    public float leftLimit;
    public float rightLimit;
    public float bottomLimit;
    public float topLimit;

    [Header("カメラのスクロール設定")]
    public bool isScrollx;//横方向に強制スクロール
    public float scrollSpeedx;
    public bool isScrolly;//縦方向に強制スクロール
    public float scrollSpeedy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Playerタグをもったゲームプロジェクトを探して、変数Playerに代入
        player = GameObject.FindGameObjectWithTag("Player");
        //カメラのZ座標は初期値のままを維持したい
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //いったんプレイヤーのx座標、y座標」の位置を変数に取得
            x = player.transform.position.x;
            y = player.transform.position.y;

            //もしも横の強制スクロールフラグが立っていてら
            if (isScrollx)
            {
                //前の座標に変数分だけ加算した座標
                x = transform.position.x + (scrollSpeedx * Time.deltaTime);
            }

            //もしも左右の限界までプレイヤーが移動したら
            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }

            //もしも縦の強制スクロールフラグが立っていてら
            if (isScrolly)
            {
                //前の座標に変数分だけ加算した座標
                y = transform.position.y + (scrollSpeedx * Time.deltaTime);
            }
            //もしも上下の限界までプレイヤーが移動したら
            if (y < bottomLimit)
            {
                y = bottomLimit;
            }
            else if (y > topLimit)
            {
                y = topLimit;
            }
            //取り決めた各変数x,y,zの値をカメラのポジションとする
            transform.position = new Vector3(x, y, z);
        }
    }
}
