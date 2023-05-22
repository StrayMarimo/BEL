using UnityEngine;
using UnityEngine.Video;

public class LoadStartvideo : MonoBehaviour
{
   public VideoPlayer myVideoPlayer;
   void Start()
   {
        myVideoPlayer = GetComponent<VideoPlayer>();
       string videoUrl= Application.dataPath + "/StreamingAssets/start_bg.mp4";
       myVideoPlayer.url = videoUrl;
   }
}