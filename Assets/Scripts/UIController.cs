using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject mainImage;//�A�i�E���X������摜
    public GameObject buttonPanel;//�{�^�����O���[�v�����Ă���p�l��

    public GameObject retryButton;//���g���C�{�^��
    public GameObject nextButton;//�l�N�X�g�{�^��
    public Sprite gameClearSprite;//�Q�[���N���A�̊G
    public Sprite gameOverSprite;//�Q�[���I�[�o�[�̊G



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
}
