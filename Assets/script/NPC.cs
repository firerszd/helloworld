using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    //主摄像机对象
    private Camera camera;
    //NPC名称
    private string name = "主角";

    //主角对象
    public GameObject hero;
    //NPC模型高度
    float npcHeight;
    //红色血条贴图
    public Texture2D blood_red;
    //黑色血条贴图
    public Texture2D blood_black;

    public int HP = 100;
    public GameObject projectilePrefab;

    public GameObject startEffect;

    void Start()
    {
        //根据Tag得到主角对象
        hero = GameObject.FindGameObjectWithTag("roleme");
        //得到摄像机对象
        camera = Camera.main;

        //注解1
        //得到模型原始高度
        float size_y = transform.GetComponent<Collider>().bounds.size.y;
        //得到模型缩放比例
        float scal_y = transform.localScale.y;
        //它们的乘积就是高度
        npcHeight = (size_y * scal_y);
        if(startEffect != null)
        {
            Instantiate(startEffect, transform.position, transform.rotation);
            Destroy(startEffect, 1000);     
        }   

    }

    void Update()
    {
        //保持NPC一直面朝主角
        transform.LookAt(hero.transform); 
    }

    public void OnGUI()
    { 
        //得到NPC头顶在3D世界中的坐标
        //默认NPC坐标点在脚底下，所以这里加上npcHeight它模型的高度即可
        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + npcHeight + 10, transform.position.z);
        //根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
        Vector2 position = camera.WorldToScreenPoint(worldPosition);
        //得到真实NPC头顶的2D坐标
        position = new Vector2(position.x, Screen.height - position.y);
        //注解2
        //计算出血条的宽高
        Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(blood_red));

        //通过血值计算红色血条显示区域
        int blood_width = blood_red.width * HP / 100;
        //先绘制黑色血条
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y, bloodSize.x, bloodSize.y), blood_black);
        //在绘制红色血条
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y, blood_width, bloodSize.y), blood_red);

        //注解3
        //计算NPC名称的宽高
        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(name));
        //设置显示颜色为黄色
        GUI.color = Color.yellow;
        //绘制NPC名称
        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y - bloodSize.y, nameSize.x, nameSize.y), name);
    }

    public void ReduceHP(int nPoint)
    {
        HP = HP - nPoint; 
        if(HP < 1)
        {
            Destroy(transform.gameObject);
            GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, transform.rotation);
            GameObject wholeObject = GameObject.Find("GameObjectPlane");
            if(null != wholeObject)
            {
               // wholeObject.GetComponent<back>().backToStart();
            }
        }
    } 
 
 
    ////下面是经典鼠标点击对象的事件，大家看一下就应该知道是什么意思啦。
    //void OnMouseDrag()
    //{
    //    Debug.Log("鼠标拖动该模型区域时");
    //}

    //void OnMouseDown()
    //{
    //    Debug.Log("鼠标按下时");

    //    if (HP > 0)
    //    {
    //        HP -= 5;
    //    }

    //}
    //void OnMouseUp()
    //{
    //    Debug.Log("鼠标抬起时");
    //}

    //void OnMouseEnter()
    //{
    //    Debug.Log("鼠标进入该对象区域时");
    //}
    //void OnMouseExit()
    //{
    //    Debug.Log("鼠标离开该模型区域时");
    //}
    //void OnMouseOver()
    //{
    //    Debug.Log("鼠标停留在该对象区域时");
    //}
}
