using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class MoveController : MonoBehaviour
{

	// Use this for initialization

    public GameObject Bullet;
    public GameObject Missile;
    public float fireRate = 0.01f;

    private float nextFire = 0.0f;
    private GameObject gmc;

    private long fTimeNow;
    private bool nShot;

    private int MissileCD = 4;

    // 控制火的大小
    private Transform fire;
    void Start()
    {        
        Debug.Log("startMeth" + this.ToString());
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd; 
        gmc = GameObject.Find("Camera"); 

        // 找到火
        Transform tChild = transform.GetComponentInChildren<Transform>().FindChild("Serapia Binder"); 
        if(null == tChild)
        { return; }
        Transform tChild2 = tChild.GetComponentInChildren<Transform>().FindChild("FT FreeSample --- RocketFire01"); 
        if(null == tChild2)
        { return; }
        fire = tChild2;  
	
	} 

	// Update is called once per frame
	void Update () {
	
	}

    //移动摇杆结束   
    void OnJoystickMoveEnd(MovingJoystick move)
    { 
        //停止时，角色恢复idle   
        if (move.joystickName == "New joystick")
        {
            //Transform tChild = transform.GetComponentInChildren<Transform>().FindChild("Serapia Binder"); 
            //tChild.GetComponent<Animator>().Play("fly");
            //Debug.Log("end");
        }
        if (null != fire)
        {
            fire.localScale = (new Vector3(5, 3, 3)); 
        }
    }


    //移动摇杆中   
    void OnJoystickMove(MovingJoystick move)
    {
        Debug.Log("OnJoystickMove" + this.ToString());
        if (move.joystickName != "New joystick")
        {
            return;
        } 
        //获取摇杆中心偏移的坐标   
        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;


        if (joyPositionY != 0 || joyPositionX != 0)
        {
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）   

            transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            //移动玩家的位置（按朝向位置移动）   
            Debug.Log("OnJoystickMove3");
            transform.Translate(Vector3.forward * Time.deltaTime * 50);
            //播放奔跑动画   
            //Transform tChild = transform.GetComponentInChildren<Transform>().FindChild("Serapia Binder");
            //tChild.GetComponent<Animator>().Stop();
            if(null != fire)
            {
                fire.localScale = (new Vector3(8, 3, 3));
            }
            Debug.Log("OnJoystickMove4");
            gmc.transform.position = transform.position + (new Vector3(5, 50, -60));
        }
    }
    void Shot()
    { 
        Vector3 test1 = transform.position + transform.forward * -0.8f;
        GameObject projectile = (GameObject)Instantiate(Bullet, transform.position + transform.forward * -0.8f , transform.rotation); 
         
        //nextFire = Time.time + fireRate;
    }

    void LaunchMissile()
    {
        if ((DateTime.Now.ToFileTime() - fTimeNow) / 10000000 < MissileCD)
        {
            return;
        }
        fTimeNow = DateTime.Now.ToFileTime();
        GameObject cdTexture = GameObject.Find("MissileCD");
        if (cdTexture != null)
        {
            cdTexture.GetComponent<cooldown>().Cooldown(MissileCD);
        }
        GameObject projectile = (GameObject)Instantiate(Missile, transform.position + transform.forward * -0.8f + new Vector3(0, -1, 0), transform.rotation);
        float fDistance = 10000;
        GameObject group = GameObject.Find("group");
        if (null == group)
        { return; }
        Transform tempTrans = null;
        foreach (Transform child in group.transform)
        {
            float dis = Vector3.Distance(child.position, transform.position);
            if (dis < fDistance)
            {
                tempTrans = child;
                fDistance = dis;
            }
        }
        if(!tempTrans)
        { return; }
        projectile.GetComponent<MissleFly>().SetTarget(tempTrans);
  
      
    }

    void LaunchMoreMissile()
    { 
        GameObject group = GameObject.Find("group");
        if (null == group)
        { return; }
        List<int> shuzu = new List<int>();
        foreach (Transform child in group.transform)
        {
            float dis = Vector3.Distance(child.position, transform.position);
            shuzu.Add((int)dis);
        
        }
        shuzu.Sort();
        int x = 0;
        Vector3 nexV = new Vector3();
        foreach(int i in shuzu)
        {
            ++x;
            if (x > 3)
            { break; }
            foreach (Transform child in group.transform)
            {
                float dis = Vector3.Distance(child.position, transform.position);
                if(i == (int)dis)
                {
                    if(x == 1)
                    { nexV = new Vector3(0, -1, 0); }
                    else if(x == 2)
                    { nexV = new Vector3(1, -1, 0); }
                    else if (x == 3)
                    { nexV = new Vector3(-1, -1, 0); }
                    nexV += transform.forward;
                    GameObject projectile = (GameObject)Instantiate(Missile, transform.position + transform.forward * -0.8f, transform.rotation);
                    projectile.GetComponent<MissleFly>().SetRo(nexV);
                    projectile.GetComponent<MissleFly>().SetTarget(child);
                }
            }
        }
 
    }

}
