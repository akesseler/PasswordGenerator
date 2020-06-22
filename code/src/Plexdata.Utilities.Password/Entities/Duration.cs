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

namespace Plexdata.Utilities.Password.Entities
{
    /// <summary>
    /// This class represents the estimated time needed to crack a password.
    /// </summary>
    /// <remarks>
    /// <para>
    /// As mentioned in the summary, the time to crack a password strictly 
    /// depends on the used method as well as on the computer system used for
    /// calculations. Against this background, the duration to crack passwords 
    /// can only be considered as an estimation.
    /// </para>
    /// <para>
    /// Be aware, the maximum amount of seconds that this calls is able to handle 
    /// is limited to the total amount of seconds of <see cref="TimeSpan.MaxValue"/>.
    /// </para>
    /// </remarks>
    public class Duration
    {
        #region Private Fields

        /// <summary>
        /// The number of days for one week.
        /// </summary>
        /// <remarks>
        /// Well this constant value is actually set to 7 days.
        /// </remarks>
        private const Int32 DaysPerWeek = 7;

        /// <summary>
        /// The number of days for one month.
        /// </summary>
        /// <remarks>
        /// Well this constant value can only be an average and is actually set 
        /// to 30 days per month.
        /// </remarks>
        private const Int32 DaysPerMonth = 30;

        /// <summary>
        /// The number of days for one year.
        /// </summary>
        /// <remarks>
        /// Well this constant value can only be an average and is actually set 
        /// to 365 days per year.
        /// </remarks>
        private const Int32 DaysPerYear = 365;

        /// <summary>
        /// The number of days for one decade.
        /// </summary>
        /// <remarks>
        /// This constant value consists of the average number days per year for 
        /// 10 years. Therefore, the value is set to 3,650 day per decade.
        /// </remarks>
        private const Int32 DaysPerDecade = 10 * DaysPerYear;

        /// <summary>
        /// The number of days for one century.
        /// </summary>
        /// <remarks>
        /// This constant value consists of the average number days per year for 
        /// 100 years. Therefore, the value is set to 36,500 day per decade.
        /// </remarks>
        private const Int32 DaysPerCentury = 10 * DaysPerDecade;

        /// <summary>
        /// The number of days for one millennium.
        /// </summary>
        /// <remarks>
        /// This constant value consists of the average number days per year for 
        /// 1,000 years. Therefore, the value is set to 365,000 day per decade.
        /// </remarks>
        private const Int32 DaysPerMillennium = 10 * DaysPerCentury;

        #endregion

        #region Public Fields

        /// <summary>
        /// Represents a zero duration.
        /// </summary>
        /// <remarks>
        /// This field represents a zero duration. Zero duration means that 
        /// each property is zero.
        /// </remarks>
        public static Duration Zero;

        /// <summary>
        /// Represents to maximum possible duration.
        /// </summary>
        /// <remarks>
        /// This field represents to maximum possible duration, which means a 
        /// limitation to the total amount of seconds of <see cref="TimeSpan.MaxValue"/>.
        /// </remarks>
        public static Duration Maximum;

        #endregion

        #region Construction

        /// <summary>
        /// Static construction.
        /// </summary>
        /// <remarks>
        /// This constructor just initializes all static fields.
        /// </remarks>
        static Duration()
        {
            Duration.Zero = new Duration();
            Duration.Maximum = new Duration(TimeSpan.MaxValue.TotalSeconds);
        }

        /// <summary>
        /// Default construction.
        /// </summary>
        /// <remarks>
        /// This constructor just initializes all properties with zero.
        /// </remarks>
        public Duration()
        {
            this.Millennia = 0;
            this.Centuries = 0;
            this.Decades = 0;
            this.Years = 0;
            this.Months = 0;
            this.Weeks = 0;
            this.Days = 0;
            this.Hours = 0;
            this.Minutes = 0;
            this.Seconds = 0;
            this.Milliseconds = 0;
        }

