using UnityEngine;
using System.Collections;

public class GameRunner : MonoBehaviour {

    public GameObject Player;
    public string PathName = "PlayerPath1";
    public int Time = 300;

    Hashtable playerPath = new Hashtable();
    
	void Start () {
        //iTween.MoveTo(Player, iTween.Hash("path", iTweenPath.GetPath(PathName), "time", Time));
	}
	
	void Update () {
	
	}
}
