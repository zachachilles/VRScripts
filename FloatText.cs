﻿using UnityEngine;
using System.Collections;

//this script is used to genreated the floating text that appears above the different brain regions when the laser is pointed at a region and the trigger pulled
namespace TMPro.Examples
{

    public class FloatText: MonoBehaviour
    {
        public Font TheFont;

        private GameObject m_floatingText;
        private TextMeshPro m_textMeshPro;
        private TextMesh m_textMesh;

        private Transform m_transform;
        private Transform m_floatingText_Transform;
        private Transform m_cameraTransform;

        Vector3 lastPOS = Vector3.zero;
        Quaternion lastRotation = Quaternion.identity;

        public int SpawnType;

        //private int m_frame = 0;

        void Awake() 
        {
            m_transform = transform;
            m_floatingText = new GameObject(this.name + " floating text");

            // Reference to Transform is lost when TMP component is added since it replaces it by a RectTransform.
            //m_floatingText_Transform = m_floatingText.transform;
            //m_floatingText_Transform.position = m_transform.position + new Vector3(0, 15f, 0);

            m_cameraTransform = Camera.main.transform;
        }

        public void floatStart(string name, Color32 col)   //change this to a different class that is called when the laser shines over it- make it take a string ie the object name as input
        {
            if (SpawnType == 0)
            {
                // TextMesh Pro Implementation
                if (m_floatingText.GetComponent<TextMeshPro>() == null)
                {
                    m_textMeshPro = m_floatingText.AddComponent<TextMeshPro>();
                }
                m_textMeshPro.rectTransform.sizeDelta = new Vector2(3, 3);

                m_floatingText_Transform = m_floatingText.transform;
                m_floatingText_Transform.position = m_transform.position + new Vector3(0, 5f, 0);   //can change this to display how far from spawing object name is displayed

                //m_textMeshPro.fontAsset = Resources.Load("Fonts & Materials/JOKERMAN SDF", typeof(TextMeshProFont)) as TextMeshProFont; // User should only provide a string to the resource.
                //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(Material)) as Material;

                m_textMeshPro.alignment = TextAlignmentOptions.Center;
                m_textMeshPro.color = col;
                m_textMeshPro.fontSize = 5;
                //m_textMeshPro.enableExtraPadding = true;
                //m_textMeshPro.enableShadows = false;
                //  m_textMeshPro.text = string.Empty;                                       CHANGED THIS BY COMMENTING OUT AND REPLACING WITH STRING
                m_textMeshPro.text = "Hello";

                StartCoroutine(DisplayTextMeshProFloatingText(name));   //feed string into this coroutine so name of object is displayed constantly while laser is shined on it
            }
            else if (SpawnType == 1)
            {
                //Debug.Log("Spawning TextMesh Objects.");

                m_floatingText_Transform = m_floatingText.transform;
                m_floatingText_Transform.position = m_transform.position + new Vector3(0, 15f, 0);

                m_textMesh = m_floatingText.AddComponent<TextMesh>();
                m_textMesh.font = Resources.Load("Fonts/ARIAL", typeof(Font)) as Font;
                m_textMesh.GetComponent<Renderer>().sharedMaterial = m_textMesh.font.material;
                m_textMesh.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                m_textMesh.anchor = TextAnchor.LowerCenter;
                m_textMesh.fontSize = 24;

                StartCoroutine(DisplayTextMeshFloatingText());
            }
            else if (SpawnType == 2)
            {

            }

        }


        //void Update()
        //{
        //    if (SpawnType == 0)
        //    {
        //        m_textMeshPro.SetText("{0}", m_frame);
        //    }
        //    else
        //    {
        //        m_textMesh.text = m_frame.ToString();
        //    }
        //    m_frame = (m_frame + 1) % 1000;

        //}