        /// <summary>
        /// Parameterized construction.
        /// </summary>
        /// <remarks>
        /// This constructor just initializes all properties with their corresponding 
        /// parts of parameter <paramref name="seconds"/>.
        /// </remarks>
        /// <param name="seconds">
        /// The number of seconds used for property initialization.
        /// </param>
        /// <exception cref="OverflowException">
        /// This exception is thrown if parameter <paramref name="seconds"/> represents 
        /// a negative or a positive infinite value.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown either if parameter <paramref name="seconds"/> 
        /// represents a NaN value or if parameter <paramref name="seconds"/> is less 
        /// than zero.
        /// </exception>
        public Duration(Double seconds)
            : this()
        {
            this.ApplyFromSeconds(seconds);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Number of affected millennia.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected millennia.
        /// </remarks>
        /// <value>
        /// The number of affected millennia taken from provided seconds.
        /// </value>
        public Int32 Millennia { get; private set; }

        /// <summary>
        /// Number of affected centuries.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected centuries.
        /// </remarks>
        /// <value>
        /// The number of affected centuries taken from provided seconds.
        /// </value>
        public Int32 Centuries { get; private set; }

        /// <summary>
        /// Number of affected decades.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected decades.
        /// </remarks>
        /// <value>
        /// The number of affected decades taken from provided seconds.
        /// </value>
        public Int32 Decades { get; private set; }

        /// <summary>
        /// Number of affected years.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected years.
        /// </remarks>
        /// <value>
        /// The number of affected years taken from provided seconds.
        /// </value>
        public Int32 Years { get; private set; }

        /// <summary>
        /// Number of affected months.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected months.
        /// </remarks>
        /// <value>
        /// The number of affected months taken from provided seconds.
        /// </value>
        public Int32 Months { get; private set; }

        /// <summary>
        /// Number of affected weeks.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected weeks.
        /// </remarks>
        /// <value>
        /// The number of affected weeks taken from provided seconds.
        /// </value>
        public Int32 Weeks { get; private set; }

        /// <summary>
        /// Number of affected days.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected days.
        /// </remarks>
        /// <value>
        /// The number of affected days taken from provided seconds.
        /// </value>
        public Int32 Days { get; private set; }

        /// <summary>
        /// Number of affected hours.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected hours.
        /// </remarks>
        /// <value>
        /// The number of affected hours taken from provided seconds.
        /// </value>
        public Int32 Hours { get; private set; }

        /// <summary>
        /// Number of affected minutes.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected minutes.
        /// </remarks>
        /// <value>
        /// The number of affected minutes taken from provided seconds.
        /// </value>
        public Int32 Minutes { get; private set; }

        /// <summary>
        /// Number of affected seconds.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected seconds.
        /// </remarks>
        /// <value>
        /// The number of affected seconds taken from provided seconds.
        /// </value>
        public Int32 Seconds { get; private set; }

        /// <summary>
        /// Number of affected milliseconds.
        /// </summary>
        /// <remarks>
        /// This property represents the number of affected milliseconds.
        /// </remarks>
        /// <value>
        /// The number of affected milliseconds taken from provided seconds.
        /// </value>
        public Int32 Milliseconds { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates an instance of class <see cref="Duration"/> taking 
        /// provided <paramref name="seconds"/> as initial value.
        /// </summary>
        /// <remarks>
        /// This static method just creates an instance of class <see cref="Duration"/> 
        /// taking provided <paramref name="seconds"/> as initial value.
        /// </remarks>
        /// <param name="seconds">
        /// The number of seconds used for property initialization.
        /// </param>
        /// <returns>
        /// An instance of class <see cref="Duration"/>.
        /// </returns>
        /// <exception cref="OverflowException">
        /// This exception is thrown if parameter <paramref name="seconds"/> represents 
        /// a negative or a positive infinite value.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown either if parameter <paramref name="seconds"/> 
        /// represents a NaN value or if parameter <paramref name="seconds"/> is less 
        /// than zero.
        /// </exception>
        /// <seealso cref="Duration(Double)"/>
        public static Duration FromSeconds(Double seconds)
        {
            return new Duration(seconds);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <remarks>
        /// This method determines whether the specified object is equal to the 
        /// current object.
        /// </remarks>
        /// <param name="other">
        /// The object to compare with the current object.
        /// </param>
        /// <returns>
        /// True if the specified object is equal to the current object; otherwise, 
        /// false.
        /// </returns>
        public override Boolean Equals(Object other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is Duration duration)
            {
                return this.Millennia == duration.Millennia &&
                       this.Centuries == duration.Centuries &&
                       this.Decades == duration.Decades &&
                       this.Years == duration.Years &&
                       this.Months == duration.Months &&
                       this.Weeks == duration.Weeks &&
                       this.Days == duration.Days &&
                       this.Hours == duration.Hours &&
                       this.Minutes == duration.Minutes &&
                       this.Seconds == duration.Seconds &&
                       this.Milliseconds == duration.Milliseconds;
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code representing this instance.
        /// </summary>
        /// <remarks>
        /// This method returns a hash code representing this instance by calling its 
        /// inherited method.
        /// </remarks>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <remarks>
        /// This method returns a string that represents the current object 
        /// in the form of D.HH:MM:SS.MS.
        /// </remarks>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            Double totalDays = this.Millennia * Duration.DaysPerMillennium +
                               this.Centuries * Duration.DaysPerCentury +
                               this.Decades * Duration.DaysPerDecade +
                               this.Years * Duration.DaysPerYear +
                               this.Months * Duration.DaysPerMonth +
                               this.Weeks * Duration.DaysPerWeek +
                               this.Days;

            return String.Format(
                "{0}.{1:00}:{2:00}:{3:00}.{4:####}",
                totalDays, this.Hours, this.Minutes, this.Seconds, this.Milliseconds);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes all properties with their corresponding parts of parameter 
        /// <paramref name="seconds"/>.
        /// </summary>
        /// <remarks>
        /// This method initializes all properties with their corresponding parts 
        /// of parameter <paramref name="seconds"/>.
        /// </remarks>
        /// <param name="seconds">
        /// The number of seconds used for property initialization.
        /// </param>
        /// <exception cref="OverflowException">
        /// This exception is thrown if parameter <paramref name="seconds"/> represents 
        /// a negative or a positive infinite value.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown either if parameter <paramref name="seconds"/> 
        /// represents a NaN value or if parameter <paramref name="seconds"/> is less 
        /// than zero.
        /// </exception>
        private void ApplyFromSeconds(Double seconds)
        {
            this.ValidateSeconds(seconds);

            TimeSpan total = this.TotalDurationFromSeconds(seconds);

            this.Milliseconds = total.Milliseconds;
            this.Seconds = total.Seconds;
            this.Minutes = total.Minutes;
            this.Hours = total.Hours;

            Int32 days = total.Days;

            this.Millennia = Convert.ToInt32(days / Duration.DaysPerMillennium);
            days = days % Duration.DaysPerMillennium;

            this.Centuries = Convert.ToInt32(days / Duration.DaysPerCentury);
            days = days % Duration.DaysPerCentury;

            this.Decades = Convert.ToInt32(days / Duration.DaysPerDecade);
            days = days % Duration.DaysPerDecade;

            this.Years = Convert.ToInt32(days / Duration.DaysPerYear);
            days = days % Duration.DaysPerYear;

            this.Months = Convert.ToInt32(days / Duration.DaysPerMonth);
            days = days % Duration.DaysPerMonth;

            this.Weeks = Convert.ToInt32(days / Duration.DaysPerWeek);
            days = days % Duration.DaysPerWeek;

            this.Days = days;
        }

        /// <summary>
        /// Validates provided number of <paramref name="seconds"/>.
        /// </summary>
        /// <remarks>
        /// This method validates provided number of <paramref name="seconds"/>.
        /// </remarks>
        /// <param name="seconds">
        /// The number of seconds to be validated.
        /// </param>
        /// <exception cref="OverflowException">
        /// This exception is thrown if parameter <paramref name="seconds"/> represents 
        /// a negative or a positive infinite value.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown either if parameter <paramref name="seconds"/> 
        /// represents a NaN value or if parameter <paramref name="seconds"/> is less 
        /// than zero.
        /// </exception>
        private void ValidateSeconds(Double seconds)
        {
            if (Double.IsInfinity(seconds))
            {
                throw new OverflowException("Duration in seconds must not be infinite.");
            }

            if (Double.IsNaN(seconds))
            {
                throw new ArgumentOutOfRangeException(nameof(seconds), "Duration in seconds must not be NaN.");
            }

            if (seconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(seconds), "Duration in seconds must be equal to or greater than zero.");
            }
        }

        /// <summary>
        /// Creates an instance of class <see cref="TimeSpan"/> using provided 
        /// <paramref name="seconds"/> as initial value.
        /// </summary>
        /// <remarks>
        /// As already mentioned, the maximum of supported seconds is limited to 
        /// the total amount of seconds of <see cref="TimeSpan.MaxValue"/>.
        /// </remarks>
        /// <param name="seconds">
        /// The number of seconds to be used as initial value.
        /// </param>
        /// <returns></returns>
        private TimeSpan TotalDurationFromSeconds(Double seconds)
        {
            if (TimeSpan.MaxValue.TotalSeconds <= seconds)
            {
                return TimeSpan.MaxValue;
            }
            else
            {
                return TimeSpan.FromSeconds(seconds);
            }
        }

        #endregion
    }
}
