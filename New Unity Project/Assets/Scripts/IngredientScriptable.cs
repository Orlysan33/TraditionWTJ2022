using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName ="Item")]
public class IngredientScriptable : ScriptableObject
{
    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private string name;

    [SerializeField]
    private int quantity;

    public Sprite Icon => icon;
    public int Quantity => quantity;
    public string Name => name;

    [SerializeField]
    private GameObject prefabObject;

    [SerializeField]
    private bool isHarvestedItem;

    public bool IsHarvesterItem => isHarvestedItem;

    public GameObject PrefabObject =>  prefabObject;


   

    private void OnEnable()
    {
       
    }


    public void Add(int value)
    {
        quantity += value;
    }

    public void Substract(int value)
    {
        if (quantity - value  >=0 )
        {          
            quantity -= value;
        }
    }
    
   
}
