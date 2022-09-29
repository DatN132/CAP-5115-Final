using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLightSwitch : MonoBehaviour
{
    public AudioClip hoverEnterSound;
    public void Switch()
    {
      GameObject parent = GameObject.Find("Scene");
      GameObject Onswitch = parent.transform.Find("LightSwitchSingleON").gameObject;
      GameObject OFFswitch = parent.transform.Find("LightSwitchSingleOFF").gameObject;
      GameObject lamp = parent.transform.Find("Lamp").gameObject;
      GameObject lamp1 = parent.transform.Find("Lamp1").gameObject;
      Onswitch.SetActive(!Onswitch.activeSelf);
      OFFswitch.SetActive(!OFFswitch.activeSelf);
      // if on
      if (Onswitch.activeSelf)
      {
        Material mat = Resources.Load("Materials/Small_roof_lamp", typeof(Material)) as Material;
        lamp.GetComponent<MeshRenderer>().material = mat;
        lamp1.GetComponent<MeshRenderer>().material = mat;
        lamp.transform.Find("Spot Light").gameObject.SetActive(true);
        lamp1.transform.Find("Spot Light 1").gameObject.SetActive(true);
      }
      else
      {
        Material mat = Resources.Load("Materials/Small_roof_lamp_OFF", typeof(Material)) as Material;
        lamp.GetComponent<MeshRenderer>().material = mat;
        lamp1.GetComponent<MeshRenderer>().material = mat;
        lamp.transform.Find("Spot Light").gameObject.SetActive(false);
        lamp1.transform.Find("Spot Light 1").gameObject.SetActive(false);
      }

    }
}
