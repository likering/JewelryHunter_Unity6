using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameState;//�ÓI�����o

    public static int totalScore;//�Q�[���S�̂̃X�R�A
    public static int stageScore;//���̃X�e�[�W�Ɋl�������X�R�A

    //Start���O�ɏ��������
    void Awake()
    {
        //�Q�[���̏�����Ԃ�playing
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
