using UnityEngine;
using System.Collections;

namespace ADNEC
{
    public class PlayVideoHandle : MonoBehaviour
    {
        [SerializeField]  private string m_NameButtonPlayVideo = "PlayVideoButton";
        private bool m_EnablePlayVideo = true;

        [SerializeField]
        private VideoPlaybackBehaviour m_VideoHandle;
        


        public void EnablePlayVideoHandle()
        {
            m_EnablePlayVideo = true;
        }
        public void DisablePlayVideoHandle()
        {
            m_EnablePlayVideo = false;
        }

        

        public void PauseVideo()
        {
            if (m_VideoHandle != null)
            {
                if (m_VideoHandle.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    m_VideoHandle.VideoPlayer.Stop();
                }
            }
        }


        void Update()
        {
            if ((m_VideoHandle != null)  && (m_EnablePlayVideo))
            {
                if (Input.GetMouseButtonUp(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray,out hit))
                    {
                        if (hit.transform.tag == m_NameButtonPlayVideo)
                        {
                           
                            if (m_VideoHandle.CurrentState == VideoPlayerHelper.MediaState.PAUSED)
                            {
                                m_VideoHandle.VideoPlayer.Play(false, m_VideoHandle.VideoPlayer.GetCurrentPosition());
                            }

                            if ((m_VideoHandle.CurrentState == VideoPlayerHelper.MediaState.REACHED_END) ||
                                (m_VideoHandle.CurrentState == VideoPlayerHelper.MediaState.READY) ||
                                (m_VideoHandle.CurrentState == VideoPlayerHelper.MediaState.STOPPED)
                                )
                            {
                                m_VideoHandle.VideoPlayer.Play(false, 0);
                            }

                            if (m_VideoHandle.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                            {
                                m_VideoHandle.VideoPlayer.Pause();
                            }                           
                        }
                    }
                }
            }
        }
    }
}
