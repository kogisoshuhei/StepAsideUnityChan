﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	//carPrefabを入れる
	public GameObject carPrefab;

	//coinPrefabを入れる
	public GameObject coinPrefab;

	//conePrefabを入れる
	public GameObject conePrefab;

	//スタート地点
	private int startPos = -160;

	//ゴール地点
	private int goalPos = 120;

	//アイテムを出すx方向の範囲
	private float posRange =3.4f;

	//Unityちゃんのオブジェクト
	private GameObject unitychan;

	//アイテムのポジション
	private int itemPos;


	// Use this for initialization
	void Start () {

		//Unityちゃんオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");

		//スタート地点をアイテムの座標に代入
		itemPos = startPos;
	
	}

	void Update () {

		//現在のアイテムの座標がUnitychanの座標より60m先にある、またはゴール位置がアイテムよりも奥にある
		if (this.unitychan.transform.position.z + 60 >= itemPos && itemPos < goalPos) {

			//アイテム生成ロジックを実行する
			generateItem ( itemPos );

			//アイテム位置に15mをプラスする
			itemPos += 15;

		}

	}

	void generateItem( int pos ){
	
		//どのアイテムを出すのかランダムに設定
		int num = Random.Range (1, 11);
		if (num <= 2) {

			//コーンをx軸方向に一直線に生成
			for (float j = -1; j <= 1; j += 0.4f) {

				//アイテムの種類を決める
				GameObject cone = Instantiate (conePrefab) as GameObject;
				cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, pos) ;

			}

		} else {

			//レーンごとにアイテムを生成
			for (int j = -1; j <= 1; j++) {
				//アイテムの種類を決める
				int item = Random.Range (1, 11);

				//アイテムを置くZ座標のオフセットをランダムに設定
				int offsetZ = Random.Range (-5, 6);

				//60%コイン配置：30%車配置：10%何もなし
				if (1 <= item && item <= 6) {

					//コインを生成
					GameObject coin = Instantiate (coinPrefab) as GameObject;
					coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, pos + offsetZ);

				} else if (7 <= item && item <= 9) {

					//車を生成
					GameObject car = Instantiate (carPrefab) as GameObject;
					car.transform.position = new Vector3 (posRange * j, car.transform.position.y, pos + offsetZ);
				}

			}

		}
	
	}
		
}