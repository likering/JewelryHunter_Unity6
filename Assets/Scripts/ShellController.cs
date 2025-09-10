using UnityEngine;

public class ShellController : MonoBehaviour
{
    [Header("¶‘¶ŠÔ")]
    public float deleteTime = 3.0f;//íœ‚·‚éŠÔw’è
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,deleteTime);//íœİ’è

    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        Destroy(gameObject);//‰½‚©‚ÉÚG‚µ‚½‚çÁ‚·
    }
}
