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
    public class TabViewControl : TabControl
    {
        private const Int32 WS_EX_COMPOSITED = 0x02000000;
        private const Int32 TCM_FIRST = 0x1300;
        private const Int32 TCM_ADJUSTRECT = (TCM_FIRST + 40);

        public TabViewControl()
            : base()
        {
            base.DoubleBuffered = true;
            this.TabsVisible = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // NOTE: The WS_EX_COMPOSITED style is disabled under Win XP.
                // Setting the COMPOSITED window style works very fine under Window 7. But 
                // under Windows XP, this style causes some sub-controls to be drawn very 
                // ugly. Additionally, the resizing behaviour is also very bad. Therefore, 
                // this feature is not supported for Windows XP, with the result that the 
                // Setting dialog flickers a bit.

                CreateParams cp = base.CreateParams;

                if (this.IsVistaOrHigher)
                {
                    // This makes the tab control flicker free.
                    cp.ExStyle |= WS_EX_COMPOSITED;
                }

                return cp;
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public Boolean TabsVisible { get; set; }

        protected override void WndProc(ref Message message)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message.
            // http://stackoverflow.com/questions/6953487/remove-hide-tab-headerswitcher-of-c-sharp-tabcontrol
            if (message.Msg == TCM_ADJUSTRECT && !this.TabsVisible && !this.DesignMode)
            {
                message.Result = (IntPtr)1;
            }
            else
            {
                base.WndProc(ref message);
            }
        }

        private Boolean IsVistaOrHigher
        {
            get
            {
                // A system is running under Vista or higher as soon 
                // as the major version is greater or equal 6.
                return Environment.OSVersion.Version.Major >= 6;
            }
        }
    }
}
