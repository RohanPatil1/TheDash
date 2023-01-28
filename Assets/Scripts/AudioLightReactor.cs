using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; //2019 VERSIONS
public class AudioLightReactor : MonoBehaviour
{
	private Light2D playerLight;
	private  AudioSource audioSource;
	public float updateStep = 0.1f;
	public int sampleDataLength = 1024;

	private float currentUpdateTime = 0f;
	public  Light2D myLight;

	private float clipLoudness;
	private float[] clipSampleData;

	//public GameObject cube;
	public float sizeFactor = 1.7f;

	

	// Use this for initialization
	private void Awake()
		{
		audioSource = GetComponent<AudioSource>();
		clipSampleData = new float[sampleDataLength];
	}

	// Update is called once per frame
	private void Update()
	{
		currentUpdateTime += Time.deltaTime;
		if (currentUpdateTime >= updateStep)
		{
			currentUpdateTime = 0f;
			audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
			clipLoudness = 0f;
			foreach (var sample in clipSampleData)
			{
				clipLoudness += sample;
			}
			clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

			clipLoudness *= sizeFactor;
			clipLoudness = Mathf.Clamp(clipLoudness*7, 1, 10);
			//Debug.Log("AUDIO LOUDNESS: "+clipLoudness);
			//cube.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
			myLight.intensity = 1 + clipLoudness;

		}
	}
}
