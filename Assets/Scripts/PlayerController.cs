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
                animetor.SetBool("Run",false);//idle�A�j���ɐ؂�ւ�

            }
            else//���E��������Ă���
            {
                animetor.SetBool("Run",true);//Run�A�j���ɐ؂�ւ�
            }
      //  }
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
}
