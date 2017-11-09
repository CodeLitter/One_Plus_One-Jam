using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName="Transitioner")]
public class Transitioner : ScriptableObject
{
	public void LoadScene (int scene_index)
	{
		SceneManager.LoadScene(scene_index);
	}

	public void Reload ()
	{
		Scene scene = SceneManager.GetActiveScene();
		LoadScene(scene.buildIndex);
	}

	public void LoadNext ()
	{
		Scene scene = SceneManager.GetActiveScene();
		LoadScene(Mathf.Clamp(scene.buildIndex + 1, 0, SceneManager.sceneCountInBuildSettings));
	}

	public void LoadPrev ()
	{
		Scene scene = SceneManager.GetActiveScene();
		LoadScene(Mathf.Clamp(scene.buildIndex - 1, 0, SceneManager.sceneCountInBuildSettings));
	}
}
