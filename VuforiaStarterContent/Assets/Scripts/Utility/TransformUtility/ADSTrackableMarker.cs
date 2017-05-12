using UnityEngine;
using System.Collections;
using Vuforia;

namespace ADSUtility
{
    public class ADSTrackableMarker : MonoBehaviour, ITrackableEventHandler
    {
        [Header("Vuforia Settings")]
        [SerializeField] private bool               m_FeedFromVuforia;
        [SerializeField] private GameObject         m_TrackObjectPrefab;
        [SerializeField] private TransformUtilityUI m_TransformUtilityUI;


        private TrackableBehaviour                  m_TrackableBehaviour;
        private GameObject                          m_TrackObject;

        void Start()
        {
            if (m_FeedFromVuforia)
            {
                m_TrackableBehaviour = GetComponent<TrackableBehaviour>();
                if (m_TrackableBehaviour)
                {
                    m_TrackableBehaviour.RegisterTrackableEventHandler(this);
                }
            }
            else
            {
                InstanceTrackObject();
            }
        }

        #region Vuforia
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (m_FeedFromVuforia)
            {
                if (newStatus == TrackableBehaviour.Status.DETECTED ||
                   newStatus == TrackableBehaviour.Status.TRACKED ||
                   newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
                {
                    OnTrackingFound();
                }
                else
                {
                    OnTrackingLost();
                }
            }
        }

        private void OnTrackingFound()
        {
            InstanceTrackObject();
        }

        private void OnTrackingLost()
        {
            DestroyTrackObject();
        }

        #endregion Vuforia

        private void DestroyTrackObject()
        {
            if (m_TrackObject != null)
            {
                Destroy(m_TrackObject);
                m_TrackObject = null;
            }
        }

        private void InstanceTrackObject()
        {
            DestroyTrackObject();
            m_TrackObject = Instantiate(m_TrackObjectPrefab) as GameObject;
            if (m_TrackObject != null)
            {
                m_TransformUtilityUI.FeedTransformUtil(m_TrackObject.GetComponent<TransformUtility>());
            }
        }
    }
}
