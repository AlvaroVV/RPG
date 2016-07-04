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
        ScriptableObjectUtility.CreateAsset<CharacterData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/new DamageAttack")]
    public static void CreateCharacterAttack()
    {
        ScriptableObjectUtility.CreateAsset<DamageAttack>();
    }

    [MenuItem("Assets/Create/Scriptable Object/new Item")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<ItemData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/new Potion")]
    public static void CreatePotion()
    {
        ScriptableObjectUtility.CreateAsset<PotionData>();
    }

}
