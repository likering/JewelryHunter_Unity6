using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public GameObject scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //���U���g��ʂ�ScoreText�I�u�W�F�N�g������
        //TextMeshPro(UGUI)��text����
        //GameManager��static�ϐ��ł���totalScore����
        //*������string�^�Ɍ^�ϊ����K�v
        scoreText.GetComponent<TextMeshProUGUI> ().text = GameManager.totalScore.ToString();

    }


}
