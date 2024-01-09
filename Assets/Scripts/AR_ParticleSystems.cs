using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_ParticleSystems : MonoBehaviour
{
	public GameObject Particles1;
	public GameObject Particles2;
	public GameObject Particles3;
	public GameObject Particles4;
	public GameObject Particles5;
	public GameObject Particles6;
	public GameObject Particles7;
	public GameObject Particles8;
	public GameObject Particles9;
	public GameObject Particles10;
	public GameObject Hearts_021;
	public GameObject Hearts_025;
	public GameObject Hearts_026;
	public GameObject Hearts_028;
	public GameObject Hearts_030;
	public GameObject Hearts_032;
	public GameObject Hearts_035;
	public GameObject Hearts_039;
	public GameObject Hearts_076;
	public GameObject Hearts_089;

	public void CreateParticles1()
	{
		Particles1.SetActive(true);
		Invoke("stopParticles1", 5);
	}
	private void stopParticles1()
	{
		Particles1.SetActive(false);
	}

	public void CreateParticles2()
	{
		Particles2.SetActive(true);
		Invoke("stopParticles2", 5);
	}
	private void stopParticles2()
	{
		Particles2.SetActive(false);
	}

	public void CreateParticles3()
	{
		Particles3.SetActive(true);
		Invoke("stopParticles3", 5);
	}
	private void stopParticles3()
	{
		Particles3.SetActive(false);
	}

	public void CreateParticles4()
	{
		Particles4.SetActive(true);
		Invoke("stopParticles4", 5);
	}
	private void stopParticles4()
	{
		Particles4.SetActive(false);
	}

	public void CreateParticles5()
	{
		Particles5.SetActive(true);
		Invoke("stopParticles5", 5);
	}
	private void stopParticles5()
	{
		Particles5.SetActive(false);
	}

	public void CreateParticles6()
	{
		Particles6.SetActive(true);
		Invoke("stopParticles6", 5);
	}
	private void stopParticles6()
	{
		Particles6.SetActive(false);
	}

	public void CreateParticles7()
	{
		Particles7.SetActive(true);
		Invoke("stopParticles7", 5);
	}
	private void stopParticles7()
	{
		Particles7.SetActive(false);
	}

	public void CreateParticles8()
	{
		Particles8.SetActive(true);
		Invoke("stopParticles8", 5);
	}
	private void stopParticles8()
	{
		Particles8.SetActive(false);
	}

	public void CreateParticles9()
	{
		Particles9.SetActive(true);
		Invoke("stopParticles9", 5);
	}
	private void stopParticles9()
	{
		Particles9.SetActive(false);
	}

	public void CreateParticles10()
	{
		Particles10.SetActive(true);
		Invoke("stopParticles10", 5);
	}
	private void stopParticles10()
	{
		Particles10.SetActive(false);
	}

	public void PlayHearts021()
	{
		Hearts_021.GetComponent<Animator>().Play("Hearts_021");
	}
	public void PlayHearts025()
	{
		Hearts_025.GetComponent<Animator>().Play("Hearts_025");
	}
	public void PlayHearts026()
	{
		Hearts_026.GetComponent<Animator>().Play("Hearts_026");
	}
	public void PlayHearts028()
	{
		Hearts_028.GetComponent<Animator>().Play("Hearts_028");
	}
	public void PlayHearts030()
	{
		Hearts_030.GetComponent<Animator>().Play("Hearts_030");
	}
	public void PlayHearts032()
	{
		Hearts_032.GetComponent<Animator>().Play("Hearts_032");
	}
	public void PlayHearts035()
	{
		Hearts_035.GetComponent<Animator>().Play("Hearts_035");
	}
	public void PlayHearts039()
	{
		Hearts_039.GetComponent<Animator>().Play("Hearts_039");
	}
	public void PlayHearts076()
	{
		Hearts_076.GetComponent<Animator>().Play("Hearts_076");
	}
	public void PlayHearts089()
	{
		Hearts_089.GetComponent<Animator>().Play("Hearts_089");
	}
}