        public IEnumerator DisplayTextMeshProFloatingText(string name)
        {
            float CountDuration = 2.0f; // How long is the countdown alive.    
                                        //  float starting_Count = Random.Range(5f, 20f); // At what number is the counter starting at.
            float starting_Count = 3;
            float current_Count = starting_Count;

            Vector3 start_pos = m_floatingText_Transform.position;
            Color32 start_color = m_textMeshPro.color;
            float alpha = 255;
            //int int_counter = 0;


            float fadeDuration = 3 / starting_Count * CountDuration;
            while (current_Count > 0)
            {
                current_Count -= (Time.deltaTime / CountDuration) * starting_Count;

                if (current_Count <= 3)
                {
                    //Debug.Log("Fading Counter ... " + current_Count.ToString("f2"));
                    alpha = Mathf.Clamp(alpha - (Time.deltaTime / fadeDuration) * 255, 0, 255);
                }
                //int_counter = (int)current_Count;                 
                //  m_textMeshPro.SetText("{0}", (int)current_Count);
                m_textMeshPro.SetText(name);
                m_textMeshPro.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);

                // Move the floating text upward each update
                m_floatingText_Transform.position += new Vector3(0, starting_Count * Time.deltaTime *0.5f, 0);

                // Align floating text perpendicular to Camera.
                if (!lastPOS.Compare(m_cameraTransform.position, 1000) || !lastRotation.Compare(m_cameraTransform.rotation, 1000))
                {
                    lastPOS = m_cameraTransform.position;
                    lastRotation = m_cameraTransform.rotation;
                    m_floatingText_Transform.rotation = lastRotation;
                    Vector3 dir = m_transform.position - lastPOS;
              //      m_transform.forward = new Vector3(dir.x, 0, dir.z);
                }
                
                yield return new WaitForEndOfFrame();
            }

            //Debug.Log("Done Counting down.");

            yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));

            m_floatingText_Transform.position = start_pos;
            Destroy(m_floatingText);

         //   StartCoroutine(DisplayTextMeshProFloatingText());
        }


        public IEnumerator DisplayTextMeshFloatingText()   //this function is never called
        {
            float CountDuration = 2.0f; // How long is the countdown alive.    
            float starting_Count = Random.Range(5f, 20f); // At what number is the counter starting at.
            float current_Count = starting_Count;

            Vector3 start_pos = m_floatingText_Transform.position;
            Color32 start_color = m_textMesh.color;
            float alpha = 255;
            int int_counter = 0;

            float fadeDuration = 3 / starting_Count * CountDuration;

            while (current_Count > 0)
            {
                current_Count -= (Time.deltaTime / CountDuration) * starting_Count;

                if (current_Count <= 3)
                {
                    //Debug.Log("Fading Counter ... " + current_Count.ToString("f2"));
                    alpha = Mathf.Clamp(alpha - (Time.deltaTime / fadeDuration) * 255, 0, 255);
                }

                int_counter = (int)current_Count;
                // m_textMesh.text = int_counter.ToString();                                                                          CHANGED THIS 
                m_textMesh.text = "Hello";
                print("hello");
                //Debug.Log("Current Count:" + current_Count.ToString("f2"));

                m_textMesh.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);

                // Move the floating text upward each update
                m_floatingText_Transform.position += new Vector3(0, starting_Count * Time.deltaTime, 0);

                // Align floating text perpendicular to Camera.
                if (!lastPOS.Compare(m_cameraTransform.position, 1000) || !lastRotation.Compare(m_cameraTransform.rotation, 1000))
                {
                    lastPOS = m_cameraTransform.position;
                    lastRotation = m_cameraTransform.rotation;
                    m_floatingText_Transform.rotation = lastRotation;
                    Vector3 dir = m_transform.position - lastPOS;
                    m_transform.forward = new Vector3(dir.x, 0, dir.z);
                }



                yield return new WaitForEndOfFrame();
            }

            //Debug.Log("Done Counting down.");

            yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));

            m_floatingText_Transform.position = start_pos;

            StartCoroutine(DisplayTextMeshFloatingText());
        }
    }
}
