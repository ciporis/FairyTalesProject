using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu(menuName = "Configs/FairyTaleConfig", fileName = "FairyTaleConfig")]
public class FairyTaleConfig : ScriptableObject
{
    [field: SerializeField] public string TextFile;
    [field: SerializeField] public string SlidesDirectory;
    [field: SerializeField] public string AudioDirectory;
}