using UnityEngine;

public class ShellController : MonoBehaviour
{
    [Header("��������")]
    public float deleteTime = 3.0f;//�폜���鎞�Ԏw��
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,deleteTime);//�폜�ݒ�

    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        Destroy(gameObject);//�����ɐڐG���������
    }
}
