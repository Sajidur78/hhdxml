using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HhdXml
{
    public enum GIModeTypes : byte
    {
        GIMODE_NORMAL = 0,
        GIMODE_ONLY = 1,
        GIMODE_NONE = 2,
        GIMODE_SHADOW = 3,
        GIMODE_SEPARATED = 4,
    };

    public enum LightFieldModeTypes : byte
    {
        LFMODE_NORMAL = 0,
        LFMODE_ONLY = 1,
        LFMODE_NONE = 2,
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxSceneConfig
    {
        public float Gammatvwiiu;
        public float Gammadrcwiiu;
        public bool Fixedldr;
        public GIModeTypes Gimode;
        public LightFieldModeTypes Lightfieldmode;
        public bool Drawlightfieldsamplingpoints;
        public bool Updatelightfieldeachframe;
        public bool Drawlightfieldregion;
        public int Screenshotlargescale;
        public bool Drawfxcolgeom;
        public bool Drawfxcolname;
        public bool Drawlocallightsphere;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxCullingSettings
    {
        public float Rangedefault;
        public float Rangenear;
        public float Rangemiddle;
        public float Rangefar;
    }

    public enum PeepingPlayerType : byte
    {
        TYPE_DEFAULT = 0,
        TYPE_EDGE = 1,
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxSceneSettings
    {
        public float Skyintensityscale;
        public float Skyfollowupratioy;
        public bool Pseudofogenable;
        public bool Pseudofogwithoutfar;
        public bool Pseudodof;
        public bool Deepblurenable;
        public bool Noblurenable;
        public float Blurscale;
        public bool Peepingplayerenable;
        public float Occcheckedplayertime;
        public PeepingPlayerType Peepingplayertype;
        public bool Clearfirstsurface;
        public bool Usemanualzprepass;
        public bool Usecaptureframebuffercolor;
        public bool Usecaptureframebufferdepth;
        public bool Playerdrawoverlay;
    }

    public enum EyeLightMode : byte
    {
        LIGHTMODE_DIR = 0,
        LIGHTMODE_POINT = 1,
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxLightSettings
    {
        public bool Globallightenable;
        public bool Amblightenable;
        public bool Alllocallightenable;
        public bool Eyelightenable;
        public EyeLightMode Eyelightmode;
        public Vector3 Eyelightdiffuse;
        public Vector3 Eyelightspecular;
        public float Eyelightrangestart;
        public float Eyelightrangeend;
    }

    public enum SaturationScalingType : byte
    {
        SATURATION_KEEPING_LUMINANCE = 0,
        SATURATION_KEEPING_BRIGHTNESS = 1,
        SATURATION_NONE = 2,
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxLightFieldSettings
    {
        public bool Ignoredata;
        public byte Defaultupdateinterval;
        public Vector3 Offsetcolorup;
        public Vector3 Offsetcolordown;
        public SaturationScalingType Saturationscalingtype;
        public float Saturationscalingrate;
        public float Luminancescalingrate;
        public bool Disablefinaladjustcolor;
        public float Luminancemin;
        public float Luminancemax;
        public float Luminancemidium;
        public float Intensitythreshold;
        public float Intensitybias;
        public float Defaultinterruption;
        public Vector3 Defaultcolorup;
        public Vector3 Defaultcolordown;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxLightScatteringSettings
    {
        public bool Enable;
        public Vector3 Color;
        public float Depthscale;
        public float Inscatteringscale;
        public float Rayleigh;
        public float Mie;
        public float G;
        public float Znear;
        public float Zfar;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxHdrSettings
    {
        public bool Enable;
        public bool Adaptationenable;
        public float Adaptationratio;
        public float Middlegray;
        public float Luminancelow;
        public float Luminancehigh;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxGlareSettings
    {
        public bool Enable;
        public float Brightpassthreshold;
        public float Brightpassinvscale;
        public float Persistent;
        public float Bloomscale;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxDofSettings
    {
        public bool Enable;
        public bool Ignoresky;
        public float Focus;
        public float Znear;
        public float Zfar;
        public float Focusrange;
    }

    public enum TimeType : byte
    {
        TIME_NONE = 0,
        TIME_MORNING = 1,
        TIME_DAY = 2,
        TIME_EVENING = 3,
        TIME_NIGHT = 4,
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxHourSettings
    {
        public float Middlegray;
        public Vector3 Basecolor;
        public Vector3 Light;
        public float Skyintensity;
        public Vector3 Sky;
        public Vector3 Ambient;
        public Vector3 Lightscattering;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxTimeChangeSettings
    {
        public bool Enable;
        public bool Ignoresky;
        public byte Timedebugindex;
        public float Morning;
        public float Day;
        public float Evening;
        public float Night;

        public FxHourSettings HourParam1;
        public FxHourSettings HourParam2;
        public FxHourSettings HourParam3;
        public FxHourSettings HourParam4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxInShadowShadowScaleSettings
    {
        public float Shadowscalex;
        public float Shadowscaley;
        public float Shadowscalelightfieldy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxOnSceneShadowScaleSettings
    {
        public float Shadowscalez;
        public float Shadowscalew;
        public float Shadowscalelightfieldw;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxShadowScale
    {
        public FxInShadowShadowScaleSettings Shadowscaleinshadow;
        public FxOnSceneShadowScaleSettings Shadowscaleonscene;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxGrassSettings
    {
        public bool Grassishide;
        public float Grassheightmin;
        public float Grassheight;
        public float Grasswidth;
        public float Grassfar;
        public float Grassfarend;
        public float Grasswindaxis;
        public float Grasswindspeed;
        public float Grasswindcycle;
        public float Grasswindstrength;
        public uint Grassdupcount;
        public float Grassduprange;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxStageDistortion
    {
        public bool Distortionisuse;
        public float Distortionspeed;
        public float Distortionpower;
        public float Distortiondensity;
        public float Distortiondepthdensity;
        public float Distortionpowerbloom;
        public float Distortionpowerdepth;
        public float Distortionpowerfront;
        public float Distortiondensityfront;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxStencilShadow
    {
        public bool Enable;
        public Vector3 Shadowcolor;
        public float Shadowalpha;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxEffectSettings
    {
        public float Lightscale;
        public float Shadowscale;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxSceneCasinoLight
    {
        public bool Isusecasinolight;
        public Vector3 Casinolightaabbmin;
        public Vector3 Casinolightaabbmax;
        public float Casinolightmoveratio;
        public float Casinolightstrengthmax;
        public float Casinolightradmin;
        public float Casinolightradmax;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxParameter
    {
        public FxCullingSettings Culling;
        public FxSceneSettings Scene;
        public FxLightSettings Light;
        public FxLightFieldSettings Lightfield;
        public FxLightScatteringSettings Olsnear;
        public bool Separateolslayer;
        public FxLightScatteringSettings Olsfar;
        public FxHdrSettings Hdr;
        public FxGlareSettings Glare;
        public FxDofSettings Dof;
        public FxTimeChangeSettings Timechange;
        public FxShadowScale Shadowscale;
        public FxGrassSettings Grasssetting;
        public FxStageDistortion Stagedistortion;
        public FxStencilShadow Stencilshadow;
        public FxEffectSettings Effect;
        public FxSceneCasinoLight Casinolight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FxSceneData
    {
        public FxSceneConfig Config;

        public FxParameter Item1;
        public FxParameter Item2;
        public FxParameter Item3;
        public FxParameter Item4;
    }
}
