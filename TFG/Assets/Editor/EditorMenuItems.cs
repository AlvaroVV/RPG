using UnityEngine;
using UnityEditor;

static class EditorMenuItems
{

    [MenuItem("Assets/Create/Scriptable Object/WeaponData")]
    public static void CreateWeaponData()
    {
        ScriptableObjectUtility.CreateAsset<WeaponData>();
    }


    [MenuItem("Assets/Create/Scriptable Object/Equipment")]
    public static void CreateEquipmentData()
    {
        ScriptableObjectUtility.CreateAsset<EquipmentData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/Enemy/Enemy")]
    public static void CreateEnemy()
    {
        ScriptableObjectUtility.CreateAsset<EnemyData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/Enemy/Attack Enemy")]
    public static void CreateEnemyAttack()
    {
        ScriptableObjectUtility.CreateAsset<EnemyAttack>();
    }
}
