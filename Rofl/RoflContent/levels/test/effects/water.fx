sampler2D g_texture1 : register(s0);
sampler2D g_texture2 : register(s1);

float time;

float4 PixelShaderFunction(float4 inputColor : COLOR0, float2 coord : TEXCOORD0) : COLOR0
{
	float2 c = coord;
	coord.y += sin((c.x + time) * 10) / 20;
	coord.x += cos((c.y + time + 1) * 10) / 35 + sin((c.y + time) * 30) / 60;
	float4 color = tex2D(g_texture1, coord.xy) * inputColor;
	color *= tex2D(g_texture2, c.xy);
	color = tex2D(g_texture1, c.xy) * (1 - color.a) + color * color.a;
	return color;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
