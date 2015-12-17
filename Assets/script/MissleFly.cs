using UnityEngine;
using System.Collections;

public class MissleFly : MonoBehaviour {

    public float damage = 10.0f;
    public float speed = 0.5f;
    public float DestroyTime = 10.0f;
    private Vector3 velocity;
    private Vector3 StartPositon;
    private Transform Target;
    public GameObject BoomPrefab;
    private Vector3 rotate =  new Vector3(-2, -1, 0);

    private int nStep = 0;
	// Use this for initialization
	void Start () { 
        velocity = rotate * speed; 
        Destroy(gameObject, DestroyTime);
        StartPositon = transform.position; 
        //LookForTarget();
	}

    private void LookForTarget()
    {
        float fDistance = 10000;
        GameObject group = GameObject.Find("group");
        if (null == group)
        { return; }
       foreach(Transform child in group.transform)
       {
           float dis = Vector3.Distance(child.position, StartPositon);
           if(dis < fDistance)
           {
               Target = child;
               fDistance = dis;
           }
       }         
    }
	
	// Update is called once per frame
	void Update () {
        if(Target == null)
        {
            nStep = 2;
        }
        if (nStep == 2)
        {
            velocity = transform.forward * speed;
            transform.position += velocity * Time.deltaTime * 300;
            return;
        }

        float dis = Vector3.Distance(Target.position, transform.position);
        if(dis < 2)
        {
            Destroy(Target.gameObject);
            GameObject projectile = (GameObject)Instantiate(BoomPrefab, Target.position + Target.forward * -0.8f, Target.rotation);
            Destroy(transform.gameObject);
            return;
        }
        if (nStep == 1)
        {
            if(Target != null)
            {
                transform.LookAt(Target.position);
            }          
            velocity = transform.forward * speed; 
            transform.position += velocity * Time.deltaTime * 300;
            return;
        }
        transform.position += velocity * Time.deltaTime * 30; 
        if(Vector3.Distance(StartPositon, transform.position) > 10)
        {
            nStep = 1;
        }
	}

    public void SetTarget(Transform tar)
    {
        Target = tar;        
    }

    public void SetRo(Vector3 param)
    {
        rotate = param;
    }
}
