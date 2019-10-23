using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{   /*
    Klasė parodyti regex
    ^ - patterno pradžia
    $ - patterno pabaiga
    [] - skliausteliai nurodyti simbolius
    [a-z] - nuo kokio iki kokio simbolio
    {} - skliausteliai nurodyti ilgį
    {3} - griežtas maksimalus ilgis
    {1,3} - ilgis nuo 1 iki 3
    () - skliausteliai nurodyti grupei
    (com|org|lt) - bus arba com arba org arba lt
    [a-z]{3} - non rigid expression
    ^[a-z]{3}$ - rigid expression
    CBD principas - CARROT (^) , BRACKET ([],{}), DOLLAR($)
     ^[a-z]{3}[0-9]{3}$ patternas bus 3 raides nuo a iki z ir trys skaiciai nu 0 iki 9
     ^[a-zA-Z]{3}$ patternas paims ir didziasias ir mazasias raides
     ^www.[a-zA-Z0-9].(com|org|lt)$ patternas websitu pavadinimam
     ^[a-z0-9]@(gmail|yahoo|lk|yandex).(com|lt|ru)$

    (?<word>\w+)	Match one or more word characters up to a word boundary. Name this captured group word.
    \s+	            Match one or more white-space characters.
    (\k<word>)	    Match the captured group that is named word.
    + - one or more
    * - zero or more
    ? - zero or one

    // Define a regular expression for repeated words.
        Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Define a test string.        
        string text = "The the quick brown fox  fox jumps over the lazy dog dog.";
        
        // Find matches.
        MatchCollection matches = rx.Matches(text);

        // Report the number of matches found.
        Console.WriteLine("{0} matches found in:\n   {1}", 
                          matches.Count, 
                          text);

        // Report on each match.
        foreach (Match match in matches)
        {
            GroupCollection groups = match.Groups;
            Console.WriteLine("'{0}' repeated at positions {1} and {2}",  
                              groups["word"].Value, 
                              groups[0].Index, 
                              groups[1].Index);
        }
        
    }
    
}
// The example produces the following output to the console:
//       3 matches found in:
//          The the quick brown fox  fox jumps over the lazy dog dog.
//       'The' repeated at positions 0 and 4
//       'fox' repeated at positions 20 and 25
//       'dog' repeated at positions 50 and 54

    */
    public partial class RegexForm : Form
    {
        public RegexForm()
        {
            InitializeComponent();
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            Regex obj = new Regex(textBoxPattern.Text);
            MessageBox.Show(obj.IsMatch(textBoxData.Text).ToString());
        }
    }
}
