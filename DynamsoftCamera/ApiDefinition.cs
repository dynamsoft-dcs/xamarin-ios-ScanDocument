using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace DynamsoftCamera
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
    //
    //[Static]
    ////[Verify(ConstantsInterfaceAssociation)]
    //partial interface Constants
    //{

    //}

    //@interface DcsView : UIView
    [BaseType(typeof(UIView))]
    interface DcsView
    {
        // @property(nonatomic, assign) DcsViewEnum currentView;
        [Export("currentView")]
        DcsViewEnum CurrentView { get; set; }

        // @property(nonatomic, strong, readonly) DcsUIVideoView* videoView;
        [Export("videoView")]
        DcsUIVideoView VideoView { get; }

        //@property(nonatomic, strong, readonly) DcsUIImageGalleryView* imageGalleryView;
        [Export("imageGalleryView")]
        DcsUIImageGalleryView ImageGalleryView { get; }

        //@property(nonatomic, strong, readonly) DcsUIDocumentEditorView* documentEditorView;
        [Export("documentEditorView")]
        DcsUIDocumentEditorView DocumentEditorView { get; }

        //@property(nonatomic, strong, readonly) DcsUIImageEditorView* imageEditorView;
        [Export("imageEditorView")]
        DcsUIImageEditorView ImageEditorView { get; }

        //@property(nonatomic, strong,readonly) DcsIo* io;
        [Export("io")]
         DcsIo Io { get; }

        //@property(nonatomic, strong,readonly) DcsBuffer* buffer;
        [Export("buffer")]
        DcsBuffer Buffer { get; }

        //+ (void) setLogLevel:(DcsLogLevelEnum) logLevel;
        [Static, Export("setLogLevel:")]
        void SetLogLevel(DcsLogLevelEnum logLevel);

        [Export("initWithFrame:")]
        IntPtr Constructor(CoreGraphics.CGRect frame);

    }

    /// <summary>
    /// UIVideoView
    /// </summary>
    //@protocol DcsUIVideoViewDelegate
    [BaseType(typeof(NSObject))]
    [Model][Protocol]   
    interface DcsUIVideoViewDelegate
    {
        //- (void) onDocumentDetected:(id) sender document:(DcsDocument*) document;
        [Export("onDocumentDetected:document:")]
        void OnDocumentDetected(NSObject sender, DcsDocument document);

        //- (void) onCancelTapped:(id) sender;
        [Export("onCancelTapped:")]
        void OnCancelTapped(NSObject sender);

        //- (void) onCaptureTapped:(id) sender;
        [Export("onCaptureTapped:")]
        void OnCaptureTapped(NSObject sender);

        //- (BOOL) onPreCapture:(id) sender;
        [Export("onPreCapture:")]
        Boolean OnPreCapture(NSObject sender);

        //- (void) onPostCapture:(id) sender image:(DcsImage*) image;
        [Export("onPostCapture:image:")]
        void OnPostCapture(NSObject sender, DcsImage image);

        //- (void) onCaptureFailure:(id) sender exception:(DcsException*) exception;
        [Export("onCaptureFailure:exception:")]
        void OnCaptureFailure(NSObject sender, DcsException exception);
    }


    //@interface DcsUIVideoView : UIView
    [BaseType(typeof(UIView))]
    interface DcsUIVideoView
    {
        //- (instancetype)initWithFrame:(CGRect)frame withClass:(id)targetClass;
        [Export("initWithFrame:targetClass:")]
        IntPtr Constructor(CoreGraphics.CGRect frame, NSObject targetClass);
      
        //delegate
       // @property(nonatomic, weak) id<DcsUIVideoViewDelegate> delegate;
        [Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        [Wrap("WeakDelegate")]
        DcsUIVideoViewDelegate Delegate { get; set; }

        //@property(nonatomic, assign) DcsViewEnum nextViewAfterCancel;
        [Export("nextViewAfterCancel")]
        DcsViewEnum NextViewAfterCancel { get; set; }


        //@property(nonatomic, assign) DcsViewEnum nextViewAfterCapture;
        [Export("nextViewAfterCapture")]
        DcsViewEnum NextViewAfterCapture { get; set; }

        //@property(nonatomic, assign) DcsModeEnum mode;
        [Export("mode")]
        DcsModeEnum Mode { get; set; }

        //@property(nonatomic, assign) DcsCameraPositionEnum cameraPosition;
        [Export("cameraPosition")]
        DcsCameraPositionEnum CameraPosition { get; set; }

        //@property(nonatomic, assign) DcsFlashModeEnum flashMode;
        [Export("flashMode")]
        DcsFlashModeEnum FlashMode { get; set; }

        //@property(nonatomic, strong) UIColor* documentBoundaryColor;
        [Export("documentBoundaryColor")]
        UIColor DocumentBoundaryColor { get; set; }


        //@property(nonatomic, assign) NSInteger documentBoundaryThickness;
        [Export("documentBoundaryThickness")]
        nint DocumentBoundaryThickness { get; set; }

        //@property(nonatomic, assign) BOOL showFlashToolItem;
        [Export("showFlashToolItem")]
        Boolean showFlashToolItem { get; set; }


        // @property(nonatomic, assign) BOOL showCaptureToolItem;
        [Export("showCaptureToolItem")]
        Boolean ShowCaptureToolItem { get; set; }

        //@property(nonatomic, assign) BOOL showCancelToolItem;
        [Export("showCancelToolItem")]
        Boolean ShowCancelToolItem { get; set; }

        //@property(nonatomic, strong) NSString* cancelText;
        [Export("cancelText")]
        String CancelText { get; set; }

        //@property(nonatomic, strong) NSString* flashOnText;
        [Export("flashOnText")]
        String FlashOnText { get; set; }
        
        //@property(nonatomic, strong) NSString* flashOffText;
        [Export("flashOffText")]
        String FlashOffText { get; set; }

        //@property(nonatomic, strong) NSString* flashAutoText;
        [Export("flashAutoText")]
        String FlashAutoText { get; set; }

        //@property(nonatomic, strong) NSString* flashTorchText;
        [Export("flashTorchText")]
        String FlashTorchText { get; set; }

        //@property(nonatomic, strong)  UIImage* flashOnIcon;
        [Export("flashOnIcon")]
        UIImage FlashOnIcon { get; set; }

       
        //@property(nonatomic, strong)  UIImage* flashOffIcon;
        [Export("flashOffIcon")]
        UIImage FlashOffIcon { get; set; }

        // @property(nonatomic, strong)  UIImage* flashAutoIcon;
        [Export("flashAutoIcon")]
        UIImage FlashAutoIcon { get; set; }
       
        //@property(nonatomic, strong)  UIImage* flashTorchIcon;
        [Export("flashTorchIcon")]
        UIImage FlashTorchIcon { get; set; }

        //@property(nonatomic, strong)  UIImage* captureIcon;
        [Export("captureIcon")]
        UIImage CaptureIcon { get; set; }
        
        //@property(nonatomic, assign) CGFloat zoomIn;
        [Export("zoomIn")]
        float ZoomIn { get; set; }

        //- (void) preview;
        [Export("preview")]
        void Preview();

        //- (void) stopPreview;
        [Export("stopPreview")]
        void StopPreview();

        //- (void) captureImage;
        [Export("captureImage")]
        void CaptureImage();

        //- (void) captureDocument;
        [Export("captureDocument")]
        void CaptureDocument();

        //@property(nonatomic, assign) BOOL ifAllowDocumentCaptureWhenNotDetected;
        [Export("ifAllowDocumentCaptureWhenNotDetected")]
        Boolean IfAllowDocumentCaptureWhenNotDetected { get;set; }

    }

    /// <summary>
    /// UIImageGallerayView
    /// </summary>
    [BaseType(typeof(NSObject))]
    [Model][Protocol]
    interface DcsUIImageGalleryViewDelegate
    {
        //- (void) onSingleTap: (id) sender index:(NSInteger) index;
        [Export("onSingleTap:index:")]
        void OnSingleTap(NSObject sender,nint index);

        //- (void) onSelectChanged:(id) sender selectedIndices:(NSArray*) indices;
        [Export("onSelectChanged:indices:")]
        void OnSelectChanged(NSObject sender, NSObject[] indices);
        //- (void) onLongPress: (id) sender index: (NSInteger) index;
        [Export("onLongPress:index:")]
        void OnLongPress(NSObject sender, nint index);
    }
 
    //@interface DcsUIImageGalleryView : UIView
    [BaseType(typeof(UIView))]
    interface DcsUIImageGalleryView
    {
        

        //@property(nonatomic, weak) id<DcsUIImageGalleryViewDelegate> delegate;
        [Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        [Wrap("WeakDelegate")]
        DcsUIImageGalleryViewDelegate Delegate { get; set; }

        //@property(nonatomic, assign) DcsImageGalleryViewModeEnum imageGalleryViewmode;
        [Export("imageGalleryViewmode")]
        DcsImageGalleryViewModeEnum ImageGalleryViewmode { get; set; }

        //- (void) enterManualSortMode;
        [Export("enterManualSortMode")]
        void EnterManualSortMode();

        //- (void) enterNormalMode;
        [Export("enterNormalMode")]
        void EnterNormalMode();

        //- (void) enterSelectMode;
        [Export("enterSelectMode")]
        void EnterSelectMode();

        //@property(nonatomic, strong) NSArray* selectedIndices;
        [Export("selectedIndices")]
        NSArray SelectedIndices { get; set; }
        
        //- (instancetype) initWithFrame:(CGRect) frame withClass:(id) targetClass;
        [Export("initWithFrame:targetClass:")]
        IntPtr Constructor(CoreGraphics.CGRect frame, NSObject targetClass);
    }


    /// <summary>
    /// DcsUIImageEditorView.h    
    /// </summary>
    [BaseType(typeof(NSObject))]
    [Model][Protocol]
    interface DcsUIImageEditorViewDelegate
    {
        //- (void)onCancelTapped:(id)sender;
        [Export("onCancelTapped:")]
        void OnCancelTapped(NSObject sender);

        //- (void) onOkTapped:(id) sender exception:(DcsException*) exception;
        [Export("onOkTapped:exception:")]
        void OnOkTapped(NSObject sender, DcsException exception);        
    }

    //@interface DcsUIImageEditorView : UIView
    [BaseType(typeof(UIView))]
    interface DcsUIImageEditorView
    {
        //- (instancetype) initWithFrame:(CGRect) frame withClass:(id) targetClass;
        [Export("initWithFrame:targetClass:")]
        IntPtr Constructor(CoreGraphics.CGRect frame, NSObject targetClass);

        //@property(nonatomic, weak) id<DcsUIImageEditorViewDelegate> delegate;
        [Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        [Wrap("WeakDelegate")]
        DcsUIImageEditorViewDelegate Delegate { get; set; }

        // @property(nonatomic, assign) DcsViewEnum nextViewAfterCancel;
        [Export("nextViewAfterCancel")]
        DcsViewEnum NextViewAfterCancel { get; set; }

        // @property(nonatomic, assign) DcsViewEnum nextViewAfterOK;
        [Export("nextViewAfterOK")]
        DcsViewEnum NextViewAfterOK { get; set; }

        // @property(nonatomic, assign) BOOL showRotateLeftToolItem;
        [Export("showRotateLeftToolItem")]
        Boolean ShowRotateLeftToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showRotateRightToolItem;
        [Export("showRotateRightToolItem")]
        Boolean ShowRotateRightToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showFlipToolItem;
        [Export("showFlipToolItem")]
        Boolean ShowFlipToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showMirrorToolItem;
        [Export("showMirrorToolItem")]
        Boolean ShowMirrorToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showBrightnessToolItem;
        [Export("showBrightnessToolItem")]
        Boolean ShowBrightnessToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showContrastToolItem;
        [Export("showContrastToolItem")]
        Boolean showContrastToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showCropToolItem;
        [Export("showCropToolItem")]
        Boolean ShowCropToolItem { get; set; }

        // @property(nonatomic, assign) UIImage* rotateIcon;
        [Export("rotateIcon")]
        UIImage RotateIcon { get; set; }

        // @property(nonatomic, assign) UIImage* rotateLeftIcon;
        [Export("rotateLeftIcon")]
        UIImage RotateLeftIcon { get; set; }

        // @property(nonatomic, assign) UIImage* rotateRightIcon;
        [Export("rotateRightIcon")]
        UIImage RotateRightIcon { get; set; }

        // @property(nonatomic, assign) UIImage* flipIcon;
        [Export("flipIcon")]
        UIImage FlipIcon { get; set; }

        // @property(nonatomic, assign) UIImage* mirrorIcon;
        [Export("mirrorIcon")]
        UIImage MirrorIcon { get; set; }

        // @property(nonatomic, assign) UIImage* cropIcon;
        [Export("cropIcon")]
        UIImage CropIcon { get; set; }


        // @property(nonatomic, assign) UIImage* brightnessContrastIcon;
        [Export("brightnessContrastIcon")]
        UIImage BrightnessContrastIcon { get; set; }

        // @property(nonatomic, assign) NSString* brightnessText;
        [Export("brightnessText")]
        String BrightnessText { get; set; }

        // @property(nonatomic, assign) NSString* contrastText;
        [Export("contrastText")]
        String ContrastText { get; set; }

        // @property(nonatomic, assign) NSString* cancelText;
        [Export("cancelText")]
        String CancelText { get; set; }

        // @property(nonatomic, assign) NSString* okText;
        [Export("okText")]
        String OkText { get; set; }

        // @property(nonatomic, assign) UIImage* cropCancelIcon;
        [Export("cropCancelIcon")]
        UIImage CropCancelIcon { get; set; }

        // @property(nonatomic, assign) UIImage* cropOKIcon;
        [Export("cropOKIcon")]
        UIImage cropOKIcon { get; set; }

        // - (void) adjustContrast:(NSInteger) contrast;
        [Export("adjustContrast:")]
        void AdjustContrast(nint contrast);

        // - (void) adjustBrightness:(NSInteger) brightness;
        [Export("adjustBrightness:")]
        void AdjustBrightness(nint brightness);

        // - (void) rotateLeft;
        [Export("rotateLeft")]
        void RotateLeft();

        // - (void) rotateRight;
        [Export("rotateRight")]
        void RotateRight();

        // - (void) flip;
        [Export("flip")]
        void Flip();

        // - (void) mirror;
        [Export("mirror")]
        void Mirror();

        //- (void) cut:(NSInteger) x1 top:(NSInteger) y1 right:(NSInteger) x2 bottom:(NSInteger) y2;
        [Export("cut:y1:x2:y2:")]
        void Mirror(nint x1,nint y1,nint x2,nint y2);

        //- (void) crop:(NSInteger) x1 top:(NSInteger) y1 right:(NSInteger) x2 bottom:(NSInteger) y2;
        [Export("crop:y1:x2:y2:")]
        void Crop(nint x1, nint y1, nint x2, nint y2);

        //- (void) save;
        [Export("save")]
        void Save();

        //- (void) discard;
        [Export("discard")]
        void Discard();
    }


    /// <summary>
    /// DcsUIDocumentEditorView.h    
    /// </summary>
    [BaseType(typeof(NSObject))]
    [Model]
    [Protocol]
    interface DcsUIDocumentEditorViewDelegate
    {
        //- (void)onCancelTapped:(id)sender;
        [Export("onCancelTapped:")]
        void OnCancelTapped(NSObject sender);

        //- (void) onOkTapped:(id) sender exception:(DcsException*) exception;
        [Export("onOkTapped:exception:")]
        void OnOkTapped(NSObject sender, DcsException exception);
    }

    //@interface DcsUIImageEditorView : UIView
    [BaseType(typeof(UIView))]
    interface DcsUIDocumentEditorView
    {
        //- (instancetype) initWithFrame:(CGRect) frame withClass:(id) targetClass;
        [Export("initWithFrame:targetClass:")]
        IntPtr Constructor(CoreGraphics.CGRect frame, NSObject targetClass);

        //@property(nonatomic, weak) id<DcsUIImageEditorViewDelegate> delegate;
        [Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        [Wrap("WeakDelegate")]
        DcsUIDocumentEditorViewDelegate Delegate { get; set; }

        // @property(nonatomic, assign) DcsViewEnum nextViewAfterCancel;
        [Export("nextViewAfterCancel")]
        DcsViewEnum NextViewAfterCancel { get; set; }

        // @property(nonatomic, assign) DcsViewEnum nextViewAfterOK;
        [Export("nextViewAfterOK")]
        DcsViewEnum NextViewAfterOK { get; set; }

        //@property(nonatomic, strong) UIColor *documentBoundaryColor;
        [Export("documentBoundaryColor")]
        UIColor DocumentBoundaryColor { get; set; }

        //@property(nonatomic, assign) NSInteger documentBoundaryThickness;
        [Export("documentBoundaryThickness")]
        nint DocumentBoundaryThickness { get; set; }

        //@property(nonatomic,strong) NSString * brightnessText;
        [Export("brightnessText")]
        String BrightnessText { get; set; }

        //@property(nonatomic,strong) NSString * contrastText;
        [Export("contrastText")]
        String ContrastText { get; set; }

        //@property(nonatomic,strong) NSString * colorText;
        [Export("colorText")]
        String ColorText { get; set; }

        //@property(nonatomic,strong) NSString * greyText;
        [Export("greyText")]
        String GreyText { get; set; }

        //@property(nonatomic,strong) NSString * blackWhiteText;
        [Export("blackWhiteText")]
        String BlackWhiteText { get; set; }

        //@property(nonatomic,strong) NSString * cancelText;
        [Export("cancelText")]
        String CancelText { get; set; }

        //@property(nonatomic,strong) NSString * okText;
        [Export("okText")]
        String OkText { get; set; }



        //-----end new
        // @property(nonatomic, assign) BOOL showRotateLeftToolItem;
        [Export("showRotateLeftToolItem")]
        Boolean ShowRotateLeftToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showRotateRightToolItem;
        [Export("showRotateRightToolItem")]
        Boolean ShowRotateRightToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showBrightnessToolItem;
        [Export("showBrightnessToolItem")]
        Boolean ShowBrightnessToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showContrastToolItem;
        [Export("showContrastToolItem")]
        Boolean showContrastToolItem { get; set; }

        // @property(nonatomic, assign) BOOL showImageModeToolItem;
        [Export("showImageModeToolItem")]
        Boolean showImageModeToolItem { get; set; }

        // @property(nonatomic, assign) UIImage* rotateLeftIcon;
        [Export("rotateLeftIcon")]
        UIImage RotateLeftIcon { get; set; }

        // @property(nonatomic, assign) UIImage* rotateRightIcon;
        [Export("rotateRightIcon")]
        UIImage RotateRightIcon { get; set; }

        // @property(nonatomic, assign) UIImage* brightnessContrastIcon;
        [Export("brightnessContrastIcon")]
        UIImage BrightnessContrastIcon { get; set; }

        // @property(nonatomic, assign) UIImage* imageModeIcon;
        [Export("imageModeIcon")]
        UIImage ImageModeIcon { get; set; }

        // @property(nonatomic, assign) UIImage* colorModeIcon;
        [Export("colorModeIcon")]
        UIImage ColorModeIcon { get; set; }

        // @property(nonatomic, assign) UIImage* greyModeIcon;
        [Export("greyModeIcon")]
        UIImage GreyModeIcon { get; set; }

        // @property(nonatomic, assign) UIImage* blackWhiteIcon;
        [Export("blackWhiteIcon")]
        UIImage BlackWhiteIcon { get; set; }

        // - (void) adjustContrast:(NSInteger) contrast;
        [Export("adjustContrast:")]
        void AdjustContrast(nint contrast);

        // - (void) adjustBrightness:(NSInteger) brightness;
        [Export("adjustBrightness:")]
        void AdjustBrightness(nint brightness);

        // - (void) rotateLeft;
        [Export("rotateLeft")]
        void RotateLeft();

        // - (void) rotateRight;
        [Export("rotateRight")]
        void RotateRight();

        // - (void) toColor;
        [Export("toColor")]
        void ToColor();

        // - (void) toGrey;
        [Export("toGrey")]
        void ToGrey();

        // - (void) toGrey;
        [Export("toBlackWhite")]
        void ToBlackWhite();

        //- (void) save;
        [Export("save")]
        void Save();

        //- (void) discard;
        [Export("discard")]
        void Discard();
    }

    //@interface DcsEncodeParameter: NSObject
    [BaseType(typeof(NSObject))]
    interface DcsEncodeParameter  { }

    [BaseType(typeof(DcsEncodeParameter))]
    interface DcsPNGEncodeParameter { }

    [BaseType(typeof(DcsEncodeParameter))]
    interface DcsJPEGEncodeParameter
    {
        //@property (nonatomic,assign) CGFloat quality;
        [Export("quality")]
        float Quality { get; set; }
    }

    [BaseType(typeof(DcsEncodeParameter))]    
    interface DcsPDFEncodeParameter
    {
        
       
        [Export("pageSize")]
        CoreGraphics.CGSize PageSize { get; set; }

        [Export("author")]
        String Author { get; set; }

        [Export("creator")]
        String Creator { get; set; }

        [Export("subject")]
        String Subject { get; set; }

        [Export("keywords")]
        String Keywords { get; set; }

        [Export("title")]
        String Title { get; set; }

        //@property(nonatomic, assign) DcsPDFQuality pdfQuality;
        [Export("pdfQuality")]
        DcsPDFQuality PDFQuality { get; set; }
    }

   
    [BaseType(typeof(NSObject))]
    interface DcsHttpUploadConfig
    {
        

        //@property(nonatomic, strong) NSString * url;
        [Export("url")]
        String Url { get; set; }

        [Export("name")]
        String Name { get; set; }

        [Export("uploadMethod")]
        DcsUploadMethodEnum UploadMethod { get; set; }

        [Export("dataFormat")]
        DcsDataFormatEnum DataFormat { get; set; }

        [Export("formField")]
        NSDictionary FormField { get; set; }

        [Export("header")]
        NSDictionary Header { get; set; }

        [Export("filePrefix")]
        String FilePrefix { get; set; }
    }

    [BaseType(typeof(NSObject))]
    interface DcsHttpDownloadConfig
    {
        [Export("url")]
        String Url { get; set; }

        [Export("header")]
        NSDictionary Header { get; set; }
    }
    /// <summary>
    /// DcsIO
    /// </summary>
    /// 
    //       typedef void (^onLoadFailure)(id source, DcsException* exp);
    public delegate void OnLoadFailure(NSObject source, DcsException exp);
    //       typedef void (^onLoadSuccess)(id source);
    public delegate void OnLoadSuccess(NSObject source);
    //       typedef BOOL(^onLoadProgress)(NSInteger progress);
    public delegate Boolean OnLoadProgress(nint progress);
    //       typedef BOOL(^onSaveProgress)(NSInteger progress);
    public delegate Boolean OnSaveProgress(nint progress);
    //       typedef void (^onSaveSuccess)(id result);
    public delegate void OnSaveSuccess(NSObject result);
    //       typedef void (^onSaveFailure)(id result, DcsException* exp);
    public delegate void OnSaveFailure(NSObject result, DcsException exp);
    //        typedef BOOL(^onUploadProgress)(NSInteger progress);
    public delegate Boolean OnUploadProgress(nint progress);
    //       typedef void (^onUploadFailure)(id userData, DcsException* exception);
    public delegate void OnUploadFailure(NSObject userData, DcsException exception);
    //       typedef void (^onUploadSuccess)(NSData* data);
    public delegate void OnUploadSuccess(NSData data);
    //      typedef BOOL(^onDownloadProgress)(NSInteger progress);
    public delegate void OnDownloadProgress(nint progress);
    //        typedef void (^onDownloadFailure)(DcsException* exception);
    public delegate void OnDownloadFailure(DcsException exception);
    //       typedef void (^onDownloadSuccess)(NSData* data);
    public delegate void OnDownloadSuccess(NSData data);
    [BaseType(typeof(NSObject))]
    interface DcsIo
    {
       

        [Export("init:")]
        IntPtr Constructor(NSObject targetClass);

        // (void) loadData:(NSData*) data mode:(DcsModeEnum) mode;
        [Export("loadData:mode:")]
        void LoadData(NSData data, DcsModeEnum mode);

        [Export("loadFile:mode:")]
        void LoadFile(String file, DcsModeEnum mode);

        [Export("loadDataAsync:mode:successCallback:failureCallback:progressCallback:")]
        void LoadDataAsync(NSData data, DcsModeEnum mode,
            OnLoadSuccess onLoadSuccess,OnLoadFailure onLoadFailure, OnLoadProgress onLoadProgress);
        
        [Export("loadFileAsync:mode:successCallback:failureCallback:progressCallback:")]
        void LoadFileAsync(string file, DcsModeEnum mode,
            OnLoadSuccess onLoadSuccess, OnLoadFailure onLoadFailure, OnLoadProgress onLoadProgress);

        //- (void)save:(NSArray *)indices file:(NSString *)filename encodeParameter:( DcsEncodeParameter  *)parameter;
        [Export("save:file:encodeParameter:")]
        void Save(NSObject[] indices,string fileName, DcsEncodeParameter parameter);

        //
        [Export("saveAsync:file:encodeParameter:successCallback:failureCallback:progressCallback:")]
        void SaveAsync(NSObject[] indices,string filename,DcsEncodeParameter parameter, OnSaveSuccess onSaveSuccess,OnSaveFailure onSaveFailure,OnSaveProgress onSaveProgress);

        [Export("uploadAsync:uploadConfig:encodeParameter:successCallback:failureCallback:progressCallback:")]
        void UploadAsync(NSObject[] indices, DcsHttpUploadConfig config, DcsEncodeParameter parameter, OnUploadSuccess onUploadSuccess, OnUploadFailure onUploadFailure, OnUploadProgress onUploadProgress);

        [Export("downloadAsync:mode:successCallback:failureCallback:progressCallback:")]
        void DownloadAsync(DcsHttpDownloadConfig config, DcsModeEnum mode, OnDownloadSuccess onDownloadSuccess, OnDownloadFailure onDownloadFailure, OnDownloadProgress onDownloadProgress);

    }
    // @interface DcsBuffer : NSObject
    [BaseType(typeof(NSObject))]
    interface DcsBuffer
    {
        //@property(nonatomic,assign)NSInteger currentIndex;
        [Export("currentIndex")]
        nint CurrentIndex { get; set; }

        //- (void)appendImage:(DcsImage *)image;
        [Export("appendImage:")]
        void AppendImage(DcsImage image);

        //- (void) appendDocument:(DcsDocument*) document;
        [Export("appendDocument:")]
        void AppendDocument(DcsDocument document);

        //- (id)get:( NSInteger )index;
        [Export("get:")]
        NSObject Get(nint index);

        //- (void)replaceWithImage:(DcsImage *)image index:(NSInteger)index;
        [Export("replaceWithImage:index:")]
        void ReplaceWithImage(DcsImage image, nint index);

        //- (void)replaceWithDocument:(DcsDocument *)document index:(NSInteger)index;
        [Export("replaceWithDocument:index:")]
        void ReplaceWithDocument(DcsDocument document, System.nint index);

        //- (void)swap:(NSInteger)firstIndex second:(NSInteger)secondIndex;
        [Export("swap:secondIndex:")]
        void Swap(nint firstIndex, nint secondIndex);

        //- (void)delete:( NSInteger)index;
        [Export("delete:")]
        void Delete(System.nint index);

        //- (void)save:(NSString *)dirName;
        [Export("save:")]
        void Save(string dirName);

        //- (void)load:(NSString *)dirName;
        [Export("load:")]
        void Load(string dirName);

        //- (NSInteger)count;
      
        [Export("count")]
        nint Count { get; }

        //- (void)insertDocument:(DcsDocument *)document index:(NSInteger)index;
        [Export("insertDocument:index:")]
        void InsertDocument(DcsDocument document, nint index);

        //- (void)insertImage:(DcsImage *)image index:(NSInteger)index;
        [Export("insertImage:index:")]
        void InsertImage(DcsImage image, nint index);

        //- (void) deleteAll;
        [Export("deleteAll")]
        void DeleteAll();

        //- (instancetype)initWithClass:(id)targetClass;
        [Export("initWithClass:")]
        IntPtr Constructor(NSObject targetClass);
        // public DcsBuffer(NSObject targetClass);
    }
    /// <summary>
    /// DcsImage
    /// </summary>
    [BaseType(typeof(NSObject))]
    interface DcsImage
    {
        [Export("init:")]
        IntPtr Constructor(UIImage image);

        [Export("initWithFile:")]
        IntPtr Constructor(string filename);

        [Export("uiImage")]
        UIImage UiImage { get; set; }

        [Export("width")]
        nint Width { get; set; }

        [Export("height")]
        nint Height { get; set; }

    }

    /// <summary>
    /// DcsDocument
    /// </summary>
    [BaseType(typeof(DcsImage))]
    interface DcsDocument
    {
        [Export("init:")]
        IntPtr Constructor(UIImage image);

        [Export("documentBoundary")]
        NSArray DocumentBoundary { get; set; }

        [Export("originalImage")]
        UIImage OriginalImage { get; set; }
    }



    [BaseType(typeof(NSException))]
    public interface DcsException
    {
        [Export("init:")]
        IntPtr Constructor(string reason);
    }

    [BaseType(typeof(DcsException))]
    interface DcsValueOutOfRangeException
    {
        [Export("init:")]
        IntPtr Constructor(string pName);

        [Export("throwDcsException:")]
        void ThrowDcsException(string pName);
    }

    [BaseType(typeof(DcsException))]
    interface DcsValueNotValidException
    {
        [Export("init:")]
        IntPtr Constructor(string pName);

        [Export("throwDcsException:")]
        void ThrowDcsException(string pName);
    }

    [BaseType(typeof(DcsException))]
    interface DcsDocumentNotReadyException
    {     

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsFileNotFoundException
    {
        [Export("init:")]
        IntPtr Constructor(string pFileName);

        [Export("throwDcsException:")]
        void ThrowDcsException(string pFileName);
    }


    [BaseType(typeof(DcsException))]
    interface DcsDocumentOnlyException
    {      

        [Export("throwDcsException")]
        void ThrowDcsException();
    }


    [BaseType(typeof(DcsException))]
    interface DcsImageOnlyException
    {

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsSelectModeNotEnabledException
    {      

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsDocumentNotDetectedException
    {     

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsLicenseException
    {
       
    }

    [BaseType(typeof(DcsException))]
    interface DcsTypeNotValidException
    {
        [Export("init:")]
        IntPtr Constructor(string pName);

        [Export("throwDcsException:")]
        void ThrowDcsException(string pName);
    }


    [BaseType(typeof(DcsException))]
    interface DcsFileReadException
    {       

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsFilePathInvalidException
    {
        [Export("init:")]
        IntPtr Constructor(string pFileName);

        [Export("throwDcsException:")]
        void ThrowDcsException(string pFileName);
    }

    [BaseType(typeof(DcsException))]
    interface DcsNotEnoughSpaceException
    {     

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsHttpErrorException
    {
        [Export("init:")]
        IntPtr Constructor(nint HTTP_status_codes);

        [Export("throwDcsException:")]
        void ThrowDcsException(nint HTTP_status_codes);
    }

    [BaseType(typeof(DcsException))]
    interface DcsDataFormatInvalidException
    {      

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsOperationCancelledException
    {       

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsNetworkUnconnectedException
    {       
        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsCameraNotAuthorizedException
    {    

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsObjectNotExistException
    {    

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsOperationSequenceException
    {       

        [Export("throwDcsException")]
        void ThrowDcsException();
    }


    [BaseType(typeof(DcsLicenseException))]
    interface DcsLicenseInvalidException
    {      

        [Export("throwDcsException")]
        void ThrowDcsException();
    }


    [BaseType(typeof(DcsLicenseException))]
    interface DcsLicenseExpiredException
    {      
        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsLicenseException))]
    interface DcsCameraNotOpenException
    {
        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsLicenseException))]
    interface DcsLicenseDevicesNumberExceededException
    {     

        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsLicenseException))]
    interface DcsLicenseVerificationFailedException
    {       
        [Export("throwDcsException")]
        void ThrowDcsException();
    }

    [BaseType(typeof(DcsException))]
    interface DcsDelegateUndefineException
    {
        [Export("init:")]
        IntPtr Constructor(string pName);

        [Export("throwDcsException:")]
        void ThrowDcsException(string pName);
    }

    [BaseType(typeof(DcsException))]
    interface DcsNullException
    {      
        [Export("throwDcsException")]
        void ThrowDcsException();
    }
}

