using System;

namespace DynamsoftCamera
{

    public enum DcsViewEnum
    {
        Videoview = 0x1000,
        Imagegalleryview,
        Editorview
    }
    public enum DcsLogLevelEnum
    {
        Off = 0,   //colse the log output
        Error, //The Error level    
        Debug, //The debug level
    }

    public enum DcsModeEnum
    {
        Image = 0x0001,//Image mode
        Document//document mode
    }
    //camera Position
    public enum DcsCameraPositionEnum
    {
        Back = 0x0010,
        Front,
    }
    //flash mode
    public enum DcsFlashModeEnum
    {
        On = 0x0100,
        Off,
        Auto,
        Torch
    }

    public enum DcsImageGalleryViewModeEnum
    {
        Multiple= 0x0001,
        Single
    }


    public enum DcsPDFQuality
    {
        QualityLow,
        QualityMedium,
        QualityHigh,
    }

    public enum DcsUploadMethodEnum
    {
        Post = 0x0001,
    }
    public enum DcsDataFormatEnum
    {
        Binary = 0x0010,
        Base64
    }
}

