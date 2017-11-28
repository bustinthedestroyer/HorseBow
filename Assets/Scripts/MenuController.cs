using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Entities;

public class MenuController : MonoBehaviour {

	public void StartGame(int LevelNumber){
		StartCoroutine(FadeToScene("HorseBow"));
	}

	public void QuitGame(){
		StartCoroutine(FadeToExit());
	}
	public void GoToMenu(){
		StartCoroutine(FadeToScene("Menu"));
		PlayerModel.Save();
	}
	public void GotToArmoury(){
		StartCoroutine(FadeToScene("Armoury"));
	}
	public void ResetStats(){
		PlayerModel.Reset();
	}
	
	public Image black;
	public Animator anim;
	IEnumerator FadeToScene(string SceneName)	
	{
		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>black.color.a==1);
		SceneManager.LoadScene(SceneName);
	}

	IEnumerator FadeToExit()
	{
		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>black.color.a==1);
		Debug.Log("Game has been exited.");
		Application.Quit();
	}
}