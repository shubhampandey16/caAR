using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Vuforia;

public class CardActivate : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	private bool mShowGUI = false;
	private bool mSubmitClicked = false;
	private bool currentOffersClicked = false;
	private bool mGetStartedClicked = false;
	private bool tick1Show = false;
	private bool tick2Show = false;
	private bool tick3Show = false;
	private bool tick4Show = false;
	private bool tick5Show = false;
	private bool tick6Show = false;
	private GameObject welcomeMessage;
	private GameObject logo;
	private GameObject offer1;
	private GameObject offer2;
	private GameObject offer3;
	private GameObject offer4;
	private GameObject offer5;
	private GameObject offer6;
	private GameObject tick1;
	private GameObject tick2;
	private GameObject tick3;
	private GameObject tick4;
	private GameObject tick5;
	private GameObject tick6;
	private GameObject ssn;
	private GameObject submitButton;
	private GameObject congratulations;
	private GameObject whiteBack;
	private GameObject currentOfferBtn;
	private GameObject offersBlab;
	private GameObject centurion;
	private GameObject getStarted;
	private GameObject prev;
	private GameObject next;
	private GameObject popUpConf;
	private GameObject amexLogo;

	public static int width = Screen.width;
	public static int height = Screen.height;

	private float FadeRate = 0.4f;
	private float targetAlpha;

	public void resetGUI() {
		welcomeMessage.SetActive (false);
		logo.SetActive (false);
		offer1.SetActive (false);
		offer2.SetActive (false);
		offer3.SetActive (false);
		offer4.SetActive (false);
		offer5.SetActive (false);
		offer6.SetActive (false);
		ssn.SetActive (false);
		whiteBack.SetActive (false);
		submitButton.SetActive (false);
		congratulations.SetActive (false);
		currentOfferBtn.SetActive (false);
		offersBlab.SetActive (false);
		getStarted.SetActive (false);
		prev.SetActive (false);
		next.SetActive (false);
		tick1.SetActive (false);
		tick2.SetActive (false);
		tick3.SetActive (false);
		tick4.SetActive (false);
		tick5.SetActive (false);
		tick6.SetActive (false);
		amexLogo.SetActive (true);
		centurion.SetActive (false);

		mShowGUI = false;

	}

	IEnumerator _wait(float time){
		yield return new WaitForSeconds(time);
	}

	// Use this for initialization
	void Start () {
		welcomeMessage = GameObject.FindGameObjectWithTag("welcomeMessage");
		logo = GameObject.FindGameObjectWithTag("logo");
		offer1 = GameObject.FindGameObjectWithTag("offer1");
		offer2 = GameObject.FindGameObjectWithTag("offer2");
		offer3 = GameObject.FindGameObjectWithTag("offer3");
		offer4 = GameObject.FindGameObjectWithTag("offer4");
		offer5 = GameObject.FindGameObjectWithTag("offer5");
		offer6 = GameObject.FindGameObjectWithTag("offer6");
		prev = GameObject.FindGameObjectWithTag ("prev");
		next = GameObject.FindGameObjectWithTag ("next");
		getStarted = GameObject.FindGameObjectWithTag ("getStarted");
		ssn = GameObject.FindGameObjectWithTag("SSN");
		submitButton = GameObject.FindGameObjectWithTag("submitButton");
		congratulations = GameObject.FindGameObjectWithTag("congrats");
//		rewardText = congratulations.GetComponent<UnityEngine.UI.Text> ();
		whiteBack = GameObject.FindGameObjectWithTag("robo");
//		backgrndImage = whiteBack.GetComponent<UnityEngine.UI.Image> ();
		currentOfferBtn = GameObject.FindGameObjectWithTag("currentOfferBtn");
		offersBlab = GameObject.FindGameObjectWithTag("offerblab");
		centurion = GameObject.FindGameObjectWithTag ("centurion");
//		scannedCard = centurion.GetComponent<UnityEngine.UI.Image> ();
		tick1 = GameObject.FindGameObjectWithTag ("nike");
		tick2 = GameObject.FindGameObjectWithTag ("apple");
		tick3 = GameObject.FindGameObjectWithTag ("target");
		tick4 = GameObject.FindGameObjectWithTag ("patagonia");
		tick5 = GameObject.FindGameObjectWithTag ("netflix");
		tick6 = GameObject.FindGameObjectWithTag ("parker");
		amexLogo = GameObject.FindGameObjectWithTag ("logoAmex");
		RectTransform whiteBackRect = whiteBack.GetComponent<RectTransform> ();
		whiteBackRect.sizeDelta = new Vector2 (height, width);
		resetGUI ();
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			mShowGUI = true;
			amexLogo.SetActive (false);
		}
