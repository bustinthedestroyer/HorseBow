using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

	public GameObject Arrow;
	public GameObject DarkArrow;
	public Transform ArrowPoint;
	
	public void Start()
	{
		PlayerModel.CalculaterValues();
	}

	public float FireArrow(float ArrowAngle)
	{
		MultiShot2(ArrowAngle);
		return Time.time + PlayerModel.AttackSpeed;
	}


	////LooseArrow
	public void LooseArrow(float ArrowAngle, bool pierces = false){
		LooseArrow(ArrowPoint.position, ArrowAngle, PlayerModel.Power, pierces);
	}
	public void LooseArrow(Vector3 ArrowPosition, float ArrowAngle, float Force, bool pierces = false){
		Quaternion ArrowRotation = Quaternion.Euler(new Vector3(0,0,ArrowAngle));
		GameObject CloneArrow = Instantiate(Arrow, ArrowPosition, ArrowRotation);
		Arrow arrow = CloneArrow.GetComponent<Arrow>();
		arrow.Piercing = pierces;
	}
	public void LooseDarkArrow(Vector3 ArrowPosition, float ArrowAngle, float Force, bool pierces = false){
		Quaternion ArrowRotation = Quaternion.Euler(new Vector3(0,0,ArrowAngle));
		GameObject CloneArrow = Instantiate(DarkArrow, ArrowPosition, ArrowRotation);
		Arrow arrow = CloneArrow.GetComponent<Arrow>();
		arrow.Piercing = pierces;
	}

	////Attacks
	public void SpecialAttack(int SpecialAttackNumber, float baseAngle){

		switch(SpecialAttackNumber){
			case 1:
				MultiShot(baseAngle);
				break;
			case 2:
				SpreadShot(baseAngle);
				break;
			case 3:
				ScatterShot(baseAngle);
				break;
			case 4:
				////Powershot
				PowerShot(baseAngle);
				break;
			case 5:
				//ScatterShot(baseAngle);
				break;
		}

	}
	
    public void MultiShot(float BaseAngle)
    {

		////Fixed cone
		//float seperation = (coneMax * 2) / (PlayerStats.MuliShotCount-1);
		//float baseRotation = BaseAngle - coneMax;
        float baseRotation = BaseAngle - ((PlayerModel.MuliShotCount -1) * PlayerModel.MultiShotSpread) * .5f;		
        for (int i = 0; i < PlayerModel.MuliShotCount; i++)
        {
			float ArrowAngle = baseRotation + i * PlayerModel.MultiShotSpread;
			//float ArrowAngle = baseRotation + i * seperation;
			LooseArrow(ArrowPoint.position, ArrowAngle, PlayerModel.Power);
        }
    }

    public void MultiShot2(float BaseAngle)
    {

		////Fixed cone
		//float seperation = (coneMax * 2) / (PlayerStats.MuliShotCount-1);
		//float baseRotation = BaseAngle - coneMax;
        float baseRotation = BaseAngle - ((PlayerModel.MuliShotCount -1) * PlayerModel.MultiShotSpread) * .5f;		
        for (int i = 0; i < PlayerModel.Arrows; i++)
        {
			float ArrowAngle = baseRotation + i * PlayerModel.MultiShotSpread;
			//float ArrowAngle = baseRotation + i * seperation;
			LooseArrow(ArrowPoint.position, ArrowAngle, PlayerModel.Power);
        }
    }

    public void SpreadShot(float BaseAngle)
    {
        Vector3 bottomPosition = new Vector3(ArrowPoint.position.x, ArrowPoint.position.y - PlayerModel.SpreadShotSpread * (PlayerModel.SpreadShotCount / 2), ArrowPoint.position.z);
        for (int i = 0; i < PlayerModel.SpreadShotCount; i++)
        {
            Vector3 ArrowPosition = new Vector3(bottomPosition.x, bottomPosition.y + i * PlayerModel.SpreadShotSpread, bottomPosition.z);
			LooseArrow(ArrowPosition, BaseAngle, PlayerModel.Power);
        }
    }

    public void ScatterShot(float BaseAngle)
    {
        for (int i = 0; i < PlayerModel.ScatterShotCount; i++)
        {
			float ArrowAngle = BaseAngle + Random.Range(-PlayerModel.ScatterShotSpread, PlayerModel.ScatterShotSpread);
			float ArrowPower = PlayerModel.Power + Random.Range(-PlayerModel.ScatterShotForceSpread, PlayerModel.ScatterShotForceSpread);
			LooseArrow(ArrowPoint.position, ArrowAngle, ArrowPower);
        }
    }

	public void PowerShot(float BaseAngle)
	{
			LooseArrow(ArrowPoint.position, BaseAngle, 1600, true);
	}
}