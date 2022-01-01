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
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Settings
{
    [XmlRoot("settings")]
    public class ProgramSettings
    {
        public const Int32 DefaultTop = 100;
        public const Int32 DefaultLeft = 100;
        public const Int32 DefaultHeight = 600;
        public const Int32 DefaultWidth = 500;

        public ProgramSettings()
        {
            this.MainWindow = new WindowSettings(
                ProgramSettings.DefaultLeft, ProgramSettings.DefaultTop,
                ProgramSettings.DefaultWidth, ProgramSettings.DefaultHeight);

            this.GeneratorData = new GeneratorSettings();
            this.CommonData = new CommonSettings();
            this.ExtendedData = new ExtendedSettings();
            this.ExchangeData = new ExchangeSettings();
            this.SecurityData = new SecuritySettings();
        }

        [XmlElement("main-window")]
        public WindowSettings MainWindow { get; set; }

        [XmlElement("generator-data")]
        public GeneratorSettings GeneratorData { get; set; }

        [XmlElement("common-data")]
        public CommonSettings CommonData { get; set; }

        [XmlElement("extended-data")]
        public ExtendedSettings ExtendedData { get; set; }

        [XmlElement("exchange-data")]
        public ExchangeSettings ExchangeData { get; set; }

        [XmlElement("security-data")]
        public SecuritySettings SecurityData { get; set; }
    }
}
