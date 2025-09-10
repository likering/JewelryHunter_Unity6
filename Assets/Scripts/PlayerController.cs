using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�v���C���[�̔\�͒l")]

    public float speed = 3.0f;//�v���C���[�̃X�s�[�h�𒲐�
    public float jumpPower = 9.0f;//�W�����v��

    [Header("�n�ʔ���̑ΏۂƂȂ郌�C���[")]

    public LayerMask groundLayer;//�n�ʃ��C���[���w�肷�邽�߂̕ϐ�

    Rigidbody2D rbody;//Player�ɂ��Ă���Rigidbody2D���������߂̕ϐ�

    Animator animetor;//Animetor�R���|�[�l���g���������߂̕ϐ�

    float axisH;//���͂̕������L�����邽�߂̕ϐ�

    bool gojump = false;//�W�����v�t���O�itrue:�^on false:�Uoff�j
    bool onGround = false;//�n�ʂɂ��邩�ǂ����̔���i�n�ʂɂ���Ftrue�A�n�ʂɂ��Ȃ��Ffalse�j

    // Start is called once before the first executiigion of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();//Player�ɂ��Ă���R���|�[�l���g�����擾

        animetor = GetComponent<Animator>();

    }
    void Update()
    {
        //�Q�[���̃X�e�[�^�X��playing�łȂ��Ȃ�
        if (GameManager.gameState != "playing")
        {
            return;//���̃t���[���������I��
        }

        //velocity�̌��ƂȂ�l�̎擾�i�E�Ȃ�P�D�O���A���Ȃ�-�P�D�O���A�Ȃɂ��Ȃ���΂O�j
        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0)
        {
            //�E������
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axisH < 0)
        {
            //��������
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //GetButtonDown���\�b�h�������Ɏw�肵���{�^���������ꂽ��true��Ԃ��A������Ă��Ȃ����false��Ԃ�
        if (Input.GetButtonDown("Jump"))
        {
            Jump();//Jmp���\�b�h�̔���
        }
    }

    //��b�ԂɂT�O��(50fps)�J��Ԃ��悤�ɐ��䂵�Ȃ���s���J��Ԃ����\�b�h
    private void FixedUpdate()
    {
        if (GameManager.gameState != "playing")
        {
            return;//���̃t���[���������I��
        }

        //�n�ʔ�����T�[�N���L���X�g�ōs���āA���̌��ʂ�ϐ�onGround�ɑ��
        onGround = Physics2D.CircleCast(
            transform.position, //���ˈʒu���v���C���[�̈ʒu�i��_�j
            0.2f,//��������~�̔��a
            new Vector2(0, 1.0f),//���˕���*������
            0,//���ˋ���
            groundLayer//�ΏۂƂȂ郌�C���[���*LayerMask


            );
        //velocity�ɒl��������
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        if (gojump)
        {
            //�W�����v�����遨�v���C���[����ɉ����o��
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            gojump = false;//�t���O��off�ɖ߂�

        }
        // if (onGround)//�n�ʂɂ��鎞
        // {
        if (axisH == 0)//���E��������Ă��Ȃ�
        {
            animetor.SetBool("Run", false);//idle�A�j���ɐ؂�ւ�

        }
        else//���E��������Ă���
        {
            animetor.SetBool("Run", true);//Run�A�j���ɐ؂�ւ�
        }

    }
    //�W�����v�{�^���������ꂽ���ɌĂяo����郁�\�b�h
    void Jump()
    {
        if (onGround)
        {
            gojump = true;//�W�����v�t���O��on
            animetor.SetTrigger("Jump");
        }
    }
    //isTtigger�����������Ă���Collider�ƂԂ������珈�������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Ԃ��������肪�hGoal�h�^�O�������Ă�����
        //if (collision.gameObject.Tag=="Goal")
        if (collision.gameObject.CompareTag("Goal"))
        {
            GameManager.gameState = "gameclear";
            Debug.Log("�S�[���ɐڐG�����I");
            Goal();
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            GameManager.gameState = "gameover";
            Debug.Log("�Q�[���I�[�o�[");
            GameOver();

        }
        //�A�C�e���ɐG�ꂽ��X�e�[�W�X�R�A�ɉ��Z
        if (collision.gameObject.CompareTag("ItemScore"))
        {
            GameManager.stageScore += collision.gameObject.GetComponent<ItemData>().value;
            Destroy(collision.gameObject);
        }
    }
    //�S�[���������̃��\�b�h
    public void Goal()
    {
        animetor.SetBool("Clear", true);//�N���A�A�j���ɐ؂�ւ�
        GameStop();//�v���C���[��Velocity���~�߂郁�\�b�h

    }
    //�Q�[���I�[�o�[�������̃��\�b�h
    public void GameOver()
    {
        animetor.SetBool("Dead", true);//�f�b�h�A�j���ɐ؂�ւ�
        GameStop();
        //�����蔻��𖳌�
        GetComponent<CapsuleCollider2D>().enabled = false;
        //������ɔ�ђ��˂�����
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

        //�v���C���[��3�b��ɖ���
        Destroy(gameObject, 3.0f);

    }
    void GameStop()
    {
        //���x���O�ɂ���
        // rbody.linerVelocity = new Vector2(0. 0);
        rbody.linearVelocity = Vector2.zero;

    }
}
