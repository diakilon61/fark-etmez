using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tekrar_oyna : MonoBehaviour
{
	
	public static bool oyun_devamedıyormu=false;
	public void Tekrar_oyna_butonkodu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		//oynanan sahneyi yükle
	}
	public void ana_menü_dön()
	{
		oyun_devamedıyormu = true;
		SceneManager.LoadScene("ana_menü");

	}
	public void bolumlerr()
	{
		SceneManager.LoadScene("levelkilit");
	}
	public void oyunu_kapat()
	{
		Application.Quit();
	}
}
