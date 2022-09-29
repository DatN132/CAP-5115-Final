/*
*   Copyright (C) 2020 University of Central Florida, created by Dr. Ryan P. McMahan.
*
*   This program is free software: you can redistribute it and/or modify
*   it under the terms of the GNU General Public License as published by
*   the Free Software Foundation, either version 3 of the License, or
*   (at your option) any later version.
*
*   This program is distributed in the hope that it will be useful,
*   but WITHOUT ANY WARRANTY; without even the implied warranty of
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*   GNU General Public License for more details.
*
*   You should have received a copy of the GNU General Public License
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*
*   Primary Author Contact:  Dr. Ryan P. McMahan <rpm@ucf.edu>
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.XR.Interaction.Toolkit
{
    // The Disable Interactable disables any selected interactable.
    [AddComponentMenu("XRST/Interaction/DisableInteractable")]
    public class DisableInteractable : MonoBehaviour
    {
        // The interactor to use for disabling selected interactables.
        [SerializeField]
        [Tooltip("The interactor to use for disabling selected interactables.")]
        XRBaseControllerInteractor m_Interactor;
        public XRBaseControllerInteractor Interactor { get { return m_Interactor; } set { m_Interactor = value; } }

        // Whether the listener has been added.
        bool listenerAdded;

        // Listener called by the interactor's OnSelectEnter interactor event.
        public void Disable(XRBaseInteractable interactable)
        {
            // If an interactor and interacble exist.
            if (Interactor != null && interactable != null)
            {
                // Deactivate the interactable game object.
                interactable.gameObject.SetActive(false);
            }
        }

        // Reset function for initializing the disable interactable.
        void Reset()
        {
            // Attempt to fetch a local interactor.
            m_Interactor = GetComponent<XRBaseControllerInteractor>();

            // Did not find a local interactor.
            if (m_Interactor == null)
            {
                // Warn the developer.
                Debug.LogWarning("[" + gameObject.name + "][DisableInteractable]: Did not find a local XRBaseControllerInteractor attached to the same game object.");

                // Attepmt to fetch any interactor.
                m_Interactor = FindObjectOfType<XRBaseControllerInteractor>();

                // Did not find one.
                if (m_Interactor == null)
                {
                    Debug.LogWarning("[" + gameObject.name + "][DisableInteractable]: Did not find an XRBaseControllerInteractor in the scene.");
                }
                // Found one.
                else
                {
                    Debug.LogWarning("[" + gameObject.name + "][DisableInteractable]: Found an XRBaseControllerInteractor attached to " + m_Interactor.gameObject.name + ".");
                }
            }
        }

        // This function is called when the behaviour becomes disabled.
        void OnDisable()
        {
            // Attempt to remove the Disable listener from the events of the ray interactor.
            if (m_Interactor != null && listenerAdded)
            {
                // Remove the Disable function as a listener.
                m_Interactor.onSelectEnter.RemoveListener(Disable);
                // Keep track of removing the listeners.
                listenerAdded = false;
            }
        }

        // This function is called when the object becomes enabled and active.
        void OnEnable()
        {
            // Attempt to add the Disable listener to the events of the ray interactor.
            if (m_Interactor != null && !listenerAdded)
            {
                // Add the SetOffset function as a listener.
                m_Interactor.onSelectEnter.AddListener(Disable);
                // Keep track of adding the listeners.
                listenerAdded = true;
            }
        }
    }
}
