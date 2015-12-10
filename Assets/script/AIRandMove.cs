using UnityEngine;
using System.Collections;
using System.Timers;

public class AIRandMove : MonoBehaviour {
     
    public float speed = 0.5f; 
    /// <summary>
    /// 最大、最小飞行界限
    /// </summary>
    float maxPos_x = 500;
    float maxPos_y = 500;
    float minPos_x = 0;
    float minPos_y = 0;
    private GameObject RolePlane;
    private bool bCanFollow;
    Timer test;
    // 索敌距离
    public float fDistance = 80;
    // 方向
    private Vector3 velocity;
    // 子弹
    public GameObject projectilePrefab;
    // 是否可以射击
    private bool bShot = false; 
    // 间隔
    private long fixedTime = 1;
    // 射击时间 
    private long nowTime;  
  
    // int max_Flys = 128;
    // Use this for initialization
    void Start()
    {
        //Change();
        RolePlane = GameObject.Find("GameObjectPlane");
        nowTime = (System.DateTime.Now.Ticks - System.DateTime.Parse("1970-01-01").Ticks) / 10000000;  
    }

    // Update is called once per frame
    void Update()
    {
        long timeme = (System.DateTime.Now.Ticks - System.DateTime.Parse("1970-01-01").Ticks) / 10000000;
        if (null == RolePlane) { return; }
        bool bIsStop = CheckStop();
        if (bShot && timeme - nowTime > fixedTime)
        {
            nowTime = timeme;
            Shot();
        }
        if (bIsStop || !bCanFollow) { return; }
        bool bFollowRole = CheckFollowRole(); 

        if (!bFollowRole)
        {
            Check(); 
        }     
        transform.position += velocity * Time.deltaTime * 150;  
    }

    private bool CheckStop()
    {
        if (null == RolePlane) { return false; }
        if (Vector3.Distance(RolePlane.transform.position, transform.position) < 20)
        {
            bCanFollow = false;
            return true;
        }
        else
        if (Vector3.Distance(RolePlane.transform.position, transform.position) > 50)
        {
            bCanFollow = true;
            return false;
        }
        return false;
    }

    private bool CheckFollowRole()
    {
        if (null == RolePlane) { return false; }
        if (Vector3.Distance(RolePlane.transform.position, transform.position) < fDistance)
        {
            transform.LookAt(new Vector3(RolePlane.transform.localPosition.x, transform.position.y, RolePlane.transform.localPosition.z));
            velocity = transform.forward * speed;
            // 开启射击计时器 
            bShot = true;
            return true;
        } 
        return false;
         
    }
     
  
    void Check()
    {
        int nPosX = Random.Range(20, 580);
        int nPosZ = Random.Range(20, 580);

        //如果到达预设的界限位置值，调换速度方向并让它当前的坐标位置等于这个临界边的位置值
        if (transform.localPosition.x > maxPos_x)
        {
            // transform.LookAt(new Vector3(-transform.position.x, transform.position.y, -transform.position.z ));  
            transform.LookAt(new Vector3(nPosX, transform.position.y, nPosZ));
        }
        if (transform.localPosition.x < minPos_x)
        {
            //transform.LookAt(new Vector3(-transform.position.x, transform.position.y, -transform.position.z)); 
            transform.LookAt(new Vector3(nPosX, transform.position.y, nPosZ));
        }
        if (transform.localPosition.z > maxPos_y)
        {
            // transform.LookAt(new Vector3(-transform.position.x, transform.position.y, -transform.position.z)); 
            transform.LookAt(new Vector3(nPosX, transform.position.y, nPosZ));           
        }
        if (transform.localPosition.z < minPos_y)
        {
            // transform.LookAt(new Vector3(-transform.position.x, transform.position.y, -transform.position.z));
            transform.LookAt(new Vector3(nPosX, transform.position.y, nPosZ));
        }
        velocity = transform.forward * speed;
    }

    void Shot()
    {
        Vector3 test1 = transform.position + transform.forward * -0.8f;
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position + transform.forward * -0.8f + new Vector3(0, -1, 0), transform.rotation);
    }
}
