using UnityEngine;
using System.Collections;

namespace ADSUtility
{
    public class TransformUtility : MonoBehaviour
    {
        [SerializeField]  private float m_Units = 0.5f;

        #region SetupTransform

        public void MoveUp()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + m_Units, transform.localPosition.z);
        }

        public void MoveDown()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - m_Units, transform.localPosition.z);
        }

        public void MoveLeft()
        {
            transform.localPosition = new Vector3(transform.localPosition.x - m_Units, transform.localPosition.y, transform.localPosition.z);
        }

        public void MoveRight()
        {
            transform.localPosition = new Vector3(transform.localPosition.x + m_Units, transform.localPosition.y, transform.localPosition.z);
        }

        public void MoveFar()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + m_Units);
        }

        public void MoveClose()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - m_Units);
        }

        public void ScaleUp()
        {
            transform.localScale = new Vector3(transform.localScale.x + m_Units, transform.localScale.y + m_Units, transform.localScale.z + m_Units);
        }

        public void ScaleDown()
        {
            transform.localScale = new Vector3(transform.localScale.x - m_Units, transform.localScale.y - m_Units, transform.localScale.z - m_Units);
        }

        public void RotateLeft()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x , transform.rotation.eulerAngles.y + m_Units, transform.rotation.eulerAngles.z);
        }

        public void RotateRight()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x , transform.rotation.eulerAngles.y - m_Units, transform.rotation.eulerAngles.z);
        }

        public void RotateUp()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - m_Units, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        public void RotateDown()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + m_Units, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        #endregion SetupTransform
    }
}
