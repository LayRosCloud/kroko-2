using UnityEngine;

[CreateAssetMenu(menuName = "Skins/new Skin...", order = 1, fileName = "skin-name")]
public class Skin : ScriptableObject
{
    [Header("Person info")]
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [Space]
    [SerializeField] private bool _isSold = false;
    [SerializeField] private int _cost;
    [Space]
    [SerializeField] private Mesh _mesh;

    public Skin()
    {
        ShopEvents.Instance.BuyEvent += Buy;
    }

    ~Skin()
    {
        ShopEvents.Instance.BuyEvent -= Buy;
    }

    public Mesh SkinMesh => _mesh;
    public int Cost => _cost;
    public bool IsSold => _isSold;
    public string Description => _description;
    public string Name => _name;
    
    public void Buy()
    {
        _isSold = true;
    }

}
