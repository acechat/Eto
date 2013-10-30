using System;
using MonoMac.AppKit;
using Eto.Forms;
using Eto.Drawing;
using Eto.Platform.Mac.Drawing;

namespace Eto.Platform.Mac.Forms.Controls
{
	public class ImageViewHandler : MacControl<NSImageView, ImageView>, IImageView
	{
		Image image;
		
		public class EtoImageView : NSImageView, IMacControl
		{
			public WeakReference WeakHandler { get; set; }

			public object Handler
			{ 
				get { return WeakHandler.Target; }
				set { WeakHandler = new WeakReference(value); } 
			}
		}
		
		public ImageViewHandler ()
		{
			Control = new EtoImageView { Handler = this, ImageScaling = NSImageScale.ProportionallyUpOrDown };
		}

		protected override SizeF GetNaturalSize (SizeF availableSize)
		{
			if (image != null)
				return image.Size;
			return Size.Empty;
		}
		
		public Image Image {
			get {
				return image;
			}
			set {
				image = value;
				if (image != null)
					Control.Image = ((IImageSource)value.Handler).GetImage ();
				else
					Control.Image = null;
			}
		}
	}
}

