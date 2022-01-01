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
using System.Diagnostics;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Dialogs
{
    public partial class SummaryDialog : Form
    {
        #region Private Fields

        // The Designer sucks, for sure! Obviously, it is impossible to just
        // put an additional string into the dialog's resx file. Because such
        // an additional string is deleted each time you add another control
        // or change the dialog in any other way.
        private const String txtContent = @"
<!DOCTYPE html>
<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<meta charset=""utf-8"" />
<title>Summary</title>
<style>
body { font-family: Arial, Helvetica, sans-serif; margin-bottom: 5em; }
p.formula { text-align: center; font-weight: bold; font-size: 1.2em; }
span.formula-single { display: -moz-inline-box; -moz-box-orient: vertical; display: inline-block; vertical-align: middle; margin: -0.2em 0 0 0; padding: 0; }
span.formula-fraction { display: -moz-inline-box; -moz-box-orient: vertical; display: inline-block; vertical-align: middle; margin: -0.5em 0 0 0; padding: 0; }
span.fraction-line { display: block; text-align: center; border-top: solid 1px; margin: 0.1em 0 0 0; padding: 0.1em 0 0 0; }
sub { font-size: 0.8em; }
sup { font-size: 0.8em; }
dt { font-style: oblique; margin-left: 2em; }
dd { padding-bottom: 0.5em; margin-left: 4em; }
li { padding-bottom: 0.5em; }
</style>
</head>
<body>
<h3>Password Entropy</h3>
<p>
The <q>Password Entropy</q> represents a measuring instrument that allows to calculate the difficulty
with which a password can be decrypted. So&ndash;called pools serve as the basis for this calculation,
whereby each pool represents a set of characters. An example of such a pool is the set of all possible
upper case letters.
</p>
<p>
The entropy, in turn, of each pool is nothing else but its length. The other way round, if a particular
password contains at least one character of one of the pools then its entropy is the length of the fitting
pool. The total password entropy is made of the sum of entropies of each of the included pools.
</p>
<p>
Finally, the calculation rule of the password entropy is defined by
</p>
<p class=""formula"">
E = <span class=""formula-single"">log<sub>2</sub>(P<sup>n</sup>)</span> = <span class=""formula-single"">log<sub>2</sub>(P)&nbsp;&times;&nbsp;n</span>
</p>
<p>
with E = Password entropy in <em>Bits</em>, P = Length of pool of unique characters and n = Number of characters
in the password (password length).
</p>
<p>
For the source of the above conclusion see links below:
</p>
<ul>
<li><a href=""https://www.pleacher.com/mp/mlessons/algebra/entropy.html"" target=""_blank"">https://www.pleacher.com/mp/mlessons/algebra/entropy.html</a></li>
<li><a href=""https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy"" target=""_blank"">https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy</a></li>
</ul>
<p>
A final note about usage of <q>Diceware Words List</q> as well as of <q>English Dictionary Words</q>. Both
were intentionally not taken into account in this program.
</p>
<h3>Password Security</h3>
<p>
According to this <a href=""https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy"" title=""https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy"" target=""_blank"">reference</a>,
a particular password might be cracked in &lt;n&gt; seconds These <q>seconds</q> are defined by
</p>
<p class=""formula"">
t
= <span class=""formula-fraction""><span>&nbsp;2<sup>log<sub>2</sub>(P<sup>n</sup>)&nbsp;</sup></span><span class=""fraction-line"">G</span></span>
= <span class=""formula-fraction""><span>&nbsp;2<sup>log<sub>2</sub>(P)&nbsp;&times;&nbsp;n</sup>&nbsp;</span><span class=""fraction-line"">G</span></span>
= <span class=""formula-fraction""><span>&nbsp;2<sup>E</sup>&nbsp;</span><span class=""fraction-line"">G</span></span>
</p>
<p>
with t = Time needed to crack a password in <em>Seconds</em>, E = Password entropy in <em>Bits</em>,
P = Length of pool of unique characters, n = Number of characters in the password (password length) and
G = Number of guesses per second a computer can make (for example 2,800,000,000 guesses per seconds).
</p>
<table>
<tr style=""vertical-align:text-top"">
<td><b>Example</b>:</td>
<td>&nbsp;</td>
<td>
Suppose the password <q>abcdef</q> is used, which just takes the pool of lower case letters. The
number of items in that pool is 26 and the password length 6. This in turn results in an entropy
value of about 28 bits. Furthermore, a computer that can run 1,000,000,000 guesses per second is
assumed, which might be used by some brute&ndash;force algorithm. With these numbers in mind, the
time needed to crack this password would take approximately 0.31 seconds.
</td>
</tr>
</table>
<p>
Replacing just one letter in the above password with its upper letter expression, the time to crack that
new password would take about 19 seconds instead. In contrast to that, appending three more letters of the
same pool would increase the time to crack the password by 1 hour and 30 minutes.
</p>
<p>
The problem here is that the number of <q>guesses per second</q> is indeed an assumption! In the real world
and through the use of powerful GPUs, the time to crack a password can be reduced even further. Against this
background, no reliable statements can be made about how long it takes to crack a password.
</p>
<h3>Password Strength</h3>
<p>
The rating of the strength of passwords is more or less based on experiences with hacked passwords.
In other words, the password strength is nothing else but an estimation of how long it would take to crack a
particular password.
</p>
<p>
In detail the rating of the password strength represents a simple range check of the calculated entropy bits.
Against this background, a password strength might be determined by these characteristics:
</p>
<dl>
<dt>Less than 64 bits.</dt>
<dd>Very weak, might keep out family members.</dd>
<dt>From 64 up to 80 bits.</dt>
<dd>Weak, should keep out most people, often good for desktop login passwords.</dd>
<dt>From 80 up to 112 bits.</dt>
<dd>Reasonable, fairly secure passwords, often good for network and company passwords.</dd>
<dt>From 112 up to 128 bits.</dt>
<dd>Strong, can be good for guarding financial information.</dd>
<dt>Equal to or greater than 128 bits.</dt>
<dd>Very strong, often considered as overkill.</dd>
</dl>
<p>
On the other hand, the rating of the password strength indirectly depends on a particular hacking scenario.
Basically, a distinction can be made between these
three scenarios:
</p>
<dl>
<dt>Online Attack Scenario</dt>
<dd>Assumption of one thousand guesses per second.</dd>
<dt>Offline Fast Attack Scenario</dt>
<dd>Assumption of one hundred billion guesses per second.</dd>
<dt>Massive Cracking Array Scenario</dt>
<dd>Assumption of one hundred trillion guesses per second.</dd>
</dl>
<p>
Further information about password strength can be found on the Internet under:
</p>
<ul>
<li><a href=""https://keepass.info/help/kb/pw_quality_est.html"" target=""_blank"">https://keepass.info/help/kb/pw_quality_est.html</a></li>
<li><a href=""https://www.pleacher.com/mp/mlessons/algebra/entropy.html"" target=""_blank"">https://www.pleacher.com/mp/mlessons/algebra/entropy.html</a></li>
<li><a href=""https://eyhn.github.io/PasswordQualityCalculator"" target=""_blank"">https://eyhn.github.io/PasswordQualityCalculator</a></li>
</ul>
<h3>Further Readings</h3>
<p>
Below please find a list of more interesting information as well as examples.
</p>
<ul>
<li><a href=""http://www.passwordmeter.com"" target=""_blank"">http://www.passwordmeter.com</a></li>
<li><a href=""https://passwordsgenerator.net"" target=""_blank"">https://passwordsgenerator.net</a></li> 
<li><a href=""https://keepass.info/help/base/pwgenerator.html"" target=""_blank"">https://keepass.info/help/base/pwgenerator.html</a></li>
<li><a href=""https://www.gaijin.at/de/tools/password-generator"" target=""_blank"">https://www.gaijin.at/de/tools/password-generator</a></li>
<li><a href=""http://cubicspot.blogspot.com/2011/11/how-to-calculate-password-strength.html?m=1"" target=""_blank"">http://cubicspot.blogspot.com/2011/11/how-to-calculate-password-strength.html?m=1</a></li>
</ul>
</body>
</html>";

        #endregion

        #region Construction

        public SummaryDialog()
            : base()
        {
            this.InitializeComponent();

            this.Icon = Properties.Resources.MainIcon;
        }

        #endregion

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            this.htmContent.NewWindow += this.OnHtmlContentOpenNewWindow;
            this.htmContent.DocumentCompleted += this.OnHtmlContentDocumentCompleted;
            this.htmContent.DocumentText = SummaryDialog.txtContent;
        }

        #region Private Methods

        private void OnHtmlContentDocumentCompleted(Object sender, WebBrowserDocumentCompletedEventArgs args)
        {
            this.Text = this.htmContent.Document.Title;
            this.htmContent.Document.Body.MouseDown += this.OnDocumentBodyMouseDown;
        }

        private void OnDocumentBodyMouseDown(Object sender, HtmlElementEventArgs args)
        {
            try
            {
                if (args.MouseButtonsPressed == MouseButtons.Left)
                {
                    HtmlElement element = this.htmContent.Document.GetElementFromPoint(args.ClientMousePosition);

                    if (element is null) { return; }

                    if (String.Equals(element.TagName, "a", StringComparison.OrdinalIgnoreCase))
                    {
                        Process.Start(element.GetAttribute("href"));
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        private void OnHtmlContentOpenNewWindow(Object sender, CancelEventArgs args)
        {
            // NOTE: The HTML resource uses target="_blank" for external links.
            //       Therefore, suppress standard handling and open all link within
            //       the body click event handler.
            args.Cancel = true;
        }

        private void OnButtonCloseClick(Object sender, EventArgs args)
        {
            this.BeginInvoke((MethodInvoker)delegate { this.Close(); });
        }

        #endregion
    }
}
