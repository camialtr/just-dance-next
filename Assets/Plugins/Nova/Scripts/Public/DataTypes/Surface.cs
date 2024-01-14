// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_5;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Nova
{
    /// <summary>
    /// A lighting model.
    /// <list type="bullet">
    /// <item><description><see cref="Lambert"/> and <see cref="BlinnPhong"/> are simpler models which make approximations 
    /// in exchange for better performance.</description></item>
    /// <item><description><see cref="Standard"/> and <see cref="StandardSpecular"/> are more complex models which 
    /// attempt to approximate the real world, but 
    /// are more expensive.</description></item>
    /// </list>
    /// </summary>
    /// <seealso cref="UIBlock.Surface"/>
    /// <seealso cref="Surface"/>
    /// <seealso cref="Surface.LightingModel"/>
    public enum LightingModel
    {
        /// <summary>
        /// Does not react to lighting (including not casting or receiving shadows).
        /// </summary>
        Unlit = InternalNamespace_0.InternalType_104.InternalField_323,
        /// <summary>
        /// The simplest and cheapest (in terms of performance) lighting model which only has a diffuse component.
        /// </summary>
        Lambert = InternalNamespace_0.InternalType_104.InternalField_324,
        /// <summary>
        /// A simple lighting model which has both a diffuse and a specular component.
        /// </summary>
        BlinnPhong = InternalNamespace_0.InternalType_104.InternalField_325,
        /// <summary>
        /// A lighting model which attempts to approximate the real world and can be used to represent a wide variety of materials.
        /// </summary>
        Standard = InternalNamespace_0.InternalType_104.InternalField_326,
        /// <summary>
        /// A lighting model which attempts to approximate the real world and can be used to represent a wide variety of materials.
        /// </summary>
        StandardSpecular = InternalNamespace_0.InternalType_104.InternalField_327,
    }

    /// <summary>
    /// Describes a lit surface effect using the <see cref="LightingModel.BlinnPhong"/> lighting model.
    /// </summary>
    /// <seealso cref="Surface.BlinnPhong"/>
    /// <seealso cref="UIBlock.Surface"/>
    public struct BlinnPhong : IEquatable<BlinnPhong>
    {
        /// <summary>
        /// Specular power, from <c>0</c> to <c>1</c>.
        /// </summary>
        public float Specular;
        /// <summary>
        /// Specular intensity, from <c>0</c> to <c>1</c>.
        /// </summary>
        public float Gloss;

        /// <summary>
        /// Creates a new <see cref="BlinnPhong"/> descriptor with the specified specular and gloss values.
        /// </summary>
        /// <param name="specular"></param>
        /// <param name="gloss"></param>
        public BlinnPhong(float specular, float gloss)
        {
            Specular = specular;
            Gloss = gloss;
        }

        public static bool operator ==(BlinnPhong lhs, BlinnPhong rhs)
        {
            return
                lhs.Specular.Equals(rhs.Specular) &&
                lhs.Gloss.Equals(rhs.Gloss);
        }
        public static bool operator !=(BlinnPhong lhs, BlinnPhong rhs) => !(rhs == lhs);

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Specular.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Gloss.GetHashCode();
            return InternalVar_1;
        }

        public override bool Equals(object other)
        {
            if (other is BlinnPhong asType)
            {
                return this == asType;
            }

            return false;
        }

        public bool Equals(BlinnPhong other) => this == other;

        /// <summary>
        /// The string representation of this <see cref="BlinnPhong"/>.
        /// </summary>
        public override string ToString()
        {
            return $"Specular = {Specular}, Gloss = {Gloss}";
        }
    }

    /// <summary>
    /// Describes a lit surface effect using the <see cref="LightingModel.Standard"/> lighting model.
    /// </summary>
    /// <seealso cref="Surface.Standard"/>
    /// <seealso cref="UIBlock.Surface"/>
    public struct Standard : IEquatable<Standard>
    {
        /// <summary>
        /// How smooth the surface is, from <c>0</c> (rough) to <c>1</c> (smooth).
        /// </summary>
        public float Smoothness;
        /// <summary>
        /// How metallic the surface is, from <c>0</c> (non-metal) to <c>1</c> (metal).
        /// </summary>
        public float Metallic;

        /// <summary>
        /// Creates a new <see cref="Standard"/> descriptor with the specified smoothness and metallic values.
        /// </summary>
        public Standard(float smoothness, float metallic)
        {
            Smoothness = smoothness;
            Metallic = metallic;
        }

        public static bool operator ==(Standard lhs, Standard rhs)
        {
            return
                lhs.Smoothness.Equals(rhs.Smoothness) &&
                lhs.Metallic.Equals(rhs.Metallic);
        }

        public static bool operator !=(Standard lhs, Standard rhs) => !(rhs == lhs);

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Smoothness.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Metallic.GetHashCode();
            return InternalVar_1;
        }

        public override bool Equals(object other)
        {
            if (other is Standard asType)
            {
                return this == asType;
            }

            return false;
        }

        public bool Equals(Standard other) => this == other;

        /// <summary>
        /// The string representation of this <see cref="Standard"/>.
        /// </summary>
        public override string ToString()
        {
            return $"Smoothness = {Smoothness}, Metallic = {Metallic}";
        }
    }

    /// <summary>
    /// Describes a lit surface effect using the <see cref="LightingModel.StandardSpecular"/> lighting model.
    /// </summary>
    /// <seealso cref="Surface.StandardSpecular"/>
    /// <seealso cref="UIBlock.Surface"/>
    public struct StandardSpecular : IEquatable<StandardSpecular>
    {
        /// <summary>
        /// The color of the specular reflections.
        /// </summary>
        public Color SpecularColor;
        /// <summary>
        /// How smooth the surface is, from <c>0</c> (rough) to <c>1</c> (smooth).
        /// </summary>
        public float Smoothness;

        /// <summary>
        /// Creates a new <see cref="Standard"/> descriptor with the specified specular color and smoothness value.
        /// </summary>
        public StandardSpecular(Color specularColor, float smoothness)
        {
            SpecularColor = specularColor;
            Smoothness = smoothness;
        }

        public static bool operator ==(StandardSpecular lhs, StandardSpecular rhs)
        {
            return
                lhs.Smoothness.Equals(rhs.Smoothness) &&
                lhs.SpecularColor.Equals(rhs.SpecularColor);
        }
        public static bool operator !=(StandardSpecular lhs, StandardSpecular rhs) => !(rhs == lhs);

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + SpecularColor.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Smoothness.GetHashCode();
            return InternalVar_1;
        }

        public override bool Equals(object other)
        {
            if (other is StandardSpecular asType)
            {
                return this == asType;
            }

            return false;
        }

        public bool Equals(StandardSpecular other) => this == other;

        /// <summary>
        /// The string representation of this <see cref="StandardSpecular"/>.
        /// </summary>
        public override string ToString()
        {
            return $"SpecularColor = {SpecularColor}, Smoothness = {Smoothness}";
        }
    }

    /// <summary>
    /// A configuration for the appearance of a mesh surface under scene lighting.
    /// </summary>
    /// <seealso cref="UIBlock.Surface"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Surface : IEquatable<Surface>
    {
        [SerializeField, InternalType_22]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Color specularColor;
        
        [SerializeField, InternalType_22]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float param1;
        
        [SerializeField, InternalType_22]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float param2;
        /// <summary>
        /// The lighting model to use. See <see cref="Nova.LightingModel"/> for more info.
        /// </summary>
        [SerializeField]
        public LightingModel LightingModel;
        /// <summary>
        /// Specifies if the surface should cast shadows.
        /// </summary>
        [SerializeField]
        public ShadowCastingMode ShadowCastingMode;
        /// <summary>
        /// Specifies whether or not the surface should receive shadows. <br/>
        /// NOTE: Only opaque surfaces can receive shadows.
        /// </summary>
        [SerializeField]
        public bool ReceiveShadows;

        #region 
        /// <summary>
        /// <c>get</c>: Returns the parameters if using <see cref="LightingModel.BlinnPhong"/>, otherwise default.<br/>
        /// <c>set</c>: Sets <see cref="LightingModel"/> to <see cref="LightingModel.BlinnPhong"/> and sets the model parameters based on the 
        /// input value.
        /// </summary>
        public BlinnPhong BlinnPhong
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => LightingModel == LightingModel.BlinnPhong ? new BlinnPhong(param1, param2) : default;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                param1 = value.Specular;
                param2 = value.Gloss;
                LightingModel = LightingModel.BlinnPhong;
            }
        }

        /// <summary>
        /// <c>get</c>: Returns the parameters if using <see cref="LightingModel.Standard"/>, otherwise default.<para/>
        /// <c>set</c>: Sets <see cref="LightingModel"/> to <see cref="LightingModel.Standard"/> and sets the model parameters based on the 
        /// input value.
        /// </summary>
        public Standard Standard
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => LightingModel == LightingModel.Standard ? new Standard(param1, param2) : default;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                param1 = value.Smoothness;
                param2 = value.Metallic;
                LightingModel = LightingModel.Standard;
            }
        }

        /// <summary>
        /// <c>get</c>: Returns the parameters if using <see cref="LightingModel.StandardSpecular"/>, otherwise default.<para/>
        /// <c>set</c>: Sets <see cref="LightingModel"/> to <see cref="LightingModel.StandardSpecular"/> and sets the model parameters based on the 
        /// input value.
        /// </summary>
        public StandardSpecular StandardSpecular
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => LightingModel == LightingModel.StandardSpecular ? new StandardSpecular(specularColor, param1) : default;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                specularColor = value.SpecularColor;
                param1 = value.Smoothness;
                LightingModel = LightingModel.StandardSpecular;
            }
        }
        #endregion

        public static bool operator ==(Surface lhs, Surface rhs)
        {
            return
                lhs.specularColor.Equals(rhs.specularColor) &&
                lhs.param1.Equals(rhs.param1) &&
                lhs.param2.Equals(rhs.param2) &&
                lhs.LightingModel == rhs.LightingModel &&
                lhs.ShadowCastingMode == rhs.ShadowCastingMode &&
                lhs.ReceiveShadows.Equals(rhs.ReceiveShadows);
        }
        public static bool operator !=(Surface lhs, Surface rhs) => !(rhs == lhs);

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + specularColor.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + param1.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + param2.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + LightingModel.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + ShadowCastingMode.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + ReceiveShadows.GetHashCode();
            return InternalVar_1;
        }

        public override bool Equals(object other)
        {
            if (other is Surface asType)
            {
                return this == asType;
            }

            return false;
        }

        /// <summary>
        /// The string representation of this <see cref="Surface"/>.
        /// </summary>
        public override string ToString()
        {
            switch (LightingModel)
            {
                case LightingModel.Lambert:
                    return "Matte";
                case LightingModel.BlinnPhong:
                    return BlinnPhong.ToString();
                case LightingModel.Standard:
                    return Standard.ToString();
                case LightingModel.StandardSpecular:
                    return StandardSpecular.ToString();
                default:
                    return "Unlit";
            }
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="Surface"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(Surface other) => this == other;

        #region 

        /// <summary>
        /// Create a new, unlit surface.
        /// </summary>
        /// <returns>A new <see cref="Surface"/> which won't react to scene lighting.</returns>
        public static Surface Unlit()
        {
            Surface InternalVar_1 = InternalField_49;

            InternalVar_1.ShadowCastingMode = ShadowCastingMode.Off;
            InternalVar_1.ReceiveShadows = false;

            return InternalVar_1;
        }

        /// <summary>
        /// Create a new, matte surface effect.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.Lambert"/> lighting model.</remarks>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> effect without any metallic, gloss, or specular characteristics.</returns>
        public static Surface Matte(ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            Surface InternalVar_1 = InternalField_50;

            InternalVar_1.ShadowCastingMode = shadowCasting;
            InternalVar_1.ReceiveShadows = receiveShadows;

            return InternalVar_1;
        }

        /// <summary>
        /// Create a new, plasticky-looking surface.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.BlinnPhong"/> lighting model.</remarks>
        /// <param name="specular">The <see cref="BlinnPhong.Specular"/> parameter.</param>
        /// <param name="gloss">The <see cref="BlinnPhong.Gloss"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a slightly glossy, non-metallic effect.</returns>
        public static Surface Plastic(float specular = 0.5f, float gloss = 0.5f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            return new Surface()
            {
                LightingModel = LightingModel.BlinnPhong,
                param1 = specular,
                param2 = gloss,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
            };
        }


        /// <summary>
        /// Create a new, glossy surface.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.Standard"/> lighting model.</remarks>
        /// <param name="smoothness">The <see cref="Standard.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a very glossy, non-metallic effect.</returns>
        public static Surface Glossy(float smoothness = 1f, float metallic = 0f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            return new Surface()
            {
                LightingModel = LightingModel.Standard,
                param1 = smoothness,
                param2 = metallic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = Color.white,
            };
        }

        /// <summary>
        /// Create a new, glossy surface with a given specular reflection color.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.StandardSpecular"/> lighting model.</remarks>
        /// <param name="reflectionColor">The hue of the surface's specular reflections.</param>
        /// <param name="smoothness">The <see cref="StandardSpecular.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a very glossy, non-metallic effect.</returns>
        public static Surface Glossy(Color reflectionColor, float smoothness = 1f, float metallic = 0f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            Color.RGBToHSV(reflectionColor, out float InternalVar_1, out float InternalVar_2, out float _);
            reflectionColor = Color.HSVToRGB(InternalVar_1, InternalVar_2, metallic);

            return new Surface()
            {
                LightingModel = LightingModel.StandardSpecular,
                param1 = smoothness,
                param2 = metallic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = reflectionColor,
            };
        }

        /// <summary>
        /// Create a new, soft rubber surface.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.Standard"/> lighting model.</remarks>
        /// <param name="smoothness">The <see cref="Standard.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a mostly matte, non-metallic effect.</returns>
        public static Surface Rubber(float smoothness = .4f, float metallic = 0f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            return new Surface()
            {
                LightingModel = LightingModel.Standard,
                param1 = smoothness,
                param2 = metallic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = Color.white,
            };
        }

        /// <summary>
        /// Create a new, soft rubber surface with a given specular reflection color.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.StandardSpecular"/> lighting model.</remarks>
        /// <param name="reflectionColor">The hue of the surface's specular reflections.</param>
        /// <param name="smoothness">The <see cref="StandardSpecular.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a mostly matte, non-metallic effect.</returns>
        public static Surface Rubber(Color reflectionColor, float smoothness = .4f, float metallic = 0f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            Color.RGBToHSV(reflectionColor, out float InternalVar_1, out float InternalVar_2, out float _);
            reflectionColor = Color.HSVToRGB(InternalVar_1, InternalVar_2, metallic);

            return new Surface()
            {
                LightingModel = LightingModel.StandardSpecular,
                param1 = smoothness,
                param2 = metallic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = reflectionColor,
            };
        }

        /// <summary>
        /// Create a new, glossy metal surface.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.Standard"/> lighting model.</remarks>
        /// <param name="smoothness">The <see cref="StandardSpecular.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a glossy, metallic effect.</returns>
        public static Surface PolishedMetal(float smoothness = .9f, float metallic = 1f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            return new Surface()
            {
                LightingModel = LightingModel.Standard,
                param1 = smoothness,
                param2 = metallic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = Color.white,
            };
        }

        /// <summary>
        /// Create a new, glossy metal surface with a given specular reflection color.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.StandardSpecular"/> lighting model.</remarks>
        /// <param name="reflectionColor">The hue of the surface's specular reflections.</param>
        /// <param name="smoothness">The <see cref="StandardSpecular.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a glossy, metallic effect.</returns>
        public static Surface PolishedMetal(Color reflectionColor, float smoothness = .9f, float metallic = 1f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            Color.RGBToHSV(reflectionColor, out float InternalVar_1, out float InternalVar_2, out float _);
            reflectionColor = Color.HSVToRGB(InternalVar_1, InternalVar_2, metallic);

            return new Surface()
            {
                LightingModel = LightingModel.StandardSpecular,
                param1 = smoothness,
                param2 = metallic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = reflectionColor,
            };
        }

        /// <summary>
        /// Create a new, brushed metal surface.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.Standard"/> lighting model.</remarks>
        /// <param name="reflectionColor">The hue of the surface's specular reflections.</param>
        /// <param name="smoothness">The <see cref="StandardSpecular.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a matte, metallic effect.</returns>
        public static Surface BrushedMetal(float smoothness = .4f, float metalic = 1f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            return new Surface()
            {
                LightingModel = LightingModel.Standard,
                param1 = smoothness,
                param2 = metalic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = Color.white,
            };
        }

        /// <summary>
        /// Create a new, brushed metal surface with a given specular reflection color.
        /// </summary>
        /// <remarks>Uses the <see cref="LightingModel.StandardSpecular"/> lighting model.</remarks>
        /// <param name="reflectionColor">The hue of the surface's specular reflections.</param>
        /// <param name="smoothness">The <see cref="StandardSpecular.Smoothness"/> parameter.</param>
        /// <param name="metallic">The <see cref="Standard.Metallic"/> parameter.</param>
        /// <param name="shadowCasting">Value for <see cref="ShadowCastingMode"/>.</param>
        /// <param name="receiveShadows">Value for <see cref="ReceiveShadows"/>.</param>
        /// <returns>A new <see cref="Surface"/> with a matte, metallic effect.</returns>
        public static Surface BrushedMetal(Color reflectionColor, float smoothness = .4f, float metallic = 1f, ShadowCastingMode shadowCasting = ShadowCastingMode.Off, bool receiveShadows = false)
        {
            Color.RGBToHSV(reflectionColor, out float InternalVar_1, out float InternalVar_2, out float _);
            reflectionColor = Color.HSVToRGB(InternalVar_1, InternalVar_2, metallic);

            return new Surface()
            {
                LightingModel = LightingModel.StandardSpecular,
                param1 = smoothness,
                param2 = metallic,
                ShadowCastingMode = shadowCasting,
                ReceiveShadows = receiveShadows,
                specularColor = reflectionColor,
            };
        }
        #endregion

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                internal static readonly Surface InternalField_49 = new Surface()
        {
            LightingModel = LightingModel.Unlit,
            specularColor = Color.white,
            param1 = .5f,
            param2 = .5f,
            ShadowCastingMode = ShadowCastingMode.TwoSided,
            ReceiveShadows = true,
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static readonly Surface InternalField_50 = new Surface()
        {
            LightingModel = LightingModel.Lambert,
            specularColor = Color.white,
            param1 = .5f,
            param2 = .5f,
            ShadowCastingMode = ShadowCastingMode.TwoSided,
            ReceiveShadows = true,
        };
    }
}
