#define EPSILON_BLUR 1e-5

// https://en.wikipedia.org/wiki/YIQ
static const half3x3 RGB_YIQ = half3x3(0.299, 0.587, 0.114,
								       0.5959, -0.2746, -0.3213,
								       0.2115, -0.5227, 0.3112);

static const half3x3 YIQ_RGB = half3x3(1, 0.956, 0.619,
								       1, -0.272, -0.647,
								       1, -1.106, 1.703);

static const uint MAX_U = 0x7fffffffU;

float4 _ColorAdjustments;
float _Grain;

uint GetSeed(uint2 coord)
{
	return coord.x + (coord.y << 11);
}

// https://en.wikipedia.org/wiki/MurmurHash
float MurmurHash(uint2 coord)
{
	uint hash = GetSeed(coord);
    
	hash ^= hash >> 16;
    hash *= 0x85ebca6bU;
    hash ^= hash >> 13;
    hash *= 0xc2b2ae35U;
    hash ^= hash >> 16;

    return float(hash & MAX_U) / float(MAX_U);
}

half3 ApplyGrain(half3 color, float2 coord) 
{
	half hash = MurmurHash(coord);

	half noise = 2 * (hash - 0.5);

	return color + noise * _Grain;
}

half3 ApplyColorAdjustments(half3 colorRGB)
{
	half contrast = _ColorAdjustments.x; // -1 to 1
	half saturation = _ColorAdjustments.y; // 0 to 2
	half brightness = _ColorAdjustments.z; // 0 to 2
	
	half3 colorYIQ = mul(RGB_YIQ, colorRGB);

	colorYIQ.yz = colorYIQ.yz * saturation * (contrast + 1);
	colorYIQ.x = (colorYIQ.x + (colorYIQ.x - 0.5) * contrast);
	
	return mul(YIQ_RGB, colorYIQ * brightness);
}

half4 BlurSample(sampler2D input, half4x2 uvs)
{
	// Sample the texture box
	half4 bl = tex2Dlod(input, float4(uvs[0], 0, 0));
	half4 br = tex2Dlod(input, float4(uvs[1], 0, 0));
	half4 tl = tex2Dlod(input, float4(uvs[2], 0, 0));
	half4 tr = tex2Dlod(input, float4(uvs[3], 0, 0));

	// We'll discard RGBs for the samples with alpha < EPSILON to prevent
	// color of expected transparent pixels from bleeding into the image
	half4 useRgb = step(EPSILON_BLUR, half4(bl.w, br.w, tl.w, tr.w));

	// Sum the used RGB values
	half4 total = (bl * useRgb.x) + 
				  (br * useRgb.y) + 
				  (tl * useRgb.z) + 
				  (tr * useRgb.w) ;

	// Use the color components of only visible pixels but the alpha of all pixels
	half4 weights = half4((useRgb.x + useRgb.y + useRgb.z + useRgb.w).xxx, 4);

	// Return the corrected average of the samples
	half4 color = half4(total.xyz, total.w) / weights;

	#if defined(COLOR_ADJUSTMENT_ON)
	color = half4(ApplyColorAdjustments(color.xyz), color.w);
	#endif

	return color;
}