using UnityEngine;
using System.Collections;

public class cooldown : MonoBehaviour {

    private float cds = 1.0f;

    private bool inCD = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
 
	
	}

    public void Cooldown()
    {
        cds = 1.0f;
        inCD = true;

    }

    void FixedUpdate()
    {
        if(!inCD)
        { return; }
        cds -= 0.01f;
        if (cds < 0.01f)
        {
            inCD = false;
           
        }
        transform.GetComponent<UITexture>().fillAmount = cds;

    }
}
