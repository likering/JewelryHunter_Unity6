using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject mainImage;//�A�i�E���X������摜
    public GameObject buttonPanel;//�{�^�����O���[�v�����Ă���p�l��

    public GameObject retryButton;//���g���C�{�^��
    public GameObject nextButton;//�l�N�X�g�{�^��
    public Sprite gameClearSprite;//�Q�[���N���A�̊G
    public Sprite gameOverSprite;//�Q�[���I�[�o�[�̊G
    TimeController timeCnt;//TimeController.cs�̎Q��
    public GameObject timeText;//�Q�[���I�u�W�F�N�g�ł���TimeText

    public GameObject scoreText;//�X�R�A�e�L�X�g



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeCnt = GetComponent<TimeController>();

        buttonPanel.SetActive(false);//���݂��\��

        //���ԍ��Ń��\�b�h�v�𔭓�
        Invoke("InactiveImage", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == "gameclear")
        {
            buttonPanel.SetActive(true);//�{�^���p�l���̕���
            mainImage.SetActive(true); //���C���摜�̕���
            //���C���摜�I�u�W�F�N�g��Image�R���|�[�l���g���������Ă���ϐ�sprite�Ɂh�X�e�[�W�N���A�h�̊G����
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            //���g���C�{�^���I�u�W�F�N�g��Button�R���|�[�l���g���������Ă���ϐ�interactable�𖳌�
            retryButton.GetComponent<Button>().interactable = false;
        }

        else if (GameManager.gameState == "gameover")
        {
            buttonPanel.SetActive(true);//�{�^���p�l���̕���
            mainImage.SetActive(true); //���C���摜�̕���
            //���C���摜�I�u�W�F�N�g��Image�R���|�[�l���g���������Ă���ϐ�sprite�Ɂh�Q�[���I�[�o�[�h�̊G����
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            //�l�N�X�g�{�^���I�u�W�F�N�g��Button�R���|�[�l���g���������Ă���ϐ�interactable�𖳌�
            nextButton.GetComponent<Button>().interactable = false;
        }
        else if (GameManager.gameState =="playing")
        {
            //��������displayTime�̐�����ϐ�times�ɓn��
            float times = timeCnt.displayTime;

            timeText.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(times).ToString();
        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
    //�X�R�A�{�[�h���X�V
    void UpadateScore()
    {
        int score = GameManager.stageScore + GameManager.totalScore;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
