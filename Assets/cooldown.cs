using UnityEngine;
using System.Collections;

public class cooldown : MonoBehaviour {

    private float cds = 1.0f;
    public float offX = 0.0f;
    public float offY = 0.0f;

    private bool inCD = false;

    private int mSecond = 1;
	// Use this for initialization
    void Start()
    { 
        transform.GetComponent<UITexture>().fillAmount = 0.0f; 
    }
	
	// Update is called once per frame
	void Update () {
 
	
	}

    public void Cooldown(int nSecond)
    {
        cds = 1.0f;
        inCD = true;
        mSecond = nSecond;
    }

    void FixedUpdate()
    {
        if(!inCD)
        { return; }
        cds = cds - 1 /(mSecond / 0.02f);
        if (cds < 1 / (mSecond / 0.02f))
        {
            inCD = false;
           
        }
        transform.GetComponent<UITexture>().fillAmount = cds;

    }
}
