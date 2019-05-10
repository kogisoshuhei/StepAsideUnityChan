using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	//Unityちゃんのオブジェクト
	private GameObject unitychan;

	void Start(){

		//Unityちゃんオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");

	}

	void Update(){

		if (this.transform.position.z < this.unitychan.transform.position.z - 10) {
		
			Destroy ( this.gameObject );
		
		}

	}
}
