using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ADSUtility
{
    public class TransformUtilityUI : MonoBehaviour
    {
        [SerializeField] private bool           m_EnableUtility;
        public bool EnableUtility
        {
            get { return m_EnableUtility; }
            set
            {
                m_EnableUtility = value;
                m_PanelButtons.SetActive(m_EnableUtility);
                m_PanelInfo.SetActive(m_EnableUtility);
            }
        }
        [SerializeField] private GameObject     m_PanelButtons;
        [SerializeField] private GameObject     m_PanelInfo;

        [Header("Info")]
        [SerializeField] private Text           m_PositionText;
        [SerializeField] private Text           m_ScaleText;
        [SerializeField] private Text           m_RotationText;

        [Header("Sound")]
        [SerializeField] private AudioSource    m_TapAudio;

        private TransformUtility                m_TransformUtilityObject;

        void Start()
        {
            m_PanelButtons.SetActive(m_EnableUtility);
            m_PanelInfo.SetActive(m_EnableUtility);
            m_PositionText.text = "";
            m_RotationText.text = "";
            m_ScaleText.text = "";
        }

        public void FeedTransformUtil(TransformUtility tUitlity)
        {
            m_TransformUtilityObject = tUitlity;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (m_TransformUtilityObject != null)
            {
                m_PositionText.text = "Position: (" + m_TransformUtilityObject.transform.position.x.ToString() + "," + m_TransformUtilityObject.transform.position.y.ToString() + "," + m_TransformUtilityObject.transform.position.z.ToString() + ")";
                m_RotationText.text = "Rotation: (" + m_TransformUtilityObject.transform.rotation.eulerAngles.x.ToString() + "," + m_TransformUtilityObject.transform.rotation.eulerAngles.y.ToString() + "," + m_TransformUtilityObject.transform.rotation.eulerAngles.z.ToString() + ")";
                m_ScaleText.text = "Scale: " + m_TransformUtilityObject.transform.localScale.x.ToString();
            }           
        }        

        #region TransformMethods

        public void MoveUp()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.MoveUp();
                UpdateInfo();
            }
        }

        public void MoveDown()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.MoveDown();
                UpdateInfo();
            }
        }

        public void MoveLeft()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.MoveLeft();
                UpdateInfo();
            }
        }

        public void MoveRight()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.MoveRight();
                UpdateInfo();
            }
        }

        public void MoveFar()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.MoveFar();
                UpdateInfo();
            }
        }

        public void MoveClose()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.MoveClose();
                UpdateInfo();
            }
        }

        public void ScaleUp()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.ScaleUp();
                UpdateInfo();
            }
        }

        public void ScaleDown()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.ScaleDown();
                UpdateInfo();
            }
        }

        public void RotateLeft()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                m_TransformUtilityObject.RotateLeft();
                UpdateInfo();
            }
        }
        public void RotateRigth()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {
                
                m_TransformUtilityObject.RotateRight();
                UpdateInfo();
            }
        }
        public void RotateUp()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {                
                m_TransformUtilityObject.RotateUp();
                UpdateInfo();
            }
        }
        public void RotateDown()
        {
            m_TapAudio.Play();
            if (m_TransformUtilityObject != null)
            {               
                m_TransformUtilityObject.RotateDown();
                UpdateInfo();
            }
        }

        #endregion TransformMethos

    }
}
