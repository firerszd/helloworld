﻿using UnityEngine;
using System.Collections;

public class createPlane : MonoBehaviour {

    public GameObject projectilePrefab;
	// Use this for initialization
	void Start () { 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateNewPlane()
    {
        GameObject group = GameObject.Find("group");
        if (null == group)
        { return; }
        int nCount = group.GetComponentInChildren<Transform>().childCount;
        if(nCount > 6)
        { return; }
        int nPosX = Random.Range(20, 580);
        int nPosZ = Random.Range(20, 580);         

        GameObject projectile = (GameObject)Instantiate(projectilePrefab, new Vector3(nPosX, 20, nPosZ), transform.rotation);
        projectile.transform.parent = group.transform;
        //CreateNewPlane();
        Debug.Log("Create");

    }
}
