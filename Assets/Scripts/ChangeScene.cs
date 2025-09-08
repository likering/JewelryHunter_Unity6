using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public string SceneName;//切り替えたいシーン名を指定

    //シーンを切り替える機能をもったメソッド作成
    public void Load()
    {
        //引数に指定した名前のシーンに切り替えしてくれるメソッドの呼び出し
        SceneManager.LoadScene(SceneName);

    }
}
