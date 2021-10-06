using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Frost")]
public class FrostEffect : MonoBehaviour
{
    public float FrostAmount = 0.5f; //0-1 (0=minimum Frost, 1=maximum frost)
    private float EdgeSharpness = 300; //>=1
    public float minFrost = 0; //0-1
    public float maxFrost = 1; //0-1
    public float seethroughness = 0.2f; //blends between 2 ways of applying the frost effect: 0=normal blend mode, 1="overlay" blend mode
    public float distortion = 0.1f; //how much the original image is distorted through the frost (value depends on normal map)
    public Texture2D Frost; //RGBA
    public Texture2D FrostNormals; //normalmap
    public Shader Shader; //ImageBlendEffect.shader
    private FridgeSnow fri_snow_manager;
	private Material material;
    private float[] frost_amount_arr = new float[6]; 
    private void Start()
    {
        material = new Material(Shader);
        material.SetTexture("_BlendTex", Frost);
        material.SetTexture("_BumpMap", FrostNormals);
        fri_snow_manager = GameObject.FindObjectOfType<FridgeSnow>();
        material.SetTexture("_BlendTex", Frost);
        material.SetTexture("_BumpMap", FrostNormals);
        frost_amount_arr[0] = 0;
        frost_amount_arr[1] = 0.4f;
        frost_amount_arr[2] = 0.45f;
        frost_amount_arr[3] = 0.48f;
        frost_amount_arr[4] = 0.52f;
        frost_amount_arr[5] = 0.54f;
    }
	
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        int freeze_amount = fri_snow_manager.is_in_fridge();
        FrostAmount = frost_amount_arr[freeze_amount];
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(FrostAmount) * (maxFrost - minFrost) + minFrost));
        material.SetFloat("_EdgeSharpness", EdgeSharpness);
        material.SetFloat("_SeeThroughness", seethroughness);
        material.SetFloat("_Distortion", distortion);
  

		Graphics.Blit(source, destination, material);
	}
}