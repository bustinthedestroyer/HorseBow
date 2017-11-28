using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;
using UnityEngine.UI;

public class ArmouryController : MonoBehaviour {

	public ArrowController arrowController;

	public AudioSource ArrowSound;

	public Text CurrentWeaponText;
	public Text TextTalentPoints;

	public SkillNode SkillPower;
	public Text ButtonTextPower;
	public Text ButtonTextSpeed;
	public Text ButtonTextHealth;
	public Text ButtonTextArrows;

	public Button ButtonPower;
	public Button ButtonSpeed;
	public Button ButtonHealth;
	public Button ButtonArrows;

	void Start(){
	    PlayerModel.Load();
		DisplayTalentPoints();
	}



    private float arrowNext = 0;
    public AudioSource bowSound;

	void Update(){
		if (Time.time > arrowNext)
		{
			arrowNext = arrowController.FireArrow(30);
			bowSound.Play();			
		}
	}

	public void DisplayTalentPoints(){

		SkillPower.LoadSkill();

		ButtonTextPower.text = "Power:" + PlayerModel.TalentPower;
		ButtonTextSpeed.text = "Speed:" + PlayerModel.TalentSpeed;
		ButtonTextHealth.text = "Health:" + PlayerModel.TalentHealth;
		ButtonTextArrows.text = "Arrows:" + PlayerModel.TalentArrows;
		TextTalentPoints.text = "Talent points:" + PlayerModel.TalentPoints.ToString();

		if(PlayerModel.TalentPower == 10) ButtonPower.interactable = false;
		if(PlayerModel.TalentSpeed == 10) ButtonSpeed.interactable = false;
		if(PlayerModel.TalentHealth == 10) ButtonHealth.interactable = false;
		if(PlayerModel.TalentArrows == 10) ButtonArrows.interactable = false;

	}

	//public void SpendTalentPoint(string talent){
	public void SpendTalentPoint(int talentId){

		if(PlayerModel.TalentPoints > 0){		
			switch(talentId){
				case 0:
					PlayerModel.TalentPower++;

					break;
				case 1:
					PlayerModel.TalentSpeed++;
					break;
				case 2:
					PlayerModel.TalentHealth++;
					break;
				case 3:
					PlayerModel.TalentArrows++;
					break;
				
			}

			PlayerModel.TalentPoints--;

			PlayerModel.CalculaterValues();

			PlayerModel.Save();

			DisplayTalentPoints();
		}

	}

	public void ResetTalentPoints(){
		PlayerModel.ResetTalents();
		DisplayTalentPoints();
		ButtonPower.interactable = true;
		ButtonSpeed.interactable = true;
		ButtonHealth.interactable = true;
		ButtonArrows.interactable = true;
	}
}