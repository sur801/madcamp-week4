using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceHoop : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this hoop prefab on a plane at the touch location.")]
        GameObject m_DaoPrefab2;
        public GameObject placedPrefabDao2
        {
            get { return m_DaoPrefab2; }
            set { m_DaoPrefab2 = value; }
        }
        public GameObject spawnedDao2 { get; private set; }

        [SerializeField]
        [Tooltip("Instantiates this hoop prefab on a plane at the touch location.")]
        GameObject m_DaoPrefab;
        public GameObject placedPrefabDao
        {
            get { return m_DaoPrefab; }
            set { m_DaoPrefab = value; }
        }
        public GameObject spawnedDao { get; private set; }

        [SerializeField]
        [Tooltip("Instantiates this hoop prefab on a plane at the touch location.")]
        GameObject m_BazziPrefab;
        public GameObject placedPrefabBazzi
        {
            get { return m_BazziPrefab; }
            set { m_BazziPrefab = value; }
        }
        public GameObject spawnedBazzi { get; private set; }

        [SerializeField]
        [Tooltip("Instantiates this hoop prefab on a plane at the touch location.")]
        GameObject m_BazziPrefab2;
        public GameObject placedPrefabBazzi2
        {
            get { return m_BazziPrefab2; }
            set { m_BazziPrefab2 = value; }
        }
        public GameObject spawnedBazzi2 { get; private set; }

        [SerializeField]
        [Tooltip("Instantiates this ball prefab in front of the AR Camera.")]
        GameObject m_BallPrefab;

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedBall
        {
            get { return m_BallPrefab; }
            set { m_BallPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedBall { get; private set; }

        /// <summary>
        /// Invoked whenever an object is placed in on a plane.
        /// </summary>
        public static event Action onPlacedObject;

        private bool isPlaced = false;

        ARRaycastManager m_RaycastManager;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        void Update()
        {
            if (isPlaced) return;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hitPose = s_Hits[0].pose;

                        spawnedDao = Instantiate(m_DaoPrefab, hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
                        spawnedDao.transform.parent = transform.parent;
                        
                        spawnedDao2 = Instantiate(m_DaoPrefab2, hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
                        spawnedDao2.transform.parent = transform.parent;
                        spawnedDao2.transform.Translate(0, 0, -0.8f);

                        spawnedBazzi = Instantiate(m_BazziPrefab, hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
                        spawnedBazzi.transform.parent = transform.parent;
                        spawnedBazzi.transform.Translate(-0.9f, 0, 0);

                        spawnedBazzi2 = Instantiate(m_BazziPrefab2, hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
                        spawnedBazzi2.transform.parent = transform.parent;
                        spawnedBazzi2.transform.Translate(-0.7f, 0, -0.7f);

                        isPlaced = true;

                        spawnedBall = Instantiate(m_BallPrefab);
                        spawnedBall.transform.parent = m_RaycastManager.transform.Find("AR Camera").gameObject.transform;
                        if (onPlacedObject != null)
                        {
                            onPlacedObject();
                        }
                    }
                }
            }
        }


    }
}