using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyAttack : ScriptableObject
{
    public string id;
    public int damage;

    public string Id { get { return CSVReader.Instance.GetWord(id); } set { id = value; } }
}
