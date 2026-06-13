using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 碰到设置为触发器 (Is Trigger) 的物体时调用
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            return;
        }

        gameObject.SetActive(false);

        
    }
}