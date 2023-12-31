using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Skill
{
    private void Awake()
    {
        this.skillCoolDown = 0f;
        this.skillCost = 0f;
        this.coolDown = 45;
        //InvokeRepeating("SkillCoolDown",1f,1f);
        Debug.Log("곰의 활력 추가됨");
    }
    public override bool Ability(Player player)
    {
        if (skillCoolDown <= 0)
        {
            Debug.Log("곰의활력 사용");
            // 애니메이션 실행,이펙트 실행, 사운드 실행

            // 기능실행
            StartCoroutine(BearVitality(player));
            this.skillCoolDown = this.coolDown;
            this.skillImage.fillAmount = 0f;
            this.skillCoolDown = this.coolDown;
            //InvokeRepeating("SkillCoolDown", 1f, 1f);
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator BearVitality(Player player)
    {
        float originGenHP = player.stats.genHp;
        player.stats.genHp = 0.05f;
        Debug.Log(player.stats.genHp);
        yield return new WaitForSeconds(5f);
        player.stats.genHp = originGenHP;
        Debug.Log(player.stats.genHp);
    }
    void SkillCoolDown()
    {
        if (this.skillCoolDown <= 0)
        {
            this.skillCoolDown = 0;
            CancelInvoke("SkillCoolDown");
            return;
        }
        this.skillCoolDown--;
        this.skillImage.fillAmount = (this.coolDown - this.skillCoolDown) / this.coolDown;
    }
}