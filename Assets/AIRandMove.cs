using UnityEngine;
using System.Collections;

public class AIRandMove : MonoBehaviour {

    float stopTime;
    float moveTime;
    public float speed = 0.5f;
    float vel_x, vel_y, vel_z;//速度
    /// <summary>
    /// 最大、最小飞行界限
    /// </summary>
    float maxPos_x = 500;
    float maxPos_y = 500;
    float minPos_x = 0;
    float minPos_y = 0;
    int curr_frame;
    int total_frame;
    float timeCounter1;
    float timeCounter2;

    private Vector3 velocity;
    // int max_Flys = 128;
    // Use this for initialization
    void Start()
    {
        velocity = transform.forward * speed;
        //Change();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += velocity * Time.deltaTime * 300;
        //timeCounter1 += Time.deltaTime;
        //if (timeCounter1 < moveTime)
        //{
        //    transform.Translate(vel_x, 20, vel_y, Space.Self);
        //}
        //else
        //{
        //    timeCounter2 += Time.deltaTime;
        //    if (timeCounter2 > stopTime)
        //    {
        //        Change();
        //        timeCounter1 = 0;
        //        timeCounter2 = 0;
        //    }
        //}
        Check();
    }
    void Change()
    {
        stopTime = Random.Range(1, 5);
        moveTime = Random.Range(1, 20);
        vel_x = Random.Range(1, 10);
        vel_y = Random.Range(1, 10);
    }
    void Check()
    {
        //如果到达预设的界限位置值，调换速度方向并让它当前的坐标位置等于这个临界边的位置值
        if (transform.localPosition.x > maxPos_x)
        {
            transform.Rotate(-transform.rotation.x, transform.rotation.y, transform.rotation.z);
            //vel_x = -vel_x;
            //transform.localPosition = new Vector3(maxPos_x, 20, transform.localPosition.y);
        }
        if (transform.localPosition.x < minPos_x)
        {
            transform.Rotate(-transform.rotation.x, transform.rotation.y, transform.rotation.z);
            //vel_x = -vel_x;
            //transform.localPosition = new Vector3(minPos_x, 20, transform.localPosition.y);
        }
        if (transform.localPosition.z > maxPos_y)
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, -transform.rotation.z);
            //vel_y = -vel_y;
            //transform.localPosition = new Vector3(transform.localPosition.x, 20, maxPos_y);
        }
        if (transform.localPosition.z < minPos_y)
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, -transform.rotation.z);
            //vel_y = -vel_y;
            //transform.localPosition = new Vector3(transform.localPosition.x, 20, minPos_y);
        }
    }
}
