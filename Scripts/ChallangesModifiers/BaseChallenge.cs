using Genral;
using UnityEngine;
using UnityEngine.UI;

namespace ChallangesModifiers
{
    /// <summary>
    /// TODO: All Challenges should not be modifiable in inspector.
    /// TODO: Instantiate a challenge should not have side effects. 
    /// </summary>
    public abstract class BaseChallenge : MonoBehaviour
    {
        private string _name = "PLACEHOLDER";
        private string _description = "PLACEHOLDER DESC";
        private Modifier _difficultyModifier;

        public Toggle PrefabToggle;

        public virtual string Name
        {
            get => _name;
            set => _name = value;
        }

        public virtual string Description
        {
            get => _description;
            set => _description = value;
        }

        public virtual Modifier DifficultyModifier
        {
            get => _difficultyModifier;
            set => _difficultyModifier = value;
        }

        public virtual void OnLevelLoaded()
        {
            
        }

        public virtual void Start()
        {
            if (PrefabToggle == null)
            {
                PrefabToggle = this.gameObject.GetComponent<Toggle>();
            }
            // this.gameObject.GetComponentInChildren<Text>().text = Name;
        }

        public void OnChange(bool state)
        {
            
        }
    }
}