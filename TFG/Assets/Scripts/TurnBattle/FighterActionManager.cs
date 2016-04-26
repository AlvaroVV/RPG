using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FighterActionManager: MonoBehaviour  {

    private static FighterActionManager instance;
    public static FighterActionManager Instance { get { return instance; } }

    //Listas
    public List<Fighter> StackTurnFighter { get; set; }
    public List<EnemyFighter> EnemyFighters { get; set; }
    public List<CharacterFighter> PlayerTeamFighters { get; set; }

    public Fighter currentFighter { get; set; }
    public AttackInfo attackInfo { get; set; } //Ataque elegido
    public Fighter target { get; set; } //Enemigo elegido

    public Cursor FighterCursor { get; set; }

    private GameObject attackEffect;

    void Awake()
    {
        instance = this;
        StackTurnFighter = new List<Fighter>();
        PlayerTeamFighters = new List<CharacterFighter>();
        EnemyFighters = new List<EnemyFighter>();
    }

    //STATE METHODS WITH COROUTINES
   
    public IEnumerator WaitForAttack()
    {
        currentFighter.ChooseAttack();

        while (attackInfo == null)
            yield return null;
    }

    public IEnumerator waitForTarget()
    {
        while (target == null)
        {
            currentFighter.ChooseTarget();
            yield return null;
        }
    }

    public IEnumerator WaitForFinishAttackEffect()
    {
        Debug.Log(target.FighterData.currentHP);
        currentFighter.ChooseState();
        //Esperamos a que se cree el ataque
        while (attackEffect == null)
            yield return null;
        //Esperamos a que finalice
        while (attackEffect != null)
            yield return null;
    }

    public IEnumerator ResolveAction()
    {
        int damage = calculateDamage();

        GameObject DamageText = CombatTextManager.Instance.CreateBounceText(target.transform.position, damage);
        while (DamageText != null)
            yield return null;

        currentFighter.SetIdleState();
        target.SetIdleState();
        target.SetDamage(damage);
        yield return null;
    }

    public IEnumerator VerifyState()
    {
        //Si es un enemigo lo destruimos, si es un personaje ponemos estado derrotado para que pueda ser resucitado
        Debug.Log(target.FighterData.currentHP);
        if(target.FighterData.currentHP <= 0)
        {
            if (target is EnemyFighter)
            {
                Debug.Log("MUERTO");
                EnemyFighters.Remove((EnemyFighter)target);
                DestroyObject(target.gameObject);
            }
            else
                target.FighterAnimator.SetTrigger("Dead");

        }

        //Eliminamos la información
        currentFighter = null;
        attackInfo = null;
        target = null;

        yield return null;
    }


    public void CreateAttackEffect()
    {
        if (attackInfo != null)
        {
            attackEffect = Instantiate(attackInfo.Animation, target.transform.position, Quaternion.identity) as GameObject;
            target.FighterAnimator.SetTrigger("Hurt");
        }
        else
            Debug.LogError("No se ha cargado el ataque");
    }

    //FIGHTER CURSOR METHODS

    public void TargetFirstEnemy()
    {
        Fighter target = EnemyFighters.Where(x => x.FighterData.currentHP > 0).FirstOrDefault();
        FighterCursor.gameObject.SetActive(true);
        FighterCursor.ChangeTarget(target);
    }

    public void CreateFightCursor()
    {
        GameObject cursorRes = Resources.Load("UI/Cursor") as GameObject;
        GameObject cursorObj = GameObject.Instantiate(cursorRes, transform.position, Quaternion.identity) as GameObject;
        cursorObj.transform.parent = transform;
        FighterCursor = cursorObj.GetComponent<Cursor>();
        FighterCursor.gameObject.SetActive(false);
    }



    //CLEAN LISTS METHODS

    public void CleanAndFinish()
    {
        CleanEnemiesList(); //TEMPORAL
        CleanStackList(); //TEMPORAL
        StartCoroutine(GameGlobals.FinishFight());
        GameGlobals.player.StateIdle();

    }

    private void CleanEnemiesList()
    {
        foreach (EnemyFighter enemy in EnemyFighters)
            DestroyObject(enemy.gameObject);
        EnemyFighters = new List<EnemyFighter>();
    }

    private void CleanStackList()
    {
        Destroy(FighterCursor.gameObject);
        StackTurnFighter = new List<Fighter>();
    }

    public void CleanCharactersList()
    {
        foreach (CharacterFighter charac in PlayerTeamFighters)
            DestroyObject(charac.gameObject);
        PlayerTeamFighters = new List<CharacterFighter>();
    }

    public void DestroyObject(GameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
        gameObject.transform.SetParent(null);
        Destroy(gameObject.gameObject);
    }

    //Damage Algorithms

    public int calculateDamage()
    {
        float damage = 0;
        switch (attackInfo.attackType)
        {
            case GameGlobals.AttackType.Attack:
                damage= (attackInfo.damage + currentFighter.FighterData.AttackPower * 0.4f - target.FighterData.defensePower * 0.4f);
                break;
            case GameGlobals.AttackType.Magic:
                damage =(attackInfo.damage + currentFighter.FighterData.MagicPower * 0.2f - target.FighterData.MagicDefense * 0.2f);
                break;
            default:
                return 0;

        }

        return (int)Random.Range(damage*0.8f,damage*1.2f);
    }

}
