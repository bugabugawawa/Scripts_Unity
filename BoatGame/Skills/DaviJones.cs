using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaviJones : MonoBehaviour
{
    //public Image blinkIcon;
    //private float[] cooldowns = new float[10];
    // Tenho que da um jeito de armazenar essas variaveis separadamente de maneira melhor para cada skill.
    [SerializeField]
    float CD = 5f, coolDown = 0;

    public static DaviJones daviJones;

    Material[] playerMaterial;

    GameObject UIskillImage;

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////
    /// TO COM SONO SE VIRA PAREI ANTES DE CHECAR SE TA ATIVO;
    /// ///////////////////////////////////////////////////////////////////////////////
    /// </summary>

    private void Start()
    {
        daviJones = this;
    }

    public void Update()
    {
        playerMaterial = SkillsClass.playerMaterial;
        UIskillImage = GetComponent<SkillsClass>().SkillsUI[1];

        if (Input.GetKeyDown(KeyCode.Alpha2) && SkillsClass.lockSkill==false)
        {
            if (coolDown < Time.time)
            {
                coolDown = Time.time + CD + .8f;
                SkillsClass.lockSkill = true;
                StartCoroutine(Sinking(SkillsClass.player));
            }
        }
    }
    
    IEnumerator Sinking(GameObject player)
    {
        float ft = 0f;
        player.transform.GetChild(0).gameObject.active = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().angularDrag = 10;
        for (; ft <= 4f; ft += 0.1f)
        {
            for (int i = 0; i < playerMaterial.Length; i++)
            {
                playerMaterial[i].SetFloat("Vector1_0c34d41be301477da3e27205debb3859", ft);
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - .03f, player.transform.position.z);
            }
            yield return new WaitForSeconds(.02f);
        }
        for (; ft >= 0f; ft -= 0.1f)
        {
            for (int i = 0; i < playerMaterial.Length; i++)
            {
                playerMaterial[i].SetFloat("Vector1_0c34d41be301477da3e27205debb3859", ft);
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .03f, player.transform.position.z);
            }
            yield return new WaitForSeconds(.02f);
        }
        for (int i = 0; i < playerMaterial.Length; i++)
        {
            playerMaterial[i].SetFloat("Vector1_0c34d41be301477da3e27205debb3859", 0);
        }
        player.transform.GetChild(0).gameObject.active = true;
        SkillsClass.lockSkill = false;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().angularDrag = 0.05f;
        for (float cd = 0f; cd < CD; cd += 0.1f)
        {
            UIskillImage.GetComponent<Image>().fillAmount = cd / CD;
            yield return new WaitForSeconds(.1f);
        }

    }

}