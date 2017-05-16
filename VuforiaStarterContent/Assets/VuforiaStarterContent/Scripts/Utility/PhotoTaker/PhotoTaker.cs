using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ADSUtility
{
    public class PhotoTaker : MonoBehaviour
    {
        private const string SCREENSHOT_PREFIX = "ADS"; //The prefix for all screenshots
        private const string APP_ALBUM_NAME = "ADSReality"; //The album title in the user's photo app
        private const string SCREENSHOT_TYPE = "png"; //File type for screenshots

        private const float SCREENSHOT_TIMEOUT = 1f; //How long before the temporary UI objects should re-enable in case of photo error
        private const float PREVIEW_FADE_TIME = 1f; //Time in seconds for how long it should take for the screenshot preview to show

        [SerializeField]
        private CanvasGroup m_PreviewObject; //The UI holder for the photo preview
        [SerializeField]
        private UnityEngine.UI.RawImage m_PreviewArea; //Where the image should go

        [SerializeField]
        private List<GameObject> m_TempDisableObjects = new List<GameObject>(); //We want to disable objects such as UI

        private Coroutine m_TimeoutCR; //Hold reference to co-routine


        [SerializeField]
        private NativePictureShare m_NativePictureShare;


        /// <summary>
        /// Register for callbacks
        /// </summary>
        private void OnEnable()
        {
            ScreenshotManager.OnScreenshotTaken += ScreenshotTaken;
            ScreenshotManager.OnScreenshotSaved += ScreenshotSaved;
        }

        /// <summary>
        /// De-register for callbakcs
        /// </summary>
        private void OnDisable()
        {
            ScreenshotManager.OnScreenshotTaken -= ScreenshotTaken;
            ScreenshotManager.OnScreenshotSaved -= ScreenshotSaved;
        }

        /// <summary>
        /// Method to call when button is pressed
        /// </summary>
        public void OnCameraButtonPress()
        {
            ProcessTempObjects(true); //Disable UI

            m_TimeoutCR = StartCoroutine(Timeout());

            ScreenshotManager.SaveScreenshot(SCREENSHOT_PREFIX, APP_ALBUM_NAME, SCREENSHOT_TYPE);
        }

        public void OnShareButtonPress()
        {
            if (m_NativePictureShare != null)
            {
                m_NativePictureShare.ShareScreenShot(ScreenshotManager.PathFromLastPicture);
                ClosePreview();
            }
        }


        /// <summary>
        /// Callback for when screenshot texture is available
        /// </summary>
        /// <param name="image">Screenshot texture</param>
        private void ScreenshotTaken(Texture2D image)
        {
            Debug.Log("Screenshot has been taken and is now saving...");

            m_PreviewArea.texture = image;
        }

        /// <summary>
        /// Callback for when the screenshot has been taken
        /// </summary>
        /// <param name="path">Where the screenshot was saved</param>
        private void ScreenshotSaved(string path)
        {
            if (m_TimeoutCR != null) //If the timeout is running, stop it
            {
                StopCoroutine(m_TimeoutCR);
            }

            m_TimeoutCR = null;

            ProcessTempObjects(false); //Re-enable the UI

            m_PreviewObject.gameObject.SetActive(true);
            StartCoroutine(SetShowPreview(true));

            Debug.Log("Screenshot finished saving to " + path);
        }

        public void ClosePreview()
        {
            Debug.Log("CLOSE PREVIEW");
            StartCoroutine(SetShowPreview(false));
        }

        private void ProcessTempObjects(bool beforePhoto)
        {
            for (int i = 0; i < m_TempDisableObjects.Count; i++)
            {
                m_TempDisableObjects[i].SetActive(!beforePhoto);
            }
        }

        private IEnumerator Timeout()
        {
            yield return new WaitForSeconds(SCREENSHOT_TIMEOUT);

            ProcessTempObjects(false);

            m_TimeoutCR = null;
        }

        private IEnumerator SetShowPreview(bool show)
        {
            if (!show && !m_PreviewArea.gameObject.activeInHierarchy)
            {
                yield break;
            }

            float lerp = 0;

            while (lerp < 1)
            {
                lerp += Time.deltaTime / PREVIEW_FADE_TIME;
                m_PreviewObject.alpha = Mathf.Lerp(show ? 0 : 1, show ? 1 : 0, lerp);

                yield return new WaitForEndOfFrame();
            }

            m_PreviewObject.gameObject.SetActive(show);
        }

    }
}
