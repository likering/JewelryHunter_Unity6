using UnityEngine;

public class TimeController : MonoBehaviour
{
    //カウントダウンにするかどうかのフラグ
    //falseならカウントアップ
    public bool isCountDown = true;

    //ゲームの基準となる時間
    public float gameTime = 0;

    //カウントをとめるかどうかのフラグ
    //falseならカウントをし続ける、trueならカウント終了
    public bool isTimeOver = false;

    //ユーザーに見せる時間
    public float displayTime = 0;

    //ゲームの経過時間
    float times = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //もしカウントダウンであれば基準時間をユーザーに見えるようにする
        if (isCountDown)
        {
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(isTimeOver ==false)
        if (!isTimeOver)
        {

            //停止フラグが立っていないので処理したいが
            //ゲームステータスがplayingでなくなった時は止めたい
            if (GameManager.gameState != "playing")
            {
                isTimeOver = true;//停止フラグをon
            }
            //カウントの処理をする

            //経過時間の蓄積
            times += Time.deltaTime;//デルタタイムの蓄積

            //カウントダウン形式だった場合
            if (isCountDown)
            {
                //ユーザーに見せたい時間（残り時間）
                //残り時間に（基準時間-経過時間）を代入
                displayTime = gameTime - times;

                if (displayTime <= 0)
                {
                    displayTime = 0;//０という表記に統一
                    isTimeOver = true;//停止フラグをon
                    GameManager.gameState = "gameover";
                }
            }
            else//カウントアップ形式だったばあい
            {
                //経過時間をユーザーに見せたい時間に代入
                displayTime = times;
                if (displayTime >= gameTime)
                {
                    //ユーザーに見せたい時間を基準時間にする
                    displayTime = gameTime;
                    isTimeOver = true;
                    GameManager.gameState = "gameover";

                }
            }
            Debug.Log(displayTime);



        }
    }
}