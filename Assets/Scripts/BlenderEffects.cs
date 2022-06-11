using UnityEngine;

public class BlenderEffects : MonoBehaviour
{
    [SerializeField] private GameObject Particles;
    
    [SerializeField] private Transform SpawnPosition;
    private GameObject ObjectToInstantiate;
    public GameObject InstantiatedObject { get; private set; }

    private Animator animator;
    private Blender blender;

    void Start()
    {
        animator = GetComponent<Animator>();
        blender = GetComponent<Blender>();
    }

    public void PrepareForEffects(GameObject ingredient)
    {
        SetObject(ingredient);
        StartLidAnimation();
    }

    private void SetObject(GameObject ingredient) =>
        ObjectToInstantiate = ingredient;

    private void StartLidAnimation() =>
        animator.SetTrigger($"OpenLid");

    public void InstantiateIngredient()
    {
        Instantiate(Particles, SpawnPosition.position, Quaternion.identity);
        InstantiatedObject = Instantiate(ObjectToInstantiate, SpawnPosition.position, Quaternion.identity);
    }

    public void StartStaggering() =>
        animator.SetTrigger("IngredientFell");

    public void DeleteIfContains()
    {
        if (blender.IsNewIngredientContains)
            Destroy(InstantiatedObject);
    }

    public bool IsEffectsGoing() =>
        !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
}
