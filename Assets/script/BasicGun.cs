using UnityEngine;
using System.Collections;

public class BasicGun : MonoBehaviour {

    public float damage = 10.0f;
    public float speed = 0.5f;
    public float DestroyTime = 1.0f;
    private Vector3 velocity;
	// Use this for initialization
	void Start () {
        velocity = transform.forward * speed;
        Destroy(gameObject, DestroyTime);
        Debug.Log("hehe " + velocity.x.ToString() + " " + velocity.y.ToString() + " " + velocity.z.ToString());
	
	}
	
	// Update is called once per frame
    void Update()
    {
        //Debug.Log("gege " + velocity.x.ToString());
        transform.position += velocity * Time.deltaTime * 300;
	
	}
}
