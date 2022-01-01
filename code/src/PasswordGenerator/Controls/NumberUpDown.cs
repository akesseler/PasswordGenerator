/*
 * MIT License
 * 
 * Copyright (c) 2022 plexdata.de
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
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public class NumberUpDown : NumericUpDown
    {
        #region Construction

        public NumberUpDown()
            : base()
        {
        }

        #endregion

        #region Public Properties

        [Bindable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override String Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Bindable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Int32 Number
        {
            get
            {
                try
                {
                    return Decimal.ToInt32(base.Value);
                }
                catch (OverflowException)
                {
                    if (base.Value < 0)
                    {
                        return Int32.MinValue;
                    }

                    if (base.Value > 0)
                    {
                        return Int32.MaxValue;
                    }

                    throw;
                }
            }
            set
            {
                base.Value = value;
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnValidating(CancelEventArgs args)
        {
            // The original implementation allows empty text. But for sure, it doesn't 
            // really make sense. Therefore, restoring current value as text seems to 
            // be a good idea. See also that link.
            // https://stackoverflow.com/questions/15074193/check-if-numericupdown-is-empty

            base.OnValidating(args);

            if (!args.Cancel && String.IsNullOrWhiteSpace(this.Text))
            {
                this.Text = base.Value.ToString();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs args)
        {
            // Seems to be a bug in class NumericUpDown. Obviously, the mouse wheel 
            // event does not take care about increment. This simple implementation 
            // fixes that issue. See also that link.
            // https://stackoverflow.com/questions/5226688/numericupdown-mousewheel-event-increases-decimal-more-than-one-increment

            if (args is HandledMouseEventArgs evt)
            {
                if (evt.Delta > 0 && base.Value + this.Increment < this.Maximum)
                {
                    base.Value += this.Increment;
                    evt.Handled = true;
                    return;
                }

                if (evt.Delta < 0 && base.Value - this.Increment > this.Minimum)
                {
                    base.Value -= this.Increment;
                    evt.Handled = true;
                    return;
                }
            }

            base.OnMouseWheel(args);
        }

        #endregion
    }
}
