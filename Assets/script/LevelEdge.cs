using UnityEngine;
using System.Collections;

public class LevelEdge : MonoBehaviour {

    public GameObject projectilePrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 碰到边缘 重新生成背景的物体  这里才是判断是否生成新的游戏物体的前提
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "enemy")
        {
            Destroy(other.GetComponent<Collider>().gameObject);
            GameObject projectile = (GameObject)Instantiate(projectilePrefab, other.GetComponent<Collider>().transform.position + other.GetComponent<Collider>().transform.forward * -0.8f + new Vector3(0, -1, 0), other.GetComponent<Collider>().transform.rotation);
            Destroy(transform.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
    
    }
     
}
