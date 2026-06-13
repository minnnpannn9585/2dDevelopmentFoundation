using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootForce;

    [Header("对象池设置")]
    public int poolSize = 100; // 预先生成的子弹数量
    private List<GameObject> bulletPool;

    void Start()
    {
        // 游戏开始时初始化对象池
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false); // 初始设为隐藏状态
            bulletPool.Add(bullet);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // 从对象池获取可用子弹
            GameObject bullet = GetBulletFromPool();
            
            if (bullet != null)
            {
                // 重置初始位置和旋转
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity;
                // 激活子弹使其显示在场景中
                bullet.SetActive(true);

                // 获取刚体组件，重置之前的残留速度，再施加新的力
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero; 
                    rb.AddForce(new Vector2(shootForce, 0));
                }
            }
        }
    }

    // 从对象池中寻找未被使用的子弹
    private GameObject GetBulletFromPool()
    {
        // 遍历整个池子
        for (int i = 0; i < bulletPool.Count; i++)
        {
            // 如果遇到没有激活（隐藏）的，就说明当前空闲可用
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }

        // 如果现有子弹全部在屏幕上飞（不够用），则临时动态扩容
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        bulletPool.Add(newBullet);
        return newBullet;
    }
}