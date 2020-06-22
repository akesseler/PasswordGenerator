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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Extensions
{
    public static class WatermarkExtension
    {
        public static String ExtractWatermark(this Control control)
        {
            if (control is null)
            {
                return String.Empty;
            }

            if (control.Tag is String watermark && !String.IsNullOrWhiteSpace(watermark))
            {
                return watermark;
            }
            else
            {
                return String.Format("{0}...", control.Text.Replace("&", "").Replace(":", "").ToLower());
            }
        }

        public static void SetWatermark(this Control control)
        {
            WatermarkExtension.SetWatermark(control, false);
        }

        public static void SetWatermark(this Control control, Boolean show)
        {
            WatermarkExtension.SetWatermark(control, control.ExtractWatermark(), show);
        }

        public static void SetWatermark(this Control control, String banner)
        {
            WatermarkExtension.SetWatermark(control, banner, false); // True if the cue banner should show even when the edit control has focus.
        }

        public static void SetWatermark(this Control control, String banner, Boolean show)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control), "The control must not be null.");
            }

            if (control is TextBox)
            {
                WatermarkExtension.SetWatermark((control as TextBox), banner, show);
                return;
            }

            if (control is ComboBox)
            {
                WatermarkExtension.SetWatermark((control as ComboBox), banner);
                return;
            }

            throw new NotSupportedException("Only text-box and combo-box control types are supported.");
        }

        private static void SetWatermark(ComboBox control, String banner)
        {
            WatermarkExtension.ValidateWindowsVersion();

            IntPtr result = WatermarkExtension.SendMessage(
                control.Handle,
                WatermarkExtension.CB_SETCUEBANNER,
                IntPtr.Zero,
                Marshal.StringToBSTR(banner)
            );

            if (result == IntPtr.Zero)
            {
                throw new InvalidOperationException("Applying textual cue banner (watermark) has failed for some reason.");
            }
        }

        private static void SetWatermark(TextBox control, String banner, Boolean show)
        {
            WatermarkExtension.ValidateWindowsVersion();

            if (control.Multiline)
            {
                throw new NotSupportedException("Textual cue banner (watermark) is not supported on multiline edit controls.");
            }

            IntPtr result = WatermarkExtension.SendMessage(
                control.Handle,
                WatermarkExtension.EM_SETCUEBANNER,
                new IntPtr(show ? 1 : 0),
                Marshal.StringToBSTR(banner)
            );

            if (result == IntPtr.Zero)
            {
                throw new InvalidOperationException("Applying textual cue banner (watermark) has failed for some reason.");
            }
        }

        private static void ValidateWindowsVersion()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                throw new NotSupportedException("Minimum Windows version must be six or higher.");
            }
        }

        #region TextBox control message definitions.

        private const Int32 ECM_FIRST = 0x1500;
        private const Int32 EM_SETCUEBANNER = (ECM_FIRST + 1);
        private const Int32 EM_GETCUEBANNER = (ECM_FIRST + 2);

        #endregion // TextBox control message definitions.

        #region ComboBox control message definitions.

        private const Int32 CBM_FIRST = 0x1700;
        private const Int32 CB_SETCUEBANNER = (CBM_FIRST + 3);
        private const Int32 CB_GETCUEBANNER = (CBM_FIRST + 4);

        #endregion // ComboBox control message definitions.

        #region Win32 message handling imports.

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 message, IntPtr wParam, IntPtr lParam);

        #endregion // Win32 message handling imports.
    }
}
