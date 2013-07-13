sampler2D g_texture;

float4 PixelShaderFunction(float4 inputColor : COLOR0, float2 coord : TEXCOORD0) : COLOR0
{
	float4 color = tex2D(g_texture, coord.xy) * inputColor;
	return color;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
