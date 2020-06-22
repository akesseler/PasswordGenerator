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
    /// This class represents a hacking scenario with the number of guesses as 
    /// its major information.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The major information this provides is property guesses. This property 
    /// stands for the assumption of how many passwords a hacker's computer can 
    /// process per second.
    /// </para>
    /// <para>
    /// Furthermore, this class provides some default scenarios, which all are 
    /// inspired by this side 
    /// <a href="https://www.grc.com/haystack.htm">https://www.grc.com/haystack.htm</a>.
    /// </para>
    /// </remarks>
    public class Scenario
    {
        #region Private Fields

        /// <summary>
        /// This field represents the name of a scenario.
        /// </summary>
        /// <remarks>
        /// The scenario name may shortly describe a particular scenario.
        /// </remarks>
        private String name = null;

        /// <summary>
        /// This field represents the text of a scenario.
        /// </summary>
        /// <remarks>
        /// The scenario text may describe in detail a particular scenario.
        /// </remarks>
        private String text = null;

        /// <summary>
        /// This field represents the note of a scenario.
        /// </summary>
        /// <remarks>
        /// The scenario note can be used to provide additional information.
        /// </remarks>
        private String note = null;

        /// <summary>
        /// This field represents the number of guesses of a scenario.
        /// </summary>
        /// <remarks>
        /// The number of guesses is always an assumption.
        /// </remarks>
        private Double guesses = 0d;

        #endregion

        #region Public Fields

        /// <summary>
        /// This field represents a standard online attack.
        /// </summary>
        /// <remarks>
        /// Such a standard online attack assumes about 1,000 guesses per second.
        /// </remarks>
        public static Scenario OnlineAttack;

        /// <summary>
        /// This field represents a offline fast attack.
        /// </summary>
        /// <remarks>
        /// Such a offline fast attack assumes about 100,000,000,000 guesses per 
        /// second.
        /// </remarks>
        public static Scenario OfflineFastAttack;

        /// <summary>
        /// This field represents a massive cracking attack.
        /// </summary>
        /// <remarks>
        /// Such a massive cracking attack assumes about 100,000,000,000,000 guesses 
        /// per second.
        /// </remarks>
        public static Scenario MassiveCrackingAttack;

        #endregion

        #region Construction

        /// <summary>
        /// Static construction.
        /// </summary>
        /// <remarks>
        /// This constructor just initializes all static class fields.
        /// </remarks>
        static Scenario()
        {
            Scenario.OnlineAttack = new Scenario(
                "Online Attack Scenario",
                "Assumption of one thousand guesses per second.",
                1000);

            Scenario.OfflineFastAttack = new Scenario(
                "Offline Fast Attack Scenario",
                "Assumption of one hundred billion guesses per second.",
                100000000000);

            Scenario.MassiveCrackingAttack = new Scenario(
                "Massive Cracking Array Scenario",
                "Assumption of one hundred trillion guesses per second.",
                100000000000000);
        }

        /// <summary>
        /// Default construction.
        /// </summary>
        /// <remarks>
        /// This constructor just initializes property <see cref="Note"/>. All other 
        /// properties are not initialized.
        /// </remarks>
        public Scenario()
        {
            this.Note = "Note that typical attacks will be online password guessing limited to, at most, a few hundred guesses per second.";
        }

        /// <summary>
        /// Parameterized construction.
        /// </summary>
        /// <remarks>
        /// This constructor initializes all properties with the values of provided 
        /// parameters.
        /// </remarks>
        /// <param name="name">
        /// The name of the scenario.
        /// </param>
        /// <param name="text">
        /// The text of the scenario.
        /// </param>
        /// <param name="guesses">
        /// The number of guesses of the scenario.
        /// </param>
        public Scenario(String name, String text, Double guesses)
            : this()
        {
            this.Name = name;
            this.Text = text;
            this.Guesses = guesses;
        }

        /// <summary>
        /// Parameterized construction.
        /// </summary>
        /// <remarks>
        /// This constructor initializes all properties with the values of provided 
        /// parameters.
        /// </remarks>
        /// <param name="name">
        /// The name of the scenario.
        /// </param>
        /// <param name="text">
        /// The text of the scenario.
        /// </param>
        /// <param name="note">
        /// An additional note of the scenario.
        /// </param>
        /// <param name="guesses">
        /// The number of guesses of the scenario.
        /// </param>
        /// <seealso cref="Scenario(String, String, Double)"/>
        public Scenario(String name, String text, String note, Double guesses)
            : this(name, text, guesses)
        {
            this.Note = note;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets and sets the name of the scenario.
        /// </summary>
        /// <remarks>
        /// This property allows to get and set the name of the scenario.
        /// </remarks>
        /// <value>
        /// The name of the scenario.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown if the name to set is null, empty or consists 
        /// only of whitespaces.
        /// </exception>
        public String Name
        {
            get
            {
                return this.name ?? String.Empty;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Name), "Name must not be null or empty or consist only of white spaces.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets and sets the text of the scenario.
        /// </summary>
        /// <remarks>
        /// This property allows to get and set the text of the scenario.
        /// </remarks>
        /// <value>
        /// The text of the scenario.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown if the text to set is null, empty or consists 
        /// only of whitespaces.
        /// </exception>
        public String Text
        {
            get
            {
                return this.text ?? String.Empty;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Text), "Text must not be null or empty or consist only of white spaces.");
                }

                this.text = value;
            }
        }

        /// <summary>
        /// Gets and sets the note of the scenario.
        /// </summary>
        /// <remarks>
        /// This property allows to get and set the note of the scenario.
        /// </remarks>
        /// <value>
        /// The note of the scenario.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown if the note to set is null, empty or consists 
        /// only of whitespaces.
        /// </exception>
        public String Note
        {
            get
            {
                return this.note;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Note), "Note must not be null or empty or consist only of white spaces.");
                }

                this.note = value;
            }
        }

        /// <summary>
        /// Gets and sets the number of guesses per second a computer can make.
        /// </summary>
        /// <remarks>
        /// This property allows to define the number of guesses per second a 
        /// computer can make. The value of this property strongly influences 
        /// the calculation result. Therefore, this value should be used very 
        /// carefully.
        /// </remarks>
        /// <value>
        /// The number of guesses per second a computer can make.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown if the number of guesses is less than or equal 
        /// to zero.
        /// </exception>
        public Double Guesses
        {
            get
            {
                return this.guesses;
            }
            set
            {
                if (value <= 0d)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Guesses), "Number of guesses per second must be greater than zero.");
                }

                this.guesses = value;
            }
        }

        #endregion

        #region Public Methods
        
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
            return String.Format("{0} ({1})", this.name, this.guesses.ToString("N0"));
        }

        #endregion
    }
}
