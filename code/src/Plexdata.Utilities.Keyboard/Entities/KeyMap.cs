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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Plexdata.Utilities.Keyboard.Entities
{
    /// <summary>
    /// A class representing the mapping of a virtual key to its scan code as well 
    /// as to its related keyboard characters.
    /// </summary>
    public class KeyMap : IComparable<KeyMap>
    {
        #region Public Fields

        public const Char Invalid = '\0';

        #endregion

        #region Construction

        public KeyMap(UInt32 virtualKey)
            : base()
        {
            IntPtr layout = KeyMap.GetKeyboardLayout(0);

            this.VirtualKey = virtualKey;
            this.ScanCode = KeyMap.MapVirtualKeyExW(this.VirtualKey, MAPVK_VK_TO_VSC, layout);
            this.LowerKey = KeyMap.Invalid;
            this.UpperKey = KeyMap.Invalid;
            this.ThirdKey = KeyMap.Invalid;

            if (this.ScanCode == 0)
            {
                return;
            }

            Int32 dwResult;
            Boolean isDeadKey = false;
            Byte[] keyState = new Byte[256];
            StringBuilder buffer = new StringBuilder(16);

            // 
            // Get associated lower key value.
            // 

            keyState[VK_SHIFT] = 0x00;
            keyState[VK_CONTROL] = 0x00;
            keyState[VK_MENU] = 0x00;

            dwResult = KeyMap.ToUnicodeEx(this.VirtualKey, this.ScanCode, keyState, buffer, buffer.Capacity, 0, layout);

            isDeadKey = dwResult < 0;

            if (dwResult > 0)
            {
                if (this.IsAnyControl(buffer))
                {
                    return;
                }

                if (dwResult == 1)
                {
                    this.LowerKey = buffer[0];
                }

                if (dwResult == 2)
                {
                    Debug.Assert(false, "Got a second character pretty unexpectedly.");
                }
            }

            // 
            // Get associated upper key value.
            // 

            keyState[VK_SHIFT] = 0xFF;
            keyState[VK_CONTROL] = 0x00;
            keyState[VK_MENU] = 0x00;

            buffer.Clear();

            dwResult = KeyMap.ToUnicodeEx(this.VirtualKey, this.ScanCode, keyState, buffer, buffer.Capacity, 0, layout);

            if (dwResult > 0)
            {
                if (dwResult == 1)
                {
                    this.UpperKey = buffer[0];
                }
                else if (dwResult == 2 && isDeadKey)
                {
                    this.LowerKey = buffer[0];
                    this.UpperKey = buffer[1];
                }
                else
                {
                    Debug.Assert(false, "Got two characters but none of them  is a dead key.");
                }
            }

            // Upper key and lower key might be the same; but use only one of them.
            if (this.LowerKey != KeyMap.Invalid && this.LowerKey == this.UpperKey)
            {
                this.UpperKey = KeyMap.Invalid;
            }

            // 
            // Get associated ALT-GR key value.
            // 

            keyState[VK_SHIFT] = 0x00;
            keyState[VK_CONTROL] = 0xFF;
            keyState[VK_MENU] = 0xFF;

            buffer.Clear();

            dwResult = KeyMap.ToUnicodeEx(this.VirtualKey, this.ScanCode, keyState, buffer, buffer.Capacity, 0, layout);

            if (dwResult > 0)
            {
                if (dwResult == 1)
                {
                    this.ThirdKey = buffer[0];
                }
                // Do not change conditions. It came along with testing US keyboard.
                else if (dwResult == 2 && this.UpperKey == KeyMap.Invalid)
                {
                    this.UpperKey = buffer[0];
                    this.ThirdKey = buffer[1];
                }
                else
                {
                    Debug.Assert(false, "Got a second character pretty unexpectedly.");
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the assigned virtual key.
        /// </summary>
        /// <remarks>
        /// The virtual key represents the globalised value of a particular 
        /// keyboard key or mouse buttons.
        /// </remarks>
        public UInt32 VirtualKey { get; }

        /// <summary>
        /// Gets the assigned scan code.
        /// </summary>
        /// <remarks>
        /// The scan code represents the physical value of a particular keyboard 
        /// key.
        /// </remarks>
        public UInt32 ScanCode { get; }

        /// <summary>
        /// Gets the assigned lower character.
        /// </summary>
        /// <remarks>
        /// Lower characters are the characters that come from a keyboard without 
        /// pressing any other manipulator key, such as the shift key.
        /// </remarks>
        public Char LowerKey { get; }

        /// <summary>
        /// Gets the assigned upper character (with SHIFT key).
        /// </summary>
        /// <remarks>
        /// Upper characters are the characters that come from a keyboard when the 
        /// shift key is pressed as well.
        /// </remarks>
        public Char UpperKey { get; }

        /// <summary>
        /// Gets the assigned third character.
        /// </summary>
        /// <remarks>
        /// Third characters are the characters that come from a keyboard when the 
        /// ALT-GR key is pressed as well.
        /// </remarks>
        public Char ThirdKey { get; }

        /// <summary>
        /// Determines whether this key map is visible.
        /// </summary>
        /// <remarks>
        /// A particular key map is considered as visible as soon as its scan code 
        /// is not zero and at least one of the assigned characters is valid.
        /// </remarks>
        /// <value>
        /// True, if the key map can be shown and false otherwise.
        /// </value>
        public Boolean IsVisible
        {
            get
            {
                return this.ScanCode != 0 && (this.LowerKey != KeyMap.Invalid || this.UpperKey != KeyMap.Invalid || this.ThirdKey != KeyMap.Invalid);
            }
        }

        #endregion

        #region Public Methods

        public static Int32 CompareByVirtualKey(KeyMap x, KeyMap y)
        {
            if (x == null) { throw new ArgumentNullException(nameof(x)); }

            if (y == null) { throw new ArgumentNullException(nameof(y)); }

            if (Object.ReferenceEquals(x, y)) { return 0; }

            if (x.VirtualKey < y.VirtualKey) { return -1; }

            if (x.VirtualKey > y.VirtualKey) { return 1; }

            return 0;
        }

        public static Int32 CompareByScanCode(KeyMap x, KeyMap y)
        {
            if (x == null) { throw new ArgumentNullException(nameof(x)); }

            if (y == null) { throw new ArgumentNullException(nameof(y)); }

            if (Object.ReferenceEquals(x, y)) { return 0; }

            if (x.ScanCode < y.ScanCode) { return -1; }

            if (x.ScanCode > y.ScanCode) { return 1; }

            return 0;
        }

        public Int32 CompareTo(KeyMap other)
        {
            return KeyMap.CompareByScanCode(this, other);
        }

        public override String ToString()
        {
            const Char space = ' ';

            StringBuilder result = new StringBuilder();

            result.Append($"VK:{space}0x{this.VirtualKey.ToString("X2")}{space}SC:{space}0x{this.ScanCode.ToString("X2")}{space}CH:{space}");

            if (this.LowerKey != KeyMap.Invalid)
            {
                if (this.LowerKey == space)
                {
                    result.Append($"SPC{space}");
                }
                else
                {
                    result.Append($"{this.LowerKey}{space}");
                }
            }

            if (this.UpperKey != KeyMap.Invalid)
            {
                result.Append($"{this.UpperKey}{space}");
            }

            if (this.ThirdKey != KeyMap.Invalid)
            {
                result.Append($"{this.ThirdKey}{space}");
            }

            return result.ToString().TrimEnd(space);
        }

        #endregion 

        #region Private Methods

        private Boolean IsAnyControl(StringBuilder builder)
        {
            for (Int32 index = 0; index < builder.Length; index++)
            {
                if (Char.IsControl(builder[index]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Win32 Access

        // Virtual-Key Codes: https://docs.microsoft.com/de-de/windows/win32/inputdev/virtual-key-codes

        private const UInt32 MAPVK_VK_TO_VSC = 0;
        private const UInt32 VK_SHIFT = 0x10;
        private const UInt32 VK_CONTROL = 0x11;
        private const UInt32 VK_MENU = 0x12;

        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(
            UInt32 idThread
        );

        [DllImport("user32.dll")]
        private static extern UInt32 MapVirtualKeyExW(
            UInt32 uCode,
            UInt32 uMapType,
            IntPtr dwhkl
        );

        [DllImport("user32.dll")]
        private static extern Int32 ToUnicodeEx(
            UInt32 wVirtKey,
            UInt32 wScanCode,
            Byte[] lpKeyState,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff,
            Int32 cchBuff,
            UInt32 wFlags,
            IntPtr dwhkl
        );

        #endregion
    }
}
