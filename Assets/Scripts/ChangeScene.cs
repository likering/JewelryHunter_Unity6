using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public string SceneName;//�؂�ւ������V�[�������w��

    //�V�[����؂�ւ���@�\�����������\�b�h�쐬
    public void Load()
    {
        //�����Ɏw�肵�����O�̃V�[���ɐ؂�ւ����Ă���郁�\�b�h�̌Ăяo��
        SceneManager.LoadScene(SceneName);

    }
}
