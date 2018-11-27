using System;

using UIKit;
using DynamsoftCamera;
using ObjCRuntime;
using Foundation;

namespace ScanDocument
{
    public class UIVideoViewDelegate : DcsUIVideoViewDelegate {
		public override bool OnPreCapture(NSObject sender)
		{
            Console.WriteLine("PreCapture invoked");
            GC.Collect();
            return true;
		}
        public override void OnPostCapture(NSObject sender, DcsImage image)
		{
            Console.WriteLine("PostCapture invoked");
           
        }
		public override void OnCancelTapped(NSObject sender)
		{
            Console.WriteLine("VideoView cancel tapped");
            sender = null;
        }
		public override void OnCaptureTapped(NSObject sender)
		{
            Console.WriteLine("Capture tapped");
            sender = null;
        }
		public override void OnCaptureFailure(NSObject sender, DcsException exception)
		{
            Console.WriteLine("CaptureFailure invoked");
            sender = null;
        }
		public override void OnDocumentDetected(NSObject sender, DcsDocument document)
		{
            Console.WriteLine("DocumentDetected invoked");
            sender = null;
            document = null;
        }
	}

    public class UIDocumentEditorViewDelegate : DcsUIDocumentEditorViewDelegate {
		public override void OnCancelTapped(NSObject sender)
		{
            Console.WriteLine("DocumentEditorView cancel tapped");
            sender = null;

        }
		public override void OnOkTapped(NSObject sender, DcsException exception)
		{
            Console.WriteLine("DocumentEditorView ok tapped");
            sender = null;
        }
	}

    public class UIImageGalleryViewDelegate : DcsUIImageGalleryViewDelegate {
		public override void OnLongPress(NSObject sender, nint index)
		{
            Console.WriteLine("LongPress invoked");

		}
		public override void OnSingleTap(NSObject sender, nint index)
		{
            Console.WriteLine("SingleTap invoked");
		}
		public override void  OnSelectChanged(NSObject sender, NSObject[] indices)
		{
            Console.WriteLine("SelectChanged invoked");
		}
	}

    public partial class ViewController : UIViewController
    {
        DcsView dcsView;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            CoreGraphics.CGSize fullScreenSize = UIScreen.MainScreen.Bounds.Size;
            dcsView = new DcsView(new CoreGraphics.CGRect(0, 0, fullScreenSize.Width, fullScreenSize.Height));
            View.AddSubview(dcsView);

            UINavigationBar navigationBar = new UINavigationBar(new CoreGraphics.CGRect(0, 0, fullScreenSize.Width, 64));
            UINavigationItem navigationItem = new UINavigationItem("ScanDocument");
            navigationBar.PushNavigationItem(navigationItem, true);
            View.AddSubview(navigationBar);

            DcsView.SetLogLevel(DcsLogLevelEnum.Off);

            dcsView.CurrentView = DcsViewEnum.Imagegalleryview;
            dcsView.ImageGalleryView.Delegate = new UIImageGalleryViewDelegate();

            dcsView.VideoView.Mode = DcsModeEnum.Document;
            dcsView.VideoView.IfAllowDocumentCaptureWhenNotDetected = true;
            dcsView.VideoView.NextViewAfterCancel = DcsViewEnum.Imagegalleryview;
            dcsView.VideoView.NextViewAfterCapture = DcsViewEnum.Videoview;
            dcsView.VideoView.Delegate = new UIVideoViewDelegate();

            dcsView.DocumentEditorView.NextViewAfterOK = DcsViewEnum.Imagegalleryview;
            dcsView.DocumentEditorView.NextViewAfterCancel = DcsViewEnum.Videoview;
            dcsView.DocumentEditorView.Delegate = new UIDocumentEditorViewDelegate();
            dcsView.DocumentEditorView.ToBlackWhite();
            UIButton uIButton = new UIButton(UIButtonType.Custom);
            uIButton.Frame = new CoreGraphics.CGRect((fullScreenSize.Width - 84) / 2,
                                                     (fullScreenSize.Height - 175),
                                                     84, 84);
            uIButton.SetTitle("Camera", UIControlState.Normal);
            uIButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            uIButton.Layer.CornerRadius = 42;
            uIButton.Layer.BorderWidth = 2;
            uIButton.Layer.BorderColor = UIColor.Blue.CGColor;
            uIButton.BackgroundColor = UIColor.White;
            uIButton.TouchUpInside += delegate {
                dcsView.CurrentView = DcsViewEnum.Videoview;
            };
            View.AddSubview(uIButton);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
