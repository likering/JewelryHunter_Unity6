using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameState;//静的メンバ

    public static int totalScore;//ゲーム全体のスコア
    public static int stageScore;//そのステージに獲得したスコア

    //Startより前に処理される
    void Awake()
    {
        //ゲームの初期状態をplaying
        gameState = "playing";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
