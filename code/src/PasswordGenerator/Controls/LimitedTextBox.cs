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
using System.Linq;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public class LimitedTextBox : TextBox
    {
        #region Private fields

        private LimitationType limitation = LimitationType.Neutral;
        private Boolean spaces = false;
        private Boolean multiple = false;
        private String subset = String.Empty;

        #endregion

        #region Public types

        public enum LimitationType
        {
            Neutral,
            Upper,
            Lower,
            Digit,
            Extra,
            Other
        }

        #endregion

        #region Construction

        public LimitedTextBox()
            : base()
        {
            this.Limitation = LimitationType.Neutral;
            this.AcceptSpaces = false;
            this.AllowMultiple = false;
            this.AllowedSubset = null;

            base.ContextMenu = new ContextMenu();
        }

        #endregion

        #region Public properties

        [Browsable(true)]
        [DefaultValue(LimitationType.Neutral)]
        [Description("Choose one of provided limitations. Choose \"Neutral\" to disable any kind of limitation.")]
        public LimitationType Limitation
        {
            get
            {
                return this.limitation;
            }
            set
            {
                if (this.limitation != value)
                {
                    this.limitation = value;
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Indicates whether spaces are allowed as input character or not.")]
        public Boolean AcceptSpaces
        {
            get
            {
                return this.spaces;
            }
            set
            {
                if (this.spaces != value)
                {
                    this.spaces = value;
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Indicates whether one and the same character can occur multiple times or not.")]
        public Boolean AllowMultiple
        {
            get
            {
                return this.multiple;
            }
            set
            {
                if (this.multiple != value)
                {
                    this.multiple = value;
                }
            }
        }

        [Browsable(true)]
        [DefaultValue("")]
        [Description("Provide a list of characters that limiting the possible characters typed by users.")]
        public String AllowedSubset
        {
            get
            {
                return this.subset;
            }
            set
            {
                if (value is null)
                {
                    value = String.Empty;
                }

                if (this.subset != value)
                {
                    this.subset = value;
                }
            }
        }

        [Browsable(false)]
        public override String Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = this.GetValidInput(value);
                }
            }
        }

        #endregion

        #region Protected methods

        protected override void OnKeyPress(KeyPressEventArgs args)
        {
            if (!this.HandleInput(args))
            {
                return;
            }

            base.OnKeyPress(args);
        }

        protected override void WndProc(ref Message message)
        {
            const Int32 WM_PASTE = 0x0302;

            if (message.Msg == WM_PASTE)
            {
                return;
            }

            base.WndProc(ref message);
        }

        #endregion

        #region Private methods

        private Boolean HandleInput(KeyPressEventArgs args)
        {
            Boolean permitted = true;
            Char current = args.KeyChar;

            if (this.limitation == LimitationType.Neutral)
            {
                return permitted;
            }

            if (Char.IsControl(current))
            {
                return permitted;
            }

            permitted = this.IsPermitted(ref current, this.Text ?? String.Empty);

            args.KeyChar = current;
            args.Handled = !permitted;

            return permitted;
        }

        private String GetValidInput(String value)
        {
            value = value?.Trim() ?? String.Empty;

            String result = String.Empty;

            for (Int32 index = 0; index < value.Length; index++)
            {
                Char current = value[index];

                if (this.IsPermitted(ref current, result))
                {
                    result += current;
                }
            }

            return result;
        }

        private Boolean IsPermitted(ref Char current, String value)
        {
            Boolean permitted = true;

            if (String.IsNullOrWhiteSpace(this.subset))
            {
                return permitted;
            }

            if (this.spaces && current == ' ')
            {
                return permitted;
            }

            if (this.limitation == LimitationType.Upper)
            {
                current = Char.ToUpperInvariant(current);
            }
            else if (this.limitation == LimitationType.Lower)
            {
                current = Char.ToLowerInvariant(current);
            }

            permitted = this.limitation == LimitationType.Other || this.subset.Contains(current);

            if (permitted && !this.multiple)
            {
                permitted = !value.Contains(current);
            }

            return permitted;
        }

        #endregion
    }
}
