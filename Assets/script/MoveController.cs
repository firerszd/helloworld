using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

	// Use this for initialization

    public GameObject Bullet;
    public GameObject Missile;
    public float fireRate = 0.01f;

    private float nextFire = 0.0f;
    private GameObject gmc;

    // 控制火的大小
    private Transform fire;
	void Start () {
        Debug.Log("startMeth");
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
        Debug.Log("OnJoystickMoveEnd");
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
        Debug.Log("OnJoystickMove");
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
            transform.Translate(Vector3.forward * Time.deltaTime * 50);
            //播放奔跑动画   
            //Transform tChild = transform.GetComponentInChildren<Transform>().FindChild("Serapia Binder");
            //tChild.GetComponent<Animator>().Stop();
            if(null != fire)
            {
                fire.localScale = (new Vector3(8, 3, 3)); 
            }
            gmc.transform.position = transform.position + (new Vector3(5, 50, -60));
        }
    }
    void Shot()
    { 
        Vector3 test1 = transform.position + transform.forward * -0.8f;
        GameObject projectile = (GameObject)Instantiate(Bullet, transform.position + transform.forward * -0.8f + new Vector3(0, -1, 0), transform.rotation); 
         
        //nextFire = Time.time + fireRate;
    }

    void LaunchMissile()
    {
        GameObject projectile = (GameObject)Instantiate(Missile, transform.position + transform.forward * -0.8f + new Vector3(0, -1, 0), transform.rotation);
    }

}
