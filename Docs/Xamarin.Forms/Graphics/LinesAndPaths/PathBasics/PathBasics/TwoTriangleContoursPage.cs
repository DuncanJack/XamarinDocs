﻿using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace PathBasics
{
    public class TwoTriangleContoursPage : ContentPage
    {
        public TwoTriangleContoursPage()
        {
            Title = "Two Triangle Contours";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Create the path
            SKPath path = new SKPath();

            // Define the first contour
            path.MoveTo(0.5f * info.Width, 0.1f * info.Height);
            path.LineTo(0.2f * info.Width, 0.4f * info.Height);
            path.LineTo(0.8f * info.Width, 0.4f * info.Height);
            path.LineTo(0.5f * info.Width, 0.1f * info.Height);

            // Define the second contour
            path.MoveTo(0.5f * info.Width, 0.6f * info.Height);
            path.LineTo(0.2f * info.Width, 0.9f * info.Height);
            path.LineTo(0.8f * info.Width, 0.9f * info.Height);
            path.Close();

            // Create two SKPaint objects
            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Magenta,
                StrokeWidth = 50
            };

            SKPaint fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Cyan
            };

            // Fill and stroke the path
            canvas.DrawPath(path, fillPaint);
            canvas.DrawPath(path, strokePaint);
        }
    }
}

