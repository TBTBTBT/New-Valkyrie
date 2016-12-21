using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour {
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{ 
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
		Debug.Log("Error");
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			Statics.coin += 20;
			Statics.Save ();
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log ("The ad was skipped before reaching the end.");
			Statics.coin += 20;
			Statics.Save ();
			break;
		case ShowResult.Failed:
			//Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}
