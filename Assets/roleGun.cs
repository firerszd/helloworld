using UnityEngine;
using System.Collections;

public class roleGun : MonoBehaviour {

    private GameObject group;
    public GameObject projectilePrefab;
	// Use this for initialization
	void Start () {

        group = GameObject.Find("group");
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(null == group)
        { return; }
        foreach (Transform child in group.transform)
        {
            float dis = Vector3.Distance(child.position, transform.position);
            if (dis < 10)
            {
                Destroy(child.gameObject);
                GameObject projectile = (GameObject)Instantiate(projectilePrefab, child.transform.position + child.transform.forward * -0.8f + new Vector3(0, -1, 0), child.transform.rotation);
                Destroy(transform.gameObject);
            }
        }       
	}
}
