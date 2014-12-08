/*
	This script is placed in public domain. The author takes no responsibility for any possible harm.
	Contributed by Jonathan Czeck
*/
using UnityEngine;
using System.Collections;

public class LightningBolt : MonoBehaviour
{
	public Transform target;
	public int zigs = 100;
	public float speed = 1f;
	public float scale = 1f;
	public Light startLight;
	public Light endLight;
	public ParticleSystem ps;
	private int particleCount;
	
	Perlin noise;
	float oneOverZigs;
	
	private ParticleSystem.Particle[] particles;
	
	void Start()
	{
		oneOverZigs = 1f / (float)zigs;
		ps.enableEmission = false;

		ps.Emit(zigs);

		particles = new ParticleSystem.Particle[100];
		particleCount = ps.GetParticles(particles);
	}
	
	void Update ()
	{
		if (noise == null)
			noise = new Perlin();
			
		float timex = Time.time * speed * 0.1365143f;
		float timey = Time.time * speed * 1.21688f;
		float timez = Time.time * speed * 2.5564f;
		
		for (int i=0; i < particleCount; i++)
		{
			Vector3 position = Vector3.Lerp(transform.position, target.position, oneOverZigs * (float)i);
			Vector3 offset = new Vector3(noise.Noise(timex + position.x, timex + position.y, timex + position.z),
										noise.Noise(timey + position.x, timey + position.y, timey + position.z),
										noise.Noise(timez + position.x, timez + position.y, timez + position.z));
			//Debug.Log("offset is: " + offset);
			//Debug.Log("position is: " + position);
			position += (offset * scale * ((float)i * oneOverZigs));

			//Debug.Log(" position after offset is: " + position);
			particles[i].position = position;
			particles[i].color = Color.white;
			particles[i].startLifetime = 1f;
		}

		ps.SetParticles (particles, particleCount);
		
		if (ps.particleCount >= 2)
		{
			if (startLight)
				startLight.transform.localPosition = particles[0].position;
			if (endLight)
				endLight.transform.localPosition = particles[particleCount - 1].position;
		}
	}	
}