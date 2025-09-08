using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float x, y, z;//�J�����̍��W�����߂邽�߂̕ϐ�

    [Header("�J�����̌��E�l")]
    public float leftLimit;
    public float rightLimit;
    public float bottomLimit;
    public float topLimit;

    [Header("�J�����̃X�N���[���ݒ�")]
    public bool isScrollx;//�������ɋ����X�N���[��
    public float scrollSpeedx;
    public bool isScrolly;//�c�����ɋ����X�N���[��
    public float scrollSpeedy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Player�^�O���������Q�[���v���W�F�N�g��T���āA�ϐ�Player�ɑ��
        player = GameObject.FindGameObjectWithTag("Player");
        //�J������Z���W�͏����l�̂܂܂��ێ�������
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //��������v���C���[��x���W�Ay���W�v�̈ʒu��ϐ��Ɏ擾
            x = player.transform.position.x;
            y = player.transform.position.y;

            //���������̋����X�N���[���t���O�������Ă��Ă�
            if (isScrollx)
            {
                //�O�̍��W�ɕϐ����������Z�������W
                x = transform.position.x + (scrollSpeedx * Time.deltaTime);
            }

            //���������E�̌��E�܂Ńv���C���[���ړ�������
            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }

            //�������c�̋����X�N���[���t���O�������Ă��Ă�
            if (isScrolly)
            {
                //�O�̍��W�ɕϐ����������Z�������W
                y = transform.position.y + (scrollSpeedx * Time.deltaTime);
            }
            //�������㉺�̌��E�܂Ńv���C���[���ړ�������
            if (y < bottomLimit)
            {
                y = bottomLimit;
            }
            else if (y > topLimit)
            {
                y = topLimit;
            }
            //��茈�߂��e�ϐ�x,y,z�̒l���J�����̃|�W�V�����Ƃ���
            transform.position = new Vector3(x, y, z);
        }
    }
}
