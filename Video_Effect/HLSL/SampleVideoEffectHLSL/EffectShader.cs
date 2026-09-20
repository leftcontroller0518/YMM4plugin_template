using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace SampleVideoEffectHLSL;

/// <summary>
/// HLSLシェーダーエフェクトのラッパークラス
/// </summary>
public class EffectShader : D2D1CustomShaderEffectBase
{
    private static readonly byte[] ShaderBytes;

    static EffectShader()
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("SampleVideoEffectHLSL.Shaders.Effect.cso")
            ?? throw new InvalidOperationException("Shaders/Effect.cso が埋め込みリソースに見つかりません。");
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        ShaderBytes = ms.ToArray();
    }

    public EffectShader(IGraphicsDevicesAndContext devices) : base(Create<EffectImpl>(devices))
    {
    }

    /// <summary>
    /// シェーダーの定数バッファパラメータ (反転率)
    /// </summary>
    public float InvertAmount
    {
        get => GetFloatValue(0);
        set => SetValue(0, value);
    }

    /// <summary>
    /// Direct2D1 カスタムエフェクト実装
    /// </summary>
    [CustomEffect(1, "SampleHLSLEffect", "Sample HLSL Invert Effect", "Custom", "Template")]
    public class EffectImpl : D2D1CustomShaderEffectImplBase<EffectImpl>
    {
        private float invertAmount = 1.0f;
        private ID2D1DrawInfo? drawInfo;

        public EffectImpl() : base(ShaderBytes)
        {
        }

        [CustomEffectProperty(PropertyType.Float, 0)]
        public float InvertAmount
        {
            get => invertAmount;
            set
            {
                invertAmount = value;
                UpdateConstants();
            }
        }

        public override void SetDrawInfo(ID2D1DrawInfo drawInfo)
        {
            base.SetDrawInfo(drawInfo);
            this.drawInfo = drawInfo;
            UpdateConstants();
        }

        protected override void UpdateConstants()
        {
            if (drawInfo == null) return;
            var constants = new ShaderConstants
            {
                InvertAmount = invertAmount,
                Padding = Vector3.Zero
            };
            drawInfo.SetPixelShaderConstantBuffer(in constants);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ShaderConstants
        {
            public float InvertAmount;
            public Vector3 Padding;
        }
    }
}
