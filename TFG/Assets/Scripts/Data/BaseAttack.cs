using UnityEngine;
using System.Collections;

public class BaseAttack : ScriptableObject {

    public string id;
    public int damage = 10;

    public string Id { get { return CSVReader.Instance.GetWord(id); } set { id = value; } }
}
