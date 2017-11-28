using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour {

	public float backGroundSize;
	private Transform[] layers;
	private int layerIndex;
	public float ScrollSpeed; 

	private void Start(){
		layers = new Transform[transform.childCount];
		layerIndex = 0;
		for(int i = 0; i<transform.childCount;i++)
		{
			layers[i] = transform.GetChild(i);
		}
	}

	private void Update()
	{
		ScrollRight();
	}

	private void ScrollRight()
	{
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * ScrollSpeed);
		if(layers[layerIndex].position.x < -backGroundSize)
		{
			layers[layerIndex].position = new Vector3(layers[layerIndex].position.x + backGroundSize * transform.childCount, layers[layerIndex].position.y, 10);
		}

		layerIndex++;
		if(layerIndex == layers.Length)
		{
			layerIndex = 0;
		}
	}
}