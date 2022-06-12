using System;
using System.Collections.Generic;
using UnityEngine;

public class BlenderEffects : MonoBehaviour
{
    [SerializeField] private GameObject IngredientParticles;
    [SerializeField] private GameObject MixingParticles;

    [SerializeField] private Transform IngredientTransform;
    [SerializeField] private Transform MixEffectsTransform;

    private List<GameObject> InstantiatedIngredients;
    private GameObject ObjectToInstantiate;

    public Action OnMixEnded;

    public GameObject InstantiatedObject { get; private set; }

    private Animator animator;
    private Blender blender;

    void Start()
    {
        animator = GetComponent<Animator>();
        blender = GetComponent<Blender>();

        InstantiatedIngredients = new List<GameObject>();
    }

    public void PrepareForEffects(GameObject ingredient)
    {
        SetObject(ingredient);
        StartAnimation("OpenLid");
    }

    private void SetObject(GameObject ingredient) =>
        ObjectToInstantiate = ingredient;

    public void StartAnimation(string triggerName) =>
        animator.SetTrigger(triggerName);

    public void InstantiateIngredient()
    {
        Instantiate(IngredientParticles, IngredientTransform.position, Quaternion.identity);
        InstantiatedObject = Instantiate(ObjectToInstantiate, IngredientTransform.position, Quaternion.identity);
        InstantiatedIngredients.Add(InstantiatedObject);
    }

    public void DeleteIfContains()
    {
        if (blender.IsNewIngredientContains)
            Destroy(InstantiatedObject);
    }

    public bool IsEffectsGoing() =>
        !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");

    public void InstantiateMixEffects() =>
        Instantiate(MixingParticles, MixEffectsTransform.position, Quaternion.identity);

    public void MakeEffectsAfterMix()
    {
        DeleteIngredients();
        MakeLiquid();
    }

    private void DeleteIngredients()
    {
        foreach (GameObject ingredient in InstantiatedIngredients)
            Destroy(ingredient);
        InstantiatedIngredients.Clear();
    }

    private void MakeLiquid()
    {

    }

    public void EndEffect()
    {
        if (OnMixEnded != null) OnMixEnded.Invoke();
    }
}
