using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAlternator : MonoBehaviour {

	public GameObject ActiveWave;
	public GameObject InactiveWave;

	AudioSource activeAudio;
	AudioSource inactiveAudio;

	// Use this for initialization
	void Start () {
		activeAudio = ActiveWave.GetComponent<AudioSource> ();
		inactiveAudio = InactiveWave.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (InBuildPhase ()) {
			activeAudio.Stop ();
			inactiveAudio.Play ();
		} 
		else 
		{
			inactiveAudio.Stop ();
			activeAudio.Play ();
		}
	}

	bool InBuildPhase ()
	{
		return MenuScript.instance ().WeAreInBuildPhase ();
	}
}
