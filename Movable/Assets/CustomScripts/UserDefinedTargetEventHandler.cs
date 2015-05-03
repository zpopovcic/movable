using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vuforia;
using System;

public class UserDefinedTargetEventHandler : MonoBehaviour, IUserDefinedTargetEventHandler
{
	/// <summary>
	/// Can be set in the Unity inspector to reference a ImageTargetBehaviour that is instanciated for augmentations of new user defined targets.
	/// </summary>
	public ImageTargetBehaviour imageTargetTemplate;
	
	private UserDefinedTargetBuildingBehaviour mTargetBuildingBehaviour;
	private ObjectTracker mObjectTracker;
	// DataSet that newly defined targets are added to
	private DataSet mBuiltDataSet;
	// currently observed frame quality
	private ImageTargetBuilder.FrameQuality mFrameQuality = ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE;

	/// <summary>
	/// Registers this component as a handler for UserDefinedTargetBuildingBehaviour events
	/// </summary>
	public void Init()
	{
		mTargetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();
		if (mTargetBuildingBehaviour)
		{
			mTargetBuildingBehaviour.RegisterEventHandler(this);
			Debug.Log ("Registering to the events of IUserDefinedTargetEventHandler");
			mTargetBuildingBehaviour.StartScanning();
		}
	}

	/// <summary>
	/// Called when UserDefinedTargetBuildingBehaviour has been initialized successfully
	/// </summary>
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
	
	/// <summary>
	/// Updates the current frame quality
	/// </summary>
	public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality)
	{
		Debug.Log("QUALITY" + frameQuality);
		mFrameQuality = frameQuality;
	}
	
	/// <summary>
	/// Takes a new trackable source and adds it to the dataset
	/// This gets called automatically as soon as you 'BuildNewTarget with UserDefinedTargetBuildingBehaviour
	/// </summary>
	public void OnNewTrackableSource(TrackableSource trackableSource)
	{

		// deactivates the dataset first
		mObjectTracker.DeactivateDataSet(mBuiltDataSet);
		
		// get predefined trackable and instantiate it
		ImageTargetBehaviour imageTargetCopy = (ImageTargetBehaviour)Instantiate(imageTargetTemplate);
		String time = DateTime.Now.ToString("yyyyMMdd_hhmmssfff");
		imageTargetCopy.gameObject.name = "UserDefinedTarget-" + time;
		
		// add the duplicated trackable to the data set and activate it
		mBuiltDataSet.CreateTrackable(trackableSource, imageTargetCopy.gameObject);
		
		
		// activate the dataset again
		mObjectTracker.ActivateDataSet(mBuiltDataSet);

		mObjectTracker.Stop();
		mObjectTracker.ResetExtendedTracking();
		mObjectTracker.Start();

		TakeScreenshoot.i = 0;
		//Application.LoadLevel("CameraScene");
		
	}
	
	/// <summary>
	/// Instantiates a new user-defined target and is also responsible for dispatching callback to 
	/// IUserDefinedTargetEventHandler::OnNewTrackableSource
	/// </summary>
	public void BuildNewTarget()
	{
		if(mFrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE) {
			Debug.Log("NOT GOOD TARGET");
			return;
		}
		// create the name of the next target.
		// the TrackableName of the original, linked ImageTargetBehaviour is extended with a continuous number to ensure unique names
		String time = DateTime.Now.ToString("yyyyMMdd_hhmmssfff");
		String targetName = string.Format("{0}-{1}", imageTargetTemplate.TrackableName, time);
		
		// generate a new target name:
		Debug.Log("GOOD TARGET");
		
		mTargetBuildingBehaviour.BuildNewTarget(targetName, imageTargetTemplate.GetSize().x);
	}

}



