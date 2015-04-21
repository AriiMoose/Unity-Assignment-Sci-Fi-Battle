using BGE;
using UnityEngine;
using System.Collections;

public class CameraMan : MonoBehaviour
{

    private Camera sov_cam;
    private Camera da_cam;
    private Camera norm_cam;

    private bool da_used;
    private bool sov_used;
    private bool norm_used;
    private bool fired;
	// Use this for initialization
	void Start ()
	{
	    sov_cam = GameObject.Find("Sovereign").GetComponentInChildren<Camera>();
	    da_cam = GameObject.Find("DestinyAscension").GetComponentInChildren<Camera>();
	    norm_cam = GameObject.Find("Normandy").GetComponentInChildren<Camera>();

	    sov_cam.enabled = true;

	    sov_used = true;
	    da_used = false;
	    norm_used = false;
	    fired = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if ((sov_used == true) && (da_used == false))
	    {
	        StartCoroutine(to_da());
            StopCoroutine(to_da());
	    }

	    if ((da_used == true && (norm_used == false)))
	    {
	        StartCoroutine(to_norm());
            StopCoroutine(to_norm());
	    }
	}

    IEnumerator to_da()
    {
        yield return new WaitForSeconds(20);

        sov_cam.enabled = false;
        da_cam.enabled = true;

        da_used = true;
    }

    IEnumerator to_norm()
    {
        yield return new WaitForSeconds(22);

        da_cam.enabled = false;
        norm_cam.enabled = true;

        norm_used = true;

        if (fired == false)
        {
            yield return new WaitForSeconds(5);
            GameObject.Find("Normandy").GetComponentInChildren<Lazer>().StartCoroutine("shoot");
            fired = true;
        }
        
    }
}
