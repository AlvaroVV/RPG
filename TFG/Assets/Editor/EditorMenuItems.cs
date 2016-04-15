using UnityEngine;
using UnityEditor;

static class EditorMenuItems
{

    [MenuItem("Assets/Create/Scriptable Object/Character/WeaponData")]
    public static void CreateWeaponData()
    {
        ScriptableObjectUtility.CreateAsset<WeaponData>();
    }


    [MenuItem("Assets/Create/Scriptable Object/Character/Equipment")]
    public static void CreateEquipmentData()
    {
        ScriptableObjectUtility.CreateAsset<EquipmentData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/Enemy/Enemy")]
    public static void CreateEnemy()
    {
        ScriptableObjectUtility.CreateAsset<EnemyData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/Character/new Character")]
    public static void CreateNewCharacter()
    {
        ScriptableObjectUtility.CreateAsset<BaseStatCharacter>();
    }

    [MenuItem("Assets/Create/Scriptable Object/new Attack")]
    public static void CreateCharacterAttack()
    {
        ScriptableObjectUtility.CreateAsset<AttackInfo>();
    }
}
