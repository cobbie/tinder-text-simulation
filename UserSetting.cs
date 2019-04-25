// Quintos, Jacob Uriel R. // 161613
// 11/14/2017
// I have not discussed the C# language
// code in my program with anyone other than my instructor or the
// teaching assistants assigned to this course.
// I have not used C# language code
// obtained from another person, or any other unauthorized source,
// either modified or unmodified.
// Any C# language code or documentation
// used in my program that was obtained from another source, such as
// a text book, a web page, or another person, have been clearly
// noted with proper citation in the comments of my program.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project1Quintos161613
{
    public class UserSetting
    {
        public int min;
        public int max;
        public char gp;

        public UserSetting(int _min, int _max, char _gp)
        {
            min = _min;
            max = _max;
            gp = _gp;
        }

        // RETURNING OF ATTRIBUTES
        public int ReturnMin()
        {
            return min;
        }
        public int ReturnMax()
        {
            return max;
        }

        public char ReturnGP()
        {
            return gp;
        }

        //SETTING OF ATTRIBUTES
  


        }
    }

