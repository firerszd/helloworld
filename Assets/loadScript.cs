using UnityEngine;
using System.Collections;

public class loadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       GameObject textture = GameObject.Find("Texture");
        if(textture == null)
        { return; } 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
	void Awake () 
	{	
                //获取需要监听的按钮对象
		GameObject button = GameObject.Find("Control - Simple Button");
                //设置这个按钮的监听，指向本类的ButtonClick方法中。
		UIEventListener.Get(button).onClick = ButtonClick;

        float fWith = Screen.width;
        float fHeight = Screen.height;
        float fScleX = fWith / 1024;
        float fScleY = fHeight / 512;

        GameObject loadTU = GameObject.Find("loadTU");
        if(loadTU != null)
        {
            loadTU.transform.localScale *= (fScleX > fScleY ?fScleX:fScleY);
        }

	}

    //计算按钮的点击事件
    void ButtonClick(GameObject button)
    {
        Debug.Log("GameObject " + button.name);
        Application.LoadLevel("main");

    }
}
