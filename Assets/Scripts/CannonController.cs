using UnityEngine;
using UnityEngine.UIElements;

public class CannonController : MonoBehaviour
{
    [Header("�����v���n�u/����/���x/�͈�")]
    public GameObject objPrefab;
    public float delayTime = 3.0f;//��������
    public float fireSpeed = 4.0f;//���ˑ̂̑��x
    public float length = 8.0f;//�����͈�


    [Header("���ˌ�")]
    public Transform gateTransform;

    GameObject player;//�v���C���[
    float passedTimes = 0;//�o�ߎ���

    AudioSource audioSource;
    public AudioClip se_Shoot;

    //�����`�F�b�N
    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d)
        {
            ret = true;
        }
        return ret;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�v���C���[�̎擾
        player = GameObject.FindGameObjectWithTag("Player");

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //�ҋ@���ԉ��Z
        passedTimes += Time.deltaTime;
        //Player�Ƃ̋����`�F�b�N
        if (CheckLength(player.transform.position))
        {
            passedTimes = 0;//���Ԃ��O�Ƀ��Z�b�g
            //�C�e���v���n�u������
            Vector2 pos = new Vector2(gateTransform.position.x, gateTransform.position.y);
            GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
            //�C�g�������Ă�������ɔ��˂���
            Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
            float angleZ = transform.localEulerAngles.z;
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector2 v = new Vector2(x, y) * fireSpeed;
            rbody.AddForce(v, ForceMode2D.Impulse);

            audioSource.PlayOneShot(se_Shoot);



        }
    }
    //�͈͕\��
     void OnDrawGizmos()
    {
        
    }
}
