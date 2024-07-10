using UnityEngine;

public class MakeOpaque : MonoBehaviour
{
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            // Ensure the shader is Standard (or another opaque shader)
            rend.material.shader = Shader.Find("Standard");

            // Set the rendering mode to Opaque
            rend.material.SetFloat("_Mode", 0);
            rend.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            rend.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            rend.material.SetInt("_ZWrite", 1);
            rend.material.DisableKeyword("_ALPHATEST_ON");
            rend.material.DisableKeyword("_ALPHABLEND_ON");
            rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            rend.material.renderQueue = -1;

            // Set the color to fully opaque
            Color color = rend.material.color;
            color.a = 1.0f;
            rend.material.color = color;
        }
    }
}

