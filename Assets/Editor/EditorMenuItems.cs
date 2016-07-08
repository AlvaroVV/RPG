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

    [MenuItem("Assets/Create/Scriptable Object/Attack/new DamageAttack")]
    public static void CreateCharacterAttack()
    {
        ScriptableObjectUtility.CreateAsset<DamageAttack>();
    }

    [MenuItem("Assets/Create/Scriptable Object/Attack/new HealthAttack")]
    public static void CreateNewHealthAttack()
    {
        ScriptableObjectUtility.CreateAsset<HealthAttack>();
    }


    [MenuItem("Assets/Create/Scriptable Object/Items/new Health Potion")]
    public static void CreatePotion()
    {
        ScriptableObjectUtility.CreateAsset<PotionHealthData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/Items/new Parchment")]
    public static void CreateParchment()
    {
        ScriptableObjectUtility.CreateAsset<PergaminoData>();
    }

    [MenuItem("Assets/Create/Scriptable Object/Items/new Mana Potion")]
    public static void CreateManaPotion()
    {
        ScriptableObjectUtility.CreateAsset<PotionManaData>();
    }

}
