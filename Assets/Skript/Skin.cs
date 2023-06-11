using UnityEngine;

[CreateAssetMenu(menuName = "Skins/new Skin...", order = 1, fileName = "skin-name")]
public class Skin : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private float _cost;
    
    [SerializeField]private bool _isSold = false;
    
    public Mesh SkinMesh => _mesh;
    public float Cost => _cost;
    public bool IsSold => _isSold;
    
    public void Buy()
    {
        _isSold = true;
    }

}
