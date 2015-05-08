using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vuforia;
using System;
using UnityEngine.UI;

public class UserDefinedTargetEventHandler : MonoBehaviour, IUserDefinedTargetEventHandler

{
	public static GameObject goodButton;
	public static GameObject badButton;

	public ImageTargetBehaviour imageTargetTemplate;
	
	private UserDefinedTargetBuildingBehaviour mTargetBuildingBehaviour;
	private ObjectTracker mObjectTracker;
	private DataSet mBuiltDataSet;
	private ImageTargetBuilder.FrameQuality mFrameQuality = ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE;
	
	public void Init()
	{
		mTargetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();
		if (mTargetBuildingBehaviour)
		{
			mTargetBuildingBehaviour.RegisterEventHandler(this);
			mTargetBuildingBehaviour.StartScanning();
		}
	}
	
	public void OnInitialized ()
	{
		mObjectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
		if (mObjectTracker != null)
		{
			// create a new dataset
			mBuiltDataSet = mObjectTracker.CreateDataSet();
			mObjectTracker.ActivateDataSet(mBuiltDataSet);
		}
	}

	public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality)
	{
		if (badButton == null) {
			badButton = GameObject.Find("TargetQualityImageBad");
			goodButton = GameObject.Find("TargetQualityImageGood");
		}

		if (frameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE ||
		    frameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW) {
			badButton.SetActive(true);
			goodButton.SetActive(false);
		} else {
			badButton.SetActive(false);
			goodButton.SetActive(true);
		}
		Debug.Log("QUALITY" + frameQuality);
		mFrameQuality = frameQuality;
	}

	public void OnNewTrackableSource(TrackableSource trackableSource)
	{
		mObjectTracker.DeactivateDataSet(mBuiltDataSet);

		ImageTargetBehaviour imageTargetCopy = (ImageTargetBehaviour)Instantiate(imageTargetTemplate);
		String time = DateTime.Now.ToString("yyyyMMdd_hhmmssfff");
		imageTargetCopy.gameObject.name = "UserDefinedTarget-" + time;

		mBuiltDataSet.CreateTrackable(trackableSource, imageTargetCopy.gameObject);

		mObjectTracker.ActivateDataSet(mBuiltDataSet);

		mObjectTracker.Stop();
		mObjectTracker.ResetExtendedTracking();
		mObjectTracker.Start();		
	}

	public bool BuildNewTarget()
	{
		if(mFrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE || 
		   mFrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW) {
			Debug.Log("NOT GOOD TARGET");
			return false;
		}

		String time = DateTime.Now.ToString("yyyyMMdd_hhmmssfff");
		String targetName = string.Format("{0}-{1}", imageTargetTemplate.TrackableName, time);

		Debug.Log("GOOD TARGET");
		
		mTargetBuildingBehaviour.BuildNewTarget(targetName, imageTargetTemplate.GetSize().x);
		return true;
	}

}



