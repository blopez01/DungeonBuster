using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponCycle : MonoBehaviour
{
    public GameObject player;
    public Animator aPlayerAnim;
    public TMP_Text tActiveWeaponText;
    public int iCurrentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }
    void Awake()
    {
        player = GameObject.Find("Player");
        aPlayerAnim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 0)
        {
            aPlayerAnim.SetInteger("ArmedCondition", 1);
        }
        else
        {
            aPlayerAnim.SetInteger("ArmedCondition", 0);
        }
        int iPreviousWeapon = iCurrentWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (iCurrentWeapon >= transform.childCount - 1)
                iCurrentWeapon = 0;
            else
                iCurrentWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (iCurrentWeapon <= 0)
                iCurrentWeapon = transform.childCount - 1;
            else
                iCurrentWeapon--;
        }
        if (iPreviousWeapon != iCurrentWeapon)
        {
            SelectWeapon();
        }

    }

    public void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == iCurrentWeapon)
            {
                weapon.gameObject.SetActive(true);
                tActiveWeaponText.text = weapon.gameObject.tag;
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
