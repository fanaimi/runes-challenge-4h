using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Challenge7
{
    /// <summary>
    /// @gObj   DragController
    /// @desc   this will spawn and shoot cubes with speed proportional to drag event
    /// @tut    https://www.youtube.com/watch?v=BGr-7GZJNXg&ab_channel=CodeMonkey
    /// </summary>
    public class DragController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector3 m_startPos;
        private Vector3 m_endPos;
        private Vector3 m_direction;
        private float m_startTime;
        private float m_endTime;
        private float m_duration;
        private float m_speed;
        [SerializeField] private Rigidbody CubePrefab;
        [SerializeField] private Transform m_world;





        public void OnPointerDown(PointerEventData downEventData)
        {
            Debug.Log(downEventData);
            m_startPos = downEventData.position;
        }


        public void OnBeginDrag(PointerEventData beginDragEventData)
        {
            // Debug.Log("OnBeginDrag");
            m_startTime = Time.time;
        }


        public void OnDrag(PointerEventData dragEventData)
        {
            // Debug.Log("OnDrag");
        }

        void IEndDragHandler.OnEndDrag(PointerEventData endDragEventData)
        {
            m_endPos = endDragEventData.position;
            m_direction = m_endPos - m_startPos;
            m_endTime = Time.time;
            m_duration = m_endTime - m_startTime;
            m_speed = m_direction.magnitude / m_duration;

            Rigidbody newCube = Instantiate(CubePrefab, m_endPos, Quaternion.identity, m_world);
            newCube.AddForce(m_direction * (m_speed * .3f));
        }
    }

} // namespace