using UnityEngine;
using LibNoise;
using System.Collections;

public class Static : MonoBehaviour {
	Texture2D tex;
	Perlout noise;
	// Use this for initialization
	void Start () {
		tex = new Texture2D(32,32);
		tex.wrapMode = TextureWrapMode.Clamp;
		noise = new Perlout();
		StartCoroutine(UpdateImage());
	}

	IEnumerator UpdateImage(){
		int pixels = tex.width * tex.height;
		int width = tex.width;
		Color[] colors = new Color[pixels];
		
		while (true)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			timer.Start();
			
			float depth = Time.time / 2f;
			
			for (int i = 0; i < pixels; i++)
			{
				float value;
				value = (float)noise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
				colors[i] = new Color(value, value, value);
			}
			
			tex.SetPixels(colors);
			
			tex.Apply();
			
			timer.Stop();
			
			yield return null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.mainTexture = tex;
	}
}
