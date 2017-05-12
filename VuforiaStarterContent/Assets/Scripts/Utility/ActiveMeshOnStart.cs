using UnityEngine;
using System.Collections;

namespace ADSUtility
{
    public class ActiveMeshOnStart : MonoBehaviour
    {
        [SerializeField]  private bool m_ActiveMeshOnStart = false;
        private Renderer m_Render;

        void Awake()
        {
            m_Render = GetComponent<Renderer>();
            if (m_Render != null)
            {
                m_Render.enabled = m_ActiveMeshOnStart;
            }
        }
    }
}
