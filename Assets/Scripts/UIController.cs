using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject mainImage;//アナウンスをする画像
    public GameObject buttonPanel;//ボタンをグループ化しているパネル

    public GameObject retryButton;//リトライボタン
    public GameObject nextButton;//ネクストボタン
    public Sprite gameClearSprite;//ゲームクリアの絵
    public Sprite gameOverSprite;//ゲームオーバーの絵
    TimeController timeCnt;//TimeController.csの参照
    public GameObject timeText;//ゲームオブジェクトであるTimeText

    public GameObject scoreText;//スコアテキスト

    AudioSource audio;
    SoundController soundController;//自作したスクリプト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //同じCanvasについている
        timeCnt = GetComponent<TimeController>();

        buttonPanel.SetActive(false);//存在を非表示

        //時間差でメソッド」を発動
        Invoke("InactiveImage", 1.0f);

        UpadateScore();//トータルスコアが出るように更新

        //AudioSourceとSoundCotrollerの取得
        audio = GetComponent<AudioSource>();
        soundController = GetComponent<SoundController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == "gameclear")
        {
            buttonPanel.SetActive(true);//ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数spriteに”ステージクリア”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            //リトライボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効
            retryButton.GetComponent<Button>().interactable = false;

            //ステージクリアによってステージスコアが確定するので
            //トータルスコアに加算
            GameManager.totalScore += GameManager.stageScore;
            GameManager.stageScore = 0;//次に備えてステージスコアはリセット

            timeCnt.isTimeOver = true;//タイムカウント停止

            //いったんdisplayの数字を変数timesに渡す
            float times = timeCnt.displayTime;

            if (timeCnt.isCountDown)//カウントダウン
            {
                //残時間をボーナスとしてとしてトータルスコアに加算
                GameManager.totalScore += (int)times * 10;
            }
            else//カウントアップ
            {
                float gameTime = timeCnt.gameTime;//基準時間の取得
                GameManager.totalScore += (int)(gameTime - times) * 10;
            }
            UpadateScore();//UIに最終的な数字を反映

            //サウンドをストップ
            audio.Stop();
            //SoundControllerの変数に指名したゲームクリアの曲を一度だけ鳴らす
            audio.PlayOneShot(soundController.bgm_GameClear);

            //二重三重にスコアを加算しないようgameclearのフラグは早々に変化
            GameManager.gameState = "gameend";

        }

        else if (GameManager.gameState == "gameover")
        {
            buttonPanel.SetActive(true);//ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数spriteに”ゲームオーバー”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            //ネクストボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効
            nextButton.GetComponent<Button>().interactable = false;

            //カウントを止める
            timeCnt.isTimeOver = true;

            //サウンドをストップ
            audio.Stop();
            //SoundControllerの変数に指名したゲームオーバーの曲を一度だけ鳴らす
            audio.PlayOneShot(soundController.bgm_GameOver);

            GameManager.gameState = "gameend";
        }
        else if (GameManager.gameState == "playing")
        {
            //いったんdisplayTimeの数字を変数timesに渡す
            float times = timeCnt.displayTime;

            timeText.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(times).ToString();

            if (timeCnt.isCountDown)
            {
                if (timeCnt.displayTime <= 0)
                {
                    //プレイヤーを見つけてきて、そのPlayerControllerコンポーネントのGameOverメソッドをやらせている
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                    GameManager.gameState = "gameover";
                }
            }
            else
            {
                if (timeCnt.displayTime >= timeCnt.gameTime)
                {
                    //プレイヤーを見つけてきて、そのPlayerControllerコンポーネントのGameOverメソッドをやらせている
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                    GameManager.gameState = "gameover";
                }
            }
            //スコアもリアルタイムに更新
            UpadateScore();
        }




    }
    //メイン画像を非表示にするためだけのメソッド
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
    //スコアボードを更新
    void UpadateScore()
    {
        int score = GameManager.stageScore + GameManager.totalScore;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
