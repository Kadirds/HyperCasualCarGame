using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMarks : MonoBehaviour
{
    private TrailRenderer skidMark;
    private ParticleSystem smoke;
    public ArcadeVehicleController carController;
    private void Awake()
    {
        smoke = GetComponent<ParticleSystem>();
        skidMark = GetComponent<TrailRenderer>();
	    skidMark.emitting = false;
        skidMark.startWidth = carController.skidWidth;

    }
    
    
	private void OnEnable()
	{
		skidMark.enabled = true;
	}
	private void OnDisable()
	{
		skidMark.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (carController.grounded())
        {

            if (Mathf.Abs(carController.carVelocity.x) > 10)
            {
                skidMark.emitting = true;
            }
            else
            {
                skidMark.emitting = false;
            }
        }
        else
        {
            skidMark.emitting = false;
        }

        // smoke
        if (skidMark.emitting == true)
        {
            smoke.Play();
        }
        else { smoke.Stop(); }

    }
}
