using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;//Player�ɂ��Ă���Rigidbody2D���������߂̕ϐ�

    float axisH;//���͂̕������L�����邽�߂̕ϐ�
    public float speed = 3.0f;//�v���C���[�̃X�s�[�h�𒲐�


    // Start is called once before the first executiigion of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();//Player�ɂ��Ă���R���|�[�l���g�����擾
    }

    // Update is called once per frame
    void Update()
    {

        //velocity�̌��ƂȂ�l�̎擾�i�E�Ȃ�P�D�O���A���Ȃ�-�P�D�O���A�Ȃɂ��Ȃ���΂O�j
        axisH = Input.GetAxisRaw("Horizontal");


    }
    //��b�ԂɂT�O��(50fps)�J��Ԃ��悤�ɐ��䂵�Ȃ���s���J��Ԃ����\�b�h
    private void FixedUpdate()
    {
        //velocity�ɒl��������
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);
    }
}
