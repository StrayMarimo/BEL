using UnityEngine;
using UnityEngine.Video;

public class LoadStartvideo : MonoBehaviour
{
   public bool isVideoPlaying;
   [HideInInspector]
   public VideoPlayer myVideoPlayer;
   public GameObject startBtn;
   private float delayTime = 2f;
   void Start()
   {
       startBtn.SetActive(false);
        myVideoPlayer = GetComponent<VideoPlayer>();
       string videoUrl= Application.dataPath + "/StreamingAssets/start_bg.mp4";
       myVideoPlayer.url = videoUrl;
   }

   void Update() {
      if (myVideoPlayer.isPlaying)
      {
          delayTime -= Time.deltaTime;
            if (delayTime < 0)
            {
                startBtn.SetActive(true);
            }
      }
   }
}