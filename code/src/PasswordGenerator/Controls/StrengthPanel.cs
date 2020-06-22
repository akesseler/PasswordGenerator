/*
 * MIT License
 * 
 * Copyright (c) 2020 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    // Quick & dirty owner drawn static progress but only with percentage behaviour!
    public class StrengthPanel : Panel
    {
        public const Int32 Minimum = 0;
        public const Int32 Maximum = 100;

        private Int32 value = StrengthPanel.Minimum;
        private Double percent = StrengthPanel.Minimum;
        private String label = String.Empty;

        public StrengthPanel()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.EnableNotifyMessage |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            base.BorderStyle = BorderStyle.FixedSingle;
            base.BackColor = Color.Transparent;
            base.ForeColor = SystemColors.WindowText;
            base.Padding = new Padding(1);
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        public Int32 Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value < StrengthPanel.Minimum)
                {
                    value = StrengthPanel.Minimum;
                }

                if (value > StrengthPanel.Maximum)
                {
                    value = StrengthPanel.Maximum;
                }

                if (this.value != value)
                {
                    this.value = value;
                    this.Invalidate();
                    this.Percent = Convert.ToDouble(this.value);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        public Double Percent
        {
            get
            {
                return this.percent;
            }
            set
            {
                Double minimum = Convert.ToDouble(StrengthPanel.Minimum);
                Double maximum = Convert.ToDouble(StrengthPanel.Maximum);

                if (value < minimum)
                {
                    value = minimum;
                }

                if (value > maximum)
                {
                    // E.g. 42.23% are meant if this fits...
                    value = value / maximum;

                    // There are given more than 100% in such a case.
                    if (value > maximum)
                    {
                        value = maximum;
                    }
                }

                if (this.percent != value)
                {
                    this.percent = value;
                    this.value = Convert.ToInt32(Math.Truncate(this.percent));

                    this.Invalidate();

                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        public String Label
        {
            get
            {
                return this.label;
            }
            set
            {
                value = value ?? String.Empty;

                if (this.label != value)
                {
                    this.label = value;
                    this.Invalidate();
                }
            }
        }

        protected Rectangle DrawingBounds
        {
            get
            {
                Padding padding = this.Padding;
                Rectangle rectangle = this.ClientRectangle;

                rectangle.X += padding.Left;
                rectangle.Y += padding.Top;
                rectangle.Width -= padding.Horizontal;
                rectangle.Height -= padding.Vertical;

                return rectangle;
            }
        }

        protected override void OnPaint(PaintEventArgs args)
        {
            base.OnPaint(args);

            Rectangle bounds = this.DrawingBounds;
            Region region = new Region(this.ClientRectangle);

            region.Exclude(bounds);
            args.Graphics.ExcludeClip(region);

            using (Brush brush = this.GetBrush(bounds))
            {
                Single x = bounds.X;
                Single y = bounds.Y;
                Single w = bounds.Width * ((Single)this.Value / 100f);
                Single h = bounds.Height;

                args.Graphics.FillRectangle(brush, x, y, w, h);
            }

            if (this.Value != 0 && !String.IsNullOrWhiteSpace(this.Label))
            {
                using (StringFormat format = new StringFormat())
                using (Brush brush = new SolidBrush(base.ForeColor))
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    format.FormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
                    format.Trimming = StringTrimming.EllipsisCharacter;

                    args.Graphics.DrawString(this.Label, base.Font, brush, bounds, format);
                }
            }
        }

        private Brush GetBrush(Rectangle bounds)
        {
            ColorBlend blend = new ColorBlend()
            {
                Colors = new Color[] { Color.Red, Color.Orange, Color.YellowGreen, Color.Green },
                Positions = new Single[] { 0f, 0.2f, 0.5f, 1f, }
            };

            return new LinearGradientBrush(bounds, Color.White, Color.White, 0f)
            {
                InterpolationColors = blend
            };
        }
    }
}
