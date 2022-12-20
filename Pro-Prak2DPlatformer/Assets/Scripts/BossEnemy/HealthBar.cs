using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
	public Slider slider;
	public TMP_Text text;

	void Start()
	{

	}

	// Update is called once per frame

	private void Update()
	{
		slider.value = BossHealth.Instance.health;
		text.text = "Health: " + BossHealth.Instance.health;
	}

}