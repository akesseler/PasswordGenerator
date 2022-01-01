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

using Plexdata.Utilities.Password.Entities;
using System;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class DurationControl : UserControl
    {
        public DurationControl()
        {
            this.InitializeComponent();
            this.Reset();
        }

        public void SetDuration(Duration duration)
        {
            this.txtMillennia.Text = "0";
            this.txtCenturies.Text = "0";
            this.txtDecades.Text = "0";
            this.txtYears.Text = "0";
            this.txtMonths.Text = "0";
            this.txtWeeks.Text = "0";
            this.txtDays.Text = "0";
            this.txtTime.Text = "00:00:00.000";

            if (duration == null)
            {
                return;
            }

            this.txtMillennia.Text = duration.Millennia.ToString();
            this.txtCenturies.Text = duration.Centuries.ToString();
            this.txtDecades.Text = duration.Decades.ToString();
            this.txtYears.Text = duration.Years.ToString();
            this.txtMonths.Text = duration.Months.ToString();
            this.txtWeeks.Text = duration.Weeks.ToString();
            this.txtDays.Text = duration.Days.ToString();
            this.txtTime.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", duration.Hours, duration.Minutes, duration.Seconds, duration.Milliseconds);
        }

        public void Reset()
        {
            this.SetDuration(null);
        }
    }
}
