using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

	int level, score;

	public ScoreSystem() {
		this.level = 0;
		this.score = 0;
	}

	public void firstRight(){
		this.score += 2;
		updateLevel ();
	}

	public void secondRight(){
		this.score += 1;
		updateLevel ();
	}
	private void updateLevel(){
		this.level = this.score / 10;
	}
}
