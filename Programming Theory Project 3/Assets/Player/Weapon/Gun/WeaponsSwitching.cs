using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    [SerializeField] float TimeForChange = 1f;
    private bool Changing = false;
    public bool P_Changing 
    {
        get { return Changing; }
    }
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        selectEqualsManual();
    }

    void selectEqualsManual()
    {
        if (Changing)
            return;

        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 1)
        {
            selectedWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2)
        {
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            StartCoroutine(SelectWeapon());
        }
    }

    IEnumerator SelectWeapon()
    {
        Changing = true;
        animator.SetBool("Changing", true);
        yield return new WaitForSeconds(TimeForChange - 0.25f);
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
        animator.SetBool("Changing", false);
        yield return new WaitForSeconds(0.25f);
        Changing = false;
    }


}
