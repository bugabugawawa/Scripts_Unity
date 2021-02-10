using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsClass : MonoBehaviour
{
    public static Material[] playerMaterial;
    public static GameObject player;

    [SerializeField]
    public Image[] sprites;

    public Dictionary<int, skillStruct> activeSkills = new Dictionary<int, skillStruct>();

    public List<GameObject> SkillsUI = new List<GameObject>();

    public static SkillsClass skillClass;

    public static bool lockSkill=false;

    //this is counting how many skills there are in the SkillsManagementStruct
    public int SkillCount=1;

    private void Start()
    {
        player = this.gameObject;

        playerMaterial = new Material[transform.GetChild(2).childCount];

        for (int i = 0; i < playerMaterial.Length; i++)
        {
            if (player.transform.GetChild(2).GetChild(i).TryGetComponent<Renderer>(out var rend))
            {
                playerMaterial[i] = player.transform.GetChild(2).GetChild(i).GetComponent<Renderer>().material;
            }
        }

        //playerMaterial = GetComponent<Renderer>().materials;

        // For test porpuses, later on this should be handled by a load script or something like that.
        //skillStruct skill = new skillStruct();
        //skill.sourceImage = sprites[0];
        //skill.CD = 5f;
        //skill.key = 1;
        //activeSkills.Add(0, skill);
        //
        //skillClass = this;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        //Debug.Log(activeSkills[0].key);
    //        //StartCoroutine(skillClass.Blinking());
    //        //Blink.blinkSkill.blink(Time.time, this.gameObject);
    //        //selectSkill((int)activeSkills[0].key);
    //    }
    //}

    //void selectSkill(int S)
    //{
    //    switch (S)
    //    {
    //        case 1:
    //            skills.blink((float)Time.time);
    //            break;
    //    }
    //}

    public struct skillStruct
    {
        public int key;
        public float CD;
        public Image sourceImage;
    }

}