//		else
//		{
//			mShowGUI = false;
//		}
	}

	void OnGUI() {
		if (!mShowGUI) {
			resetGUI ();
		}
		else if (!(mSubmitClicked || currentOffersClicked || mGetStartedClicked)) {
//			FadeIn (backgrndImage);
			whiteBack.SetActive(mShowGUI);
			welcomeMessage.SetActive (mShowGUI);
			logo.SetActive (mShowGUI);
			centurion.SetActive(true);
			ssn.SetActive (mShowGUI);
			submitButton.SetActive (mShowGUI);

		}
	}

	public void submitClicked() {
		mSubmitClicked = true;
		welcomeMessage.SetActive (false);
		ssn.SetActive (false);
		centurion.SetActive (false);
		submitButton.SetActive (false);
		congratulations.SetActive (true);
		whiteBack.SetActive (true);
		getStarted.SetActive (true);
		amexLogo.SetActive (false);
	}

	public void getStartedClicked() {
		amexLogo.SetActive (false);
		offersBlab.SetActive (true);
		currentOfferBtn.SetActive (true);
		congratulations.SetActive (false);
		getStarted.SetActive (false);
		next.SetActive (true);
		prev.SetActive (false);
		offer1.SetActive (false);
		offer2.SetActive (false);
		offer3.SetActive (false);
		offer4.SetActive (false);
		offer5.SetActive (false);
		offer6.SetActive (false);
		tick1.SetActive (false);
		tick2.SetActive (false);
		tick3.SetActive (false);
		tick4.SetActive (false);
		tick5.SetActive (false);
		tick6.SetActive (false);
	}

	public void currentOfferBtnClicked() {
		amexLogo.SetActive (false);
		currentOffersClicked = true;
		mSubmitClicked = false;
		offersBlab.SetActive (false);
		currentOfferBtn.SetActive (false);
		offer1.SetActive (true);
		offer2.SetActive (true);
		offer3.SetActive (true);
		offer4.SetActive (true);
		offer5.SetActive (true);
		offer6.SetActive (true);
		tick1.SetActive (tick1Show);
		tick2.SetActive (tick2Show);
		tick3.SetActive (tick3Show);
		tick4.SetActive (tick4Show);
		tick5.SetActive (tick5Show);
		tick6.SetActive (tick6Show);
		prev.SetActive (true);
		next.SetActive (false);
	}

	public void offerClicked(string text) {
		if (text.Contains ("nike")) {
			tick1Show = true;
			tick1.SetActive (true);
		}
		else if (text.Contains ("apple")) {
			tick2Show = true;
			tick2.SetActive (true);
		}
		else if (text.Contains ("target")) {
			tick3Show = true;
			tick3.SetActive (true);
		}
		else if (text.Contains ("patagonia")) {
			tick4Show = true;
			tick4.SetActive (true);
		}
		else if (text.Contains ("netflix")) {
			tick5Show = true;
			tick5.SetActive (true);
		}
		else if (text.Contains ("parker")) {
			tick6Show = true;
			tick6.SetActive (true);
		}
	}


	public void mycaAccountClicked() {
		Application.OpenURL ("https://online.americanexpress.com/myca/oce/us/action/register?request_type=un_Register&Face=en_US&regSrc=logon&linknav=us-homepage-createnewaccount");
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public void FadeIn(UnityEngine.UI.Image img) {
		targetAlpha = 1.0f;
		FadeRate = 0.5f;
		Color curColor = img.color;
		float alphaDiff = Mathf.Abs (curColor.a - targetAlpha);
		if (alphaDiff > 0.0001f) {
			curColor.a = Mathf.Lerp (curColor.a, targetAlpha, FadeRate * Time.deltaTime);
			img.color = curColor;
//			scannedCard.color = curColor;
		}
	}

	public void FadeInText(UnityEngine.UI.Text txt) {
		targetAlpha = 1.0f;
		FadeRate = 0.9f;
		Color curColor = txt.color;
		float alphaDiff = Mathf.Abs (curColor.a - targetAlpha);
		if (alphaDiff > 0.0001f) {
			Time.fixedDeltaTime += 0.8f;
			curColor.a = Mathf.Lerp (curColor.a, targetAlpha, FadeRate * Time.fixedDeltaTime);
			txt.color = curColor;
		}
	}
		

	private void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}

		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
	}


	private void OnTrackingLost()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}

		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}

		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
	}
}
