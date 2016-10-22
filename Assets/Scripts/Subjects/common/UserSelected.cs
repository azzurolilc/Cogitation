using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.IO;

public class UserSelected : MonoBehaviour {

	public Text targetText;
	private Button myButton;
	public string str;
	public Text scoreText;
	public Text levelText;

	void OnEnable() {
		myButton = GetComponent<Button>();
		myButton.onClick.AddListener(() => {ChangeTarget();});
	}

	void ChangeTarget() {
		string username = EventSystem.current.currentSelectedGameObject.name;
		targetText.text = "Nice to see you again, " + username;

		//StreamReader r = new StreamReader ("file.json");

		string userdatapath = Application.dataPath + "/Data/users";

		DirectoryInfo dir = new DirectoryInfo(userdatapath);
		FileInfo[] info = dir.GetFiles("*.json");
		foreach (FileInfo f in info) {
			if (f.Name.ToString().Equals(username + ".json")) {
				StreamReader r = new StreamReader (userdatapath + "/" + username + ".json");

				str = r.ReadLine ();
				while (!str.Equals ("")) {
					if (str.Contains ("score")) {
						str = r.ReadLine ();
						int start1 = str.IndexOf (":") + 2;
						int end1 = str.LastIndexOf (",");
						int matscore = int.Parse(str.Substring (start1, end1 - start1));

						str = r.ReadLine ();
						int start2 = str.IndexOf (":") + 2;
						int end2 = str.LastIndexOf (",");
						int geoscore = int.Parse(str.Substring (start2, end2 - start2));

						str = r.ReadLine ();
						int start3 = str.IndexOf (":") + 2;
						int end3 = str.LastIndexOf (",");
						int engscore = int.Parse(str.Substring (start3, end3 - start3));

						scoreText.text = "Math score: " + matscore + "  Geo score: " + geoscore + "  Eng score: " + engscore;

					} else if (str.Contains ("level")) {
						str = r.ReadLine ();
						int start1 = str.IndexOf (":") + 2;
						int end1 = str.LastIndexOf (",");
						int matlevel = int.Parse(str.Substring (start1, end1 - start1));

						str = r.ReadLine ();
						int start2 = str.IndexOf (":") + 2;
						int end2 = str.LastIndexOf (",");
						int geolevel = int.Parse(str.Substring (start2, end2 - start2));

						str = r.ReadLine ();
						int start3 = str.IndexOf (":") + 2;
						int end3 = str.LastIndexOf (",");
						int englevel = int.Parse(str.Substring (start3, end3 - start3));

						levelText.text = "Math level: " + matlevel + "  Geo level: " + geolevel + "  Eng level: " + englevel;

					}

					str = r.ReadLine ();
				}


			}
		}

	}
}

public class ReadUser {
	string name;
	Score score;
	Level level;
}

public class Score {
	int mat, geo, eng;
}

public class Level {
	int mat, geo, eng;
}
