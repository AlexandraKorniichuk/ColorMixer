using UnityEngine;

public class BlenderEffects : MonoBehaviour
{
    [SerializeField] private GameObject Particles;
    
    [SerializeField] private Transform SpawnPosition;
    private GameObject ObjectToInstantiate;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetObject(GameObject ingredient) =>
        ObjectToInstantiate = ingredient;

    public void StartAnimation(string toDo) =>
        animator.SetTrigger($"{toDo}Lid");

    public void InstantiateIngredient()
    {
        Instantiate(Particles, SpawnPosition.position, Quaternion.identity);
        Instantiate(ObjectToInstantiate, SpawnPosition.position, Quaternion.identity);
    }
}
