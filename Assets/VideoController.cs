using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    RaycastHit hit;

    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if(Physics.Raycast(ray, out hit))
                {
                    VideoPlayer videoPlayer = hit
                                                .transform
                                                .gameObject
                                                .GetComponent<VideoPlayer>();
                    if (!videoPlayer) {
                        return;
                    }

                    if (videoPlayer.isPlaying)
                    {
                        videoPlayer.Pause();
                    }
                    else
                    {
                        videoPlayer.Play();
                    }



                }
            }
        }
    }
}
