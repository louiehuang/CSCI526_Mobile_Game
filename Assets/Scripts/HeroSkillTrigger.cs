using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HeroSkillTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public string heroName;
    public Image SkillDescBackground;

    private bool pointerDown;
    private float pointerDownTimer;
    private float requiredHoldTime = 0.8f;

    HeroPool heroPool;

    void Start() {
        heroPool = HeroPool.GetInstance();
    }


    void Update() {
        if (pointerDown) {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime) {
                ShowSkillDescription();
                //Reset();  //let OnPointerUp() do the work
            }
        }
    }


    private void ShowSkillDescription() {
        SkillDescBackground.gameObject.SetActive(true);
    }


    public void OnPointerDown(PointerEventData eventData) {
        pointerDown = true;
    }


    public void OnPointerUp(PointerEventData eventData) {
        //Logger.Log(pointerDownTimer + ", " + requiredHoldTime);
        if (pointerDownTimer < requiredHoldTime) {  //short click, use skill
            UseSkill();
        }

        SkillDescBackground.gameObject.SetActive(false);
        Reset();
    }


    private void UseSkill() { 
        if (EqualsIgnoreCase(heroName, CommonConfig.Knight)) {
            heroPool.UseKnightSkill();
        } else if (EqualsIgnoreCase(heroName, CommonConfig.Archer)) {
            heroPool.UseArcherSkill();
        } else if (EqualsIgnoreCase(heroName, CommonConfig.FireMage)) {
            heroPool.UseFireMageSkill();
        } else if (EqualsIgnoreCase(heroName, CommonConfig.IceMage)) {
            heroPool.UseIceMageSkill();
        } else if (EqualsIgnoreCase(heroName, CommonConfig.Priest)) {
            heroPool.UsePriestSkill();
        } else {
            Logger.Log("Unknown Hero Skill");
        }
    }


    private void Reset() {
        pointerDown = false;
        pointerDownTimer = 0f;
    }


    private bool EqualsIgnoreCase(string str1, string str2) {
        return string.Equals(str1.ToUpper(), str2.ToUpper());
    }
}