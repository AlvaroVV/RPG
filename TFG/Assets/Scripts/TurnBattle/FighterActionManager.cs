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
        currentFighter.ChooseState();
        //Esperamos a que se cree el ataque
        while (attackEffect == null)
            yield return null;
        //Esperamos a que finalice
        while (attackEffect != null)
            yield return null;
    }

    public void CreateAttackEffect()
    {
        if (attackInfo != null)
        {
            attackEffect = Instantiate(attackInfo.Animation, target.transform.position, Quaternion.identity) as GameObject;
            target.FighterAnimator.SetTrigger("hurt");
        }
        else
            Debug.LogError("No se ha cargado el ataque");
    }

    //FIGHTER CURSOR METHODS

    public void TargetFirstEnemy()
    {
        Fighter target = EnemyFighters.Where(x => x.EnemyData.currentHP > 0).FirstOrDefault();
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

}
