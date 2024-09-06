using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject weapon0;
    [SerializeField] private GameObject weapon1;
    [SerializeField] private List <GameObject> weapon0DisableObject = new List<GameObject>();
    [SerializeField] private List <GameObject> weapon1DisableObject = new List<GameObject>();
    [SerializeField] private List<List<GameObject>> weaponsDisableObject = new List<List<GameObject>>();

    private void Awake()
    {
        foreach (var weapon in weapon1DisableObject)
        {
            weapon.gameObject.SetActive(false);
        }
        weapon1.GetComponent<PistolStateMachine>().enabled = false;
        weapon0.GetComponent<HandWeaponStateMachine>().enabled = true;
        foreach (var weapon in weapon0DisableObject)
        {
            weapon.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if(InputManager.IsChooseWeapon1) 
        {
           foreach(var weapon in weapon1DisableObject) 
            { 
                weapon.gameObject.SetActive(false);
            }
            weapon1.GetComponent<PistolStateMachine>().enabled = false;
            weapon0.GetComponent<HandWeaponStateMachine>().enabled = true;
            foreach(var weapon in weapon0DisableObject)
            {
                weapon.gameObject.SetActive(true);
            }
        }
        if(InputManager.IsChooseWeapon2)
        {
            foreach (var weapon in weapon0DisableObject)
            {
                weapon.gameObject.SetActive(false);
            }
            weapon0.GetComponent<HandWeaponStateMachine>().enabled = false;
            weapon1.GetComponent<PistolStateMachine>().enabled = true;
           
            foreach (var weapon in weapon1DisableObject)
            {
                weapon.gameObject.SetActive(true);
            }
        }
    }

   
}