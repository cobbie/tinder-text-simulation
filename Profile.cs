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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project1Quintos161613
{
    public class Profile
    {
        // ATTRIBUTES
		public int age;
		public char gender;
        public string name;

        UserSetting userSettingz;
        public Profile[] matches = new Profile[10];
        public List<Profile> likes = new List<Profile>();
        public List<Profile> hasBeenLiked = new List<Profile>(); 

        public int numMatches = 0;
        public int idNo;
        public int matchNo;

        public Profile (string nameInputted, int ageInputted, char genderInputted, int minInputted, int maxInputted, char gpInputted)
        {
            
            name = nameInputted;
            age = ageInputted;
            gender = genderInputted;
            userSettingz = new UserSetting(minInputted, maxInputted, gpInputted);
        }


        //SHOW ATTRIBUTES 
		public char ShowUserGP()
        {
            return userSettingz.gp;
        }
		public int ShowUserMin()
		{
			return userSettingz.min;
		}
		public int ShowUserMax()
		{
			return userSettingz.max;
		}
        public string ShowName()
        {
            return name;
        }
        public int ShowNumLikes()
        {
            return likes.Count;
        }


        //ADDING TO MATCHES AND ADDING TO LIKES
        public void AddToMatches(Profile users)
        {
            if (numMatches < 10)
            {
                    matches[numMatches] = users;
                numMatches += 1;
                likes.Remove(users);
            }
            else 
            {
                Console.WriteLine("YOUR MATCHES ARE FULL.");
            }
        }

        public void AddToLikes(Profile user)
        {
            for (int i = 0; i < likes.Count; i++)
            {
                Profile userSearched = likes.ElementAt(i);
                if (user == userSearched && i <= likes.Count)
                {
                    Console.WriteLine(" ");
                }
                else 
                {
                    AddToLikes(user);
                    Console.WriteLine("{0} HAS BEEN LIKED!", userSearched.name);
                }

            }
        }

        // CHECKS IF A CERTAIN USER IS IN LIKES/MATCHES

        public bool IsInLikesList(Profile userChecked)
        {
            bool check = false;
            for (int i = 0; i < likes.Count; i++)
            {
				var current = likes.ElementAt(i);
                if (current == userChecked)
                {
                    check = true;
                }
            }
            return check;
        }
        public bool IsInMatches(Profile userChecked)
        {
			bool check = false;
			for (int i = 0; i < numMatches; i++)
			{
				var current = matches[i];
				if (current == userChecked)
				{
					check = true;
				}
			}
			return check;
        }
      



        
        //VIEWING MATCHES AND LIKES
		public void ViewMatches()
		{
			if (numMatches > 0)
			{
				Console.WriteLine("ID \tNAME \tGENDER \tAGE");
				for (int i = 0; i < numMatches; i++)
			{
                    Console.WriteLine("{0} \t{1} \t  {2} \t{3}", i + 1, matches.ElementAt(i).name, 
                                      matches.ElementAt(i).gender, matches.ElementAt(i).age);
                }
                Console.WriteLine("TOTAL MATCHES: {0}", numMatches);
            }
            else
            {
                Console.WriteLine("YOU HAVE NO MATCHES.");
            }
		}

		public void ViewLikesz()
		{
			Console.WriteLine("=====VIEW LIKES=====");

            if (likes.Count > 0)
            {
                Console.WriteLine("ID \tNAME \tGENDER \tAGE");
                for (int i = 0; i < likes.Count; i++)
                {
                    Console.WriteLine("{0} \t{1} \t  {2} \t{3}", likes.ElementAt(i).idNo, likes.ElementAt(i).name,
                                      likes.ElementAt(i).gender, likes.ElementAt(i).age);
                }
                Console.WriteLine("TOTAL LIKES: {0}", likes.Count);
            }
            else 
            {
                Console.WriteLine("YOU HAVE NO LIKES.");
            }
		}



        //SETTING OF CERTAIN ATTRIBUTES
		public void SetMin(int _min)
		{
            userSettingz.min = _min;
		}

		public void SetMax(int _max)
		{
			userSettingz.max = _max;

		}
		public void SetGP(char _gp)
		{
         
			userSettingz.gp = _gp;

		}
        public void SetidNo(int id)
        {
            idNo = id;
        }



	}
}
