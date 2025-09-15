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

    AudioSource audio;
    SoundController soundController;//���삵���X�N���v�g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //����Canvas�ɂ��Ă���
        timeCnt = GetComponent<TimeController>();

        buttonPanel.SetActive(false);//���݂��\��

        //���ԍ��Ń��\�b�h�v�𔭓�
        Invoke("InactiveImage", 1.0f);

        UpadateScore();//�g�[�^���X�R�A���o��悤�ɍX�V

        //AudioSource��SoundCotroller�̎擾
        audio = GetComponent<AudioSource>();
        soundController = GetComponent<SoundController>();

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

            //�X�e�[�W�N���A�ɂ���ăX�e�[�W�X�R�A���m�肷��̂�
            //�g�[�^���X�R�A�ɉ��Z
            GameManager.totalScore += GameManager.stageScore;
            GameManager.stageScore = 0;//���ɔ����ăX�e�[�W�X�R�A�̓��Z�b�g

            timeCnt.isTimeOver = true;//�^�C���J�E���g��~

            //��������display�̐�����ϐ�times�ɓn��
            float times = timeCnt.displayTime;

            if (timeCnt.isCountDown)//�J�E���g�_�E��
            {
                //�c���Ԃ��{�[�i�X�Ƃ��ĂƂ��ăg�[�^���X�R�A�ɉ��Z
                GameManager.totalScore += (int)times * 10;
            }
            else//�J�E���g�A�b�v
            {
                float gameTime = timeCnt.gameTime;//����Ԃ̎擾
                GameManager.totalScore += (int)(gameTime - times) * 10;
            }
            UpadateScore();//UI�ɍŏI�I�Ȑ����𔽉f

            //�T�E���h���X�g�b�v
            audio.Stop();
            //SoundController�̕ϐ��Ɏw�������Q�[���N���A�̋Ȃ���x�����炷
            audio.PlayOneShot(soundController.bgm_GameClear);

            //��d�O�d�ɃX�R�A�����Z���Ȃ��悤gameclear�̃t���O�͑��X�ɕω�
            GameManager.gameState = "gameend";

        }

        else if (GameManager.gameState == "gameover")
        {
            buttonPanel.SetActive(true);//�{�^���p�l���̕���
            mainImage.SetActive(true); //���C���摜�̕���
            //���C���摜�I�u�W�F�N�g��Image�R���|�[�l���g���������Ă���ϐ�sprite�Ɂh�Q�[���I�[�o�[�h�̊G����
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            //�l�N�X�g�{�^���I�u�W�F�N�g��Button�R���|�[�l���g���������Ă���ϐ�interactable�𖳌�
            nextButton.GetComponent<Button>().interactable = false;

            //�J�E���g���~�߂�
            timeCnt.isTimeOver = true;

            //�T�E���h���X�g�b�v
            audio.Stop();
            //SoundController�̕ϐ��Ɏw�������Q�[���I�[�o�[�̋Ȃ���x�����炷
            audio.PlayOneShot(soundController.bgm_GameOver);

            GameManager.gameState = "gameend";
        }
        else if (GameManager.gameState == "playing")
        {
            //��������displayTime�̐�����ϐ�times�ɓn��
            float times = timeCnt.displayTime;

            timeText.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(times).ToString();

            if (timeCnt.isCountDown)
            {
                if (timeCnt.displayTime <= 0)
                {
                    //�v���C���[�������Ă��āA����PlayerController�R���|�[�l���g��GameOver���\�b�h����点�Ă���
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                    GameManager.gameState = "gameover";
                }
            }
            else
            {
                if (timeCnt.displayTime >= timeCnt.gameTime)
                {
                    //�v���C���[�������Ă��āA����PlayerController�R���|�[�l���g��GameOver���\�b�h����点�Ă���
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                    GameManager.gameState = "gameover";
                }
            }
            //�X�R�A�����A���^�C���ɍX�V
            UpadateScore();
        }




    }
    //���C���摜���\���ɂ��邽�߂����̃��\�b�h
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
