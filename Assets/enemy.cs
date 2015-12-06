using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {

        Debug.Log("Create");
        GameObject gmc = GameObject.Find("GameObject");

        if (null == gmc)
        { return; }

        gmc.GetComponent<createPlane>().CreateNewPlane();

    }
}
