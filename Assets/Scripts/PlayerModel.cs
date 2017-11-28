using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerModel {
	private static int _highScore;
	public static int HighScore
	{
		get{
			return _highScore;
		}
		set{
			_highScore = value;
		}
	}

	private static int _experiencePoints;
	public static int ExperiencePoints
	{
		get{
			return _experiencePoints;
		}
		set{
			_experiencePoints = value;
		}
	}

	private static int _nextLevel;
	public static int NextLevel
	{
		get{
			return _nextLevel;
		}
		set{
			_nextLevel = value;
		}
	}

	private static int _level;
	public static int Level
	{
		get{
			return _level;
		}
		set{
			_level = value;
		}
	}

	private static int _talentPoints;
	public static int TalentPoints
	{
		get{
			return _talentPoints;
		}
		set{
			_talentPoints = value;
		}
	}

	public static void Save()
	{
		PlayerPrefs.SetInt("_highScore", _highScore);
		PlayerPrefs.SetInt("_experiencePoints", _experiencePoints);
		PlayerPrefs.SetInt("_level", _level);
		PlayerPrefs.SetInt("_nextLevel", _nextLevel);
		PlayerPrefs.SetInt("_talentPoints", _talentPoints);

		PlayerPrefs.SetInt("_talentPower", _talentPower);
		PlayerPrefs.SetInt("_talentSpeed", _talentSpeed);
		PlayerPrefs.SetInt("_talentHealth", _talentHealth);
		PlayerPrefs.SetInt("_talentArrows", _talentArrows);
		
		CalculaterValues();
		Debug.Log("Player model saved.");
		
	}

	public static void Load()
	{
		_highScore = PlayerPrefs.GetInt("_highScore", 0);
		_experiencePoints = PlayerPrefs.GetInt("_experiencePoints", 0);
		_level = PlayerPrefs.GetInt("_level", 1);
		_nextLevel = PlayerPrefs.GetInt("_nextLevel", levelFactor);

		_talentPoints = PlayerPrefs.GetInt("_talentPoints", 1);

		_talentPower = PlayerPrefs.GetInt("_talentPower", 0);
		_talentSpeed = PlayerPrefs.GetInt("_talentSpeed", 0);
		_talentHealth = PlayerPrefs.GetInt("_talentHealth", 0);
		_talentArrows = PlayerPrefs.GetInt("_talentArrows", 0);

		CalculaterValues();
		Debug.Log("Player model loaded.");
	}

	public static void Reset()
	{
		PlayerPrefs.DeleteAll();
		PlayerModel.Load();
		PlayerModel.Save();
	}
	public static void ResetTalents()
	{
		TalentPoints = TalentPoints + TalentPower + TalentSpeed + TalentHealth + TalentArrows;
		TalentPower = 0;
		TalentSpeed = 0;
		TalentHealth = 0;
		TalentArrows = 0;

		Save();
		CalculaterValues();
	}


	////Debug testing
	public static int levelFactor = 10;

	////Talents
	private static int _talentPower;
	public static int TalentPower
	{
		get{
			return _talentPower;
		}
		set{
			_talentPower = value;
		}
	}

	private static int _talentSpeed;
	public static int TalentSpeed
	{
		get{
			return _talentSpeed;
		}
		set{
			_talentSpeed = value;
		}
	}

	private static int _talentHealth;
	public static int TalentHealth
	{
		get{
			return _talentHealth;
		}
		set{
			_talentHealth = value;
		}
	}

	private static int _talentArrows;
	public static int TalentArrows
	{
		get{
			return _talentArrows;
		}
		set{
			_talentArrows = value;
		}
	}


	////Calculater Fields

	public static float AttackSpeed;
	public static int Power;
	public static int Health;
	public static int Arrows;

	public static void CalculaterValues(){
		AttackSpeed = .5f - (PlayerModel.TalentSpeed * .025f);
		Power = 500 + (PlayerModel.TalentPower * 50);
		Health = 6 + PlayerModel.TalentHealth * 2;
		Arrows = (int)Mathf.Ceil(PlayerModel.TalentArrows * 0.5f) + 1;
	}



	////Weapons refacotr
	public static float ScatterShotSpread = 10f;
	public static float ScatterShotForceSpread = 100;
	public static int ScatterShotCount = 3;
	
	public static float SpreadShotSpread = .5f;
	public static int SpreadShotCount = 3;
	
	public static float MultiShotSpread = 5f;
	public static float MuliShotCount = 3;
}