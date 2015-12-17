using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowMoreButton()
    {
        GameObject uiroot = GameObject.Find("UI Root");
        if(!uiroot)
        {
            return;
        }
        //GameObject projectile = (GameObject)Instantiate(new GameObject(), transform.position, transform.rotation);
        //projectile.AddComponent<UIButton>();
        //projectile.AddComponent<UILabel>();
        //projectile.GetComponent<UILabel>().text = "hehe";
        //projectile.transform.parent = uiroot.transform;
    }
}
