using UnityEngine;
using System.Collections;

public class MissleFly : MonoBehaviour {

    public float damage = 10.0f;
    public float speed = 0.5f;
    public float DestroyTime = 10.0f;
    private Vector3 velocity;
    private Vector3 StartPositon;
    private Transform Target;

    private int nStep = 0;
	// Use this for initialization
	void Start () {
        velocity = (new Vector3(0,-1,0)) * speed; 
        Destroy(gameObject, DestroyTime);
        StartPositon = transform.position;
        LookForTarget();
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
}
