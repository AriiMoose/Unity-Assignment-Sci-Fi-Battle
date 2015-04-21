using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace BGE
{
	class Lazer:MonoBehaviour
	{
	    public String lazerTargetTag;
	    public GameObject lazerTarget;
	    private LineRenderer line;
	    private Vector3 targetPos;
	    private ParticleSystem explosion;

	    public void Start()
	    {
	        line = gameObject.GetComponent<LineRenderer>();
	        line.enabled = false;
	    }

        public void Update()
        {
            if (lazerTarget == null && lazerTargetTag != null)
            {
                lazerTarget = GameObject.FindGameObjectWithTag("Turian");
            }

            targetPos = lazerTarget.transform.position - transform.position;

            if (Physics.Raycast(transform.position, targetPos, 70.0f))
            {
                lazerTarget.GetComponent<ParticleSystem>().Play();

                StopCoroutine("shoot");
                StartCoroutine("shoot");
                
            }
        }

        IEnumerator shoot()
	    {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, targetPos);
            line.enabled = true;

            Destroy(lazerTarget);

            yield return new WaitForSeconds(1);
            line.enabled = false;
	    }
	}
}
