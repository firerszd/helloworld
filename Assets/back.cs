using UnityEngine;
using System.Collections;

public class back : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public  void backToStart()
    {
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => { Application.LoadLevel("load"); }, 3.0f));
    }
}
