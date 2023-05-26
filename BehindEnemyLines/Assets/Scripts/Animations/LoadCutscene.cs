using UnityEngine;
using UnityEngine.Video;

public class LoadCutscene : MonoBehaviour
{
    
   public VideoPlayer myVideoPlayer;
   void Start()
   {
        myVideoPlayer = GetComponent<VideoPlayer>();
       string videoUrl= Application.dataPath + "/StreamingAssets/cutscene.mp4";
       myVideoPlayer.url = videoUrl;
   }
}
