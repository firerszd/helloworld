using UnityEngine;
using System.Collections;

public class BasicGun : MonoBehaviour {

    public float damage = 10.0f;
    public float speed = 0.5f;
    public float DestroyTime = 3.0f;
    private Vector3 velocity;
	// Use this for initialization
	void Start () {
        velocity = transform.forward * speed;
        Destroy(gameObject, DestroyTime); 
	
	}
	
	// Update is called once per frame
    void Update()
    { 
        transform.position += velocity * Time.deltaTime * 300;	
	}
}
