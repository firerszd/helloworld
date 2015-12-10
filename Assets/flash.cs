using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {

    private bool isShow;
    float timenow;
	// Use this for initialization
	void Start () { 
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(isShow.ToString());
        isShow = !isShow;
        if (Time.time - timenow > 0.4)
        {
            timenow = Time.time;
            transform.GetComponent<UILabel>().enabled = isShow;
        }
        Debug.Log(Time.time.ToString());
	}
     
}
