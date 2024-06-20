using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VideoHandler : MonoBehaviour
{
    private ObserverBehaviour mTrackableBehaviour;
    public VideoPlayer videoPlayer;

    void Start()
{
    videoPlayer.prepareCompleted += PreparedToPlay;
    videoPlayer.Prepare();
}

void PreparedToPlay(VideoPlayer source)
{
    source.Play();
}
/*
    void Start()
    {
        mTrackableBehaviour = GetComponent<ObserverBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterObserver(this);
        }
    }

    public void OnObserverStateChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus == TargetStatus.DETECTED || 
            targetStatus == TargetStatus.TRACKED || 
            targetStatus == TargetStatus.EXTENDED_TRACKED)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }
    }
*/
}
