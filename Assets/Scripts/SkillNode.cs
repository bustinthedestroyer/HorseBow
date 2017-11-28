using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillNode : MonoBehaviour {

	public Text textNode;
	public Text textNodeLevel;

	public Button button;
	public int SkillMax = 5;

	public bool SkillMaxed;
	private int skillLevel;

	public Skill skill;

	public ArmouryController armouryController;

	public SkillNode[] RequiredSkills;

	void Start () {
		LoadSkill();
	}

	public void LoadSkill()
	{
		skillLevel = PlayerModel.TalentPower;

		//button.interactable = false;
		textNodeLevel.text = skillLevel.ToString();
		if(skillLevel >= SkillMax){
			button.interactable = false;
		}else{
			button.interactable = true;
		}

		if(!RequiredSkillMeet())
		{
			button.interactable = false;
		}

	}

	public void GainSkill(){
		armouryController.SpendTalentPoint(0);
		LoadSkill();
	}

	public bool RequiredSkillMeet(){

		bool unlocked = true;

		foreach (SkillNode node in RequiredSkills)
		{
			if(!node.SkillMaxed){
				unlocked = false;
			}
		}

		return unlocked;
	}


}

[Serializable]
public class Skill{
	public string SkillName;
	public TalentKey SkillKey;
}

public enum TalentKey{
	Power,
	Speed,
}