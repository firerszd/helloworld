using UnityEngine;
using System.Collections;

public class EnemyBoomHit : MonoBehaviour {

    public GameObject projectilePrefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 碰到边缘 重新生成背景的物体  这里才是判断是否生成新的游戏物体的前提
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "roleme")
        {
            other.GetComponent<NPC>().ReduceHP(1); 
            Destroy(transform.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}
