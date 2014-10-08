﻿using System;
using System.Drawing;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using Xamarin.Forms;
using System.ComponentModel;
using CouchbaseConnect2014.iOS;
using CouchbaseConnect2014.Controls;
using MonoTouch.Foundation;
using System.Reflection;

[assembly: ExportRendererAttribute(typeof(RoundedImageView), typeof(RoundedImageRenderer))]
namespace CouchbaseConnect2014.iOS
{
	public class RoundedImageRenderer : ImageRenderer
	{
		public RoundedImageRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);
			base.SetNativeControl (new UIImageView (RectangleF.Empty) {
				ContentMode = UIViewContentMode.ScaleAspectFit,
				ClipsToBounds = true,
				Layer = {
					CornerRadius = (float)(e.NewElement.WidthRequest / 2.0),
					BorderWidth = 0
				}
			});

			var basetype = typeof(ImageRenderer);

			// reflection calls
			basetype.GetMethod ("SetAspect", BindingFlags.NonPublic | BindingFlags.Instance).Invoke (this, new object[] {});
			basetype.GetMethod ("SetImage", BindingFlags.NonPublic | BindingFlags.Instance).Invoke (this, new object[] {});
			basetype.GetMethod ("SetOpacity", BindingFlags.NonPublic | BindingFlags.Instance).Invoke (this, new object[] {});
		}
	}
}
