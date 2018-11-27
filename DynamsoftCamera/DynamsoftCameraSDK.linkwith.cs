using System;
using ObjCRuntime;

[assembly: LinkWith ("DynamsoftCameraSDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator, ForceLoad = true, LinkerFlags = "-lc++.1")]
