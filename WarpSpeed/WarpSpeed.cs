using UnityEngine;
using System.Collections;


// From https://github.com/cbdileo/warp_speed
public class WarpSpeed : MonoBehaviour {
	public float WarpDistortion;
	public float Speed;
	ParticleSystem particles;
	ParticleSystemRenderer rend;
	bool isWarping;
	public SpeedUpmAN sp_man;

	void Awake()
	{
		particles = GetComponent<ParticleSystem>();
		rend = particles.GetComponent<ParticleSystemRenderer>();
	}

	void Update()
	{
		isWarping = sp_man.get_s();
		if(isWarping && !atWarpSpeed())
		{
			particles.startSize = 0.07f;
			rend.velocityScale += WarpDistortion * (Time.deltaTime * Speed);
		}

		if(!isWarping && !atNormalSpeed())
		{
			particles.startSize = 0;
			particles.Clear();
			rend.velocityScale = 0;
		}
	}

	public void Engage()
	{
		isWarping = true;
	}

	public void Disengage()
	{
		isWarping = false;
	}

	bool atWarpSpeed()
	{
		return rend.velocityScale < WarpDistortion;
	}

	bool atNormalSpeed()
	{
		return rend.velocityScale > 0;
	}
}
