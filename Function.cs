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
    public class Function
    {
        public List<Profile> registeredUsers = new List<Profile>();

        Profile user;

        public Function()
        {

        }


        //REGISTER USER
        public void RegisterUser()
        {

            string nameInputted;
            int ageInputted;
            char genderInputted;
            Console.Write("\n=====REGISTER=====\nName: ");
            nameInputted = Console.ReadLine();
            string currentUser;
            bool backToMenu = false;
            if (registeredUsers.Count != 0)
            {
                for (int i = 0; i < registeredUsers.Count; i++)
                {
                    currentUser = registeredUsers[i].ShowName();
                    if (currentUser == nameInputted)
                    {
                        Console.WriteLine("{0} HAS ALREADY BEEN REGISTERED.", nameInputted);
                        backToMenu = true;
                    }

                }


            }


            if (backToMenu == false)
            {

                Console.Write("\nAge: ");

                ageInputted = int.Parse(Console.ReadLine());
                 
                if (ageInputted >= 18)
                {

                    Console.Write("\nGender: ");
                    genderInputted = char.Parse(Console.ReadLine().ToUpper());
                    Console.Write("\nEnter your preferences\nM for MALES, " +
                                      "F for FEMALES\n\nShow Me: ");
                    char gpInputted = char.Parse(Console.ReadLine().ToUpper());

                    Console.Write("\nAge Start: ");
                    int minInputted = int.Parse(Console.ReadLine());

                    if (minInputted >= 18)
                    {


                        Console.Write("\nAge Limit: ");
                        int maxInputted = int.Parse(Console.ReadLine());
                        while (maxInputted < minInputted)
                        {
                            Console.Write("\nAge Limit: ");
                            maxInputted = int.Parse(Console.ReadLine());
                        }

                        user = new Profile(nameInputted, ageInputted, genderInputted, minInputted, maxInputted, gpInputted);
                        registeredUsers.Add(user);
                        int currentRU = registeredUsers.Count;
                        user.SetidNo(currentRU);

                        Console.WriteLine("\n{0} HAS BEEN SUCCESSFULLY REGISTERED.", nameInputted);

                    }
                    else
                    {
                        Console.WriteLine("AGE START IS TOO LOW.");
                    }
                }
                else
                {
                    Console.WriteLine("PERSON IS TOO YOUNG TO JOIN.\n");
                }


            }
        }

        // LOGIN + TINDER MENU

        public void LoginUser()
        {
            string nameInputted;

            Console.WriteLine("\n=====LOGIN=====");
            if (registeredUsers.Count != 0)
            {
                Console.Write("Name: ");
                nameInputted = Console.ReadLine();


                bool successfulLogin = false;
                for (int i = 0; i < registeredUsers.Count; i++)
                {
                    Profile current = registeredUsers[i];

                    if (nameInputted == current.name)
                    {
                        user = current;
                        Console.WriteLine("\nWELCOME, {0}!", current.name);
                        int choice;
                        do
                        {
                            Console.WriteLine("\n=====TINDER MENU=====" +
                                              "\n1 Match" +
                                              "\n2 View Matches" +
                                              "\n3 View People List" +
                                              "\n4 Unmatch" +
                                              "\n5 Edit User Settings" +
                                              "\n6 View Likes" +
                                              "\n0 to LOGOUT");
                            choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    Match(current);
                                    break;
                                case 2:
                                    Console.WriteLine("=====VIEW MATCHES=====");
                                    current.ViewMatches();
                                    break;

                                case 3:
                                    ViewPeopleList();
                                    break;
                                case 4:
                                    Console.WriteLine("=====UNMATCH=====");
                                    UnMatch(current);
                                    break;
                                case 5:
                                    EditUserSettings();
                                    break;
                                case 6:
                                    current.ViewLikesz();
                                    break;

                            }

                        } while (choice != 0);
                        Console.WriteLine("LOGGING OUT...");
                        successfulLogin = true;
                    }




                }
                if (successfulLogin == false)
                {
                    Console.WriteLine("PERSON HAS NOT BEEN REGISTERED.");
                }
            }

            else
            {

                Console.WriteLine("NO ONE HAS REGISTERED YET.");
            }
        }


        // MATCH AND UNMATCH

        public void Match(Profile user)
        {
            if (registeredUsers.Count > 1)
            {
                if (user.numMatches == 10)
                {
                    Console.WriteLine("YOUR MATCHES ARE FULL.");
                }
                else
                {
                    Console.WriteLine("\n=====MATCH=====");
                    Console.WriteLine("Show Me: {0} \nAge Range: {1} - {2}", user.ShowUserGP(),
                                     user.ShowUserMin(), user.ShowUserMax());

                    int numOfLikesAtStart = user.ShowNumLikes();
                    bool someoneLikeable = false;
                    for (int i = 0; i < registeredUsers.Count; i++)
                    {
                        Profile userInRU = registeredUsers[i];
                        bool someoneLiked = false;
                        if ((someoneLiked == false) && ((userInRU.name != user.name) && (userInRU != user) && (userInRU.ShowUserGP() == user.gender) &&
                            (user.ShowUserGP() == userInRU.gender) && (userInRU.age >= user.ShowUserMin() && userInRU.age <= user.ShowUserMax()) &&
                                                        (user.age >= userInRU.ShowUserMin()) && (user.age <= userInRU.ShowUserMax())
                                                        && (user.IsInLikesList(userInRU) == false && user.IsInMatches(userInRU) == false)))
                        {
                            someoneLikeable = true;
                            numOfLikesAtStart += 1;
                            Console.WriteLine("\nName: {0} \nAge: {1} \nGender: {2} \n 1 Like \n 2 No; next \n 3 Exit", userInRU.name, userInRU.age,
                                                          userInRU.gender);
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                //checking if person liked by user has liked the user
                                if (userInRU.likes.Count == 0)
                                {
                                    user.likes.Add(userInRU);
                                    Console.WriteLine("{0} HAS BEEN LIKED!", userInRU.name);

                                }

                                else
                                {
                                    for (int b = 0; b < userInRU.likes.Count; b++)
                                    {
                                        if (user.numMatches < 10)
                                        {
                                            if ((userInRU.likes[b] == user) && (userInRU.numMatches < 10))
                                            {
                                                user.likes.Add(userInRU);
                                                user.AddToMatches(userInRU);
                                                userInRU.AddToMatches(user);

                                                Console.WriteLine("{0} IS A MATCH!", userInRU.name);
                                            }
                                            else if ((userInRU.likes[b] == user) && ((user.numMatches >= 10 || userInRU.numMatches >= 10)))
                                            {
                                                if (user.numMatches >= 10)
                                                {
                                                    Console.WriteLine("YOUR MATCHES ARE FULL.");
                                                }
                                                else if (userInRU.numMatches >= 10)
                                                {
                                                    Console.WriteLine("THIS PERSON'S MATCHES ARE FULL.");
                                                }
                                                user.likes.Add(userInRU);
                                                  
                                            }  
                                            else if (userInRU.likes.Contains(user) == false)
                                            {
												user.likes.Add(userInRU);
												Console.WriteLine("{0} HAS BEEN LIKED!", userInRU.name);
                                            }
                                        
                                        }
                          
                                    }
                                }
                                someoneLiked = true;
                            }



                            else if (choice == 2)
                            {
                                if (i + 1 == registeredUsers.Count)
                                {
                                    Console.WriteLine("NO MORE POTENTIAL MATCHES.");
                                    user.ViewMatches();
                                }
                            }
                            else if (choice == 3)
                            {
                                i = registeredUsers.Count;
                                user.ViewMatches();

                            }
                        }



                    }

                    if (someoneLikeable == false/*i - 1 == registeredUsers.Count && numOfLikesAtStart == user.ShowNumLikes()*/)/*(i == registeredUsers.Count) && (numOfLikesAtStart == user.ShowNumLikes() - 1)*/
                    {
                        Console.WriteLine("\nNO MATCHES AVAILABLE.");
                        numOfLikesAtStart += 1;
                    }
                }
            }



            else
            {

                Console.WriteLine("NO OTHER PEOPLE HAVE BEEN REGISTERED.");
            }
        }

		public void UnMatch(Profile user)
		{
			if (user.numMatches == 0)
			{
				Console.WriteLine("NO MATCHES AVAILABLE.");
			}
			else
			{
				user.ViewMatches();
				Console.Write("Enter ID: ");
				int choice = int.Parse(Console.ReadLine()) - 1;
				bool success = false;
                for (int i = 0; i < user.numMatches; i++)
                {
                    if (choice == i)
                    {
                        for (int b = 0; b < user.matches[i].numMatches; b++)
                        {
                            if (user.matches[i].matches[b] == user)
                            {
                                user.matches[i].likes.Remove(user);
                                user.matches[i].matches[b] = null;
                                user.matches[i].numMatches -= 1;
                                if (user.matches[i].numMatches > 0)
                                {
                                    for (int y = 0; y < user.matches[i].numMatches; y++)
                                    {
                                        if (user.matches[i].matches[b] == null)
                                        {
                                            user.matches[i].matches[b] = user.matches[b + 1];
                                            user.matches[i].matches[b + 1] = null;
                                        }
                                    }
                                }
                            }
                        }
                        user.likes.Remove(user.matches[i]);
                        user.matches[choice] = null;
                        user.numMatches -= 1;
                        success = true;
                    }
                    if (user.numMatches > 0 && success == true)
						{

                            for (int x = 0; x < user.numMatches; x++)
							{
								if (user.matches[choice] == null)
								{
									user.matches[choice] = user.matches[choice + 1];
									user.matches[choice + 1] = null;
								}
							}
						}

						success = true;
					}

				
				if (success == false)
				{
					Console.WriteLine("INVALID ID.");
				}
                else{
					Console.WriteLine("\nTHE MATCH HAS BEEN DELETED.");

				}

			}

		}

        /// VIEWS PEOPLE LIST

        public void ViewPeopleList()
        {
            if (registeredUsers.Count == 1)
            {
                Console.WriteLine("YOUR LIST OF PEOPLE IS EMPTY.");
            }
            else
            {
                Console.WriteLine("=====VIEW PEOPLE LIST=====");
                Console.WriteLine("ID \tNAME \tGENDER \tAGE");
                for (int i = 0; i < registeredUsers.Count; i++)
                {
                    Profile current = registeredUsers[i];
                    if (current.name != user.name)
                    {
                        Console.WriteLine("{0} \t{1} \t  {2} \t{3}", current.idNo, current.name, current.gender, current.age);
                    }

                }
                Console.WriteLine("TOTAL REGISTERED: {0}", registeredUsers.Count);
            }
        }

        // EDIT USER SETTINGS
        public void EditUserSettings()
        {
            Console.WriteLine("\n=====EDIT USER SETTINGS=====");
            Console.WriteLine("Show Me: {0} \nAge Range: {1} - {2}",
                              user.ShowUserGP(), user.ShowUserMin(), user.ShowUserMax());
            Console.WriteLine("1 Change Show Me\n2 Change Age Range");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("M for MALES, F for FEMALES");
                char choice2 = char.Parse(Console.ReadLine().ToUpper());
                user.SetGP(choice2);
                Console.WriteLine("\nSHOW ME SETTINGS HAVE BEEN CHANGED.");

            }

            else if (choice == 2)
            {
                Console.WriteLine("Set Age Start: ");
                int choice3 = int.Parse(Console.ReadLine());
                if (choice3 >= 18)
                {
                    user.SetMin(choice3);
                    Console.WriteLine("Set Age Limit: ");
                    int choice4 = int.Parse(Console.ReadLine());
                    if (choice4 > choice3)
                    {
                        user.SetMax(choice4);
                        Console.WriteLine("\nAGE RAGE HAS CHANGED.");
                    }
                    else
                    {
                        Console.WriteLine("AGE LIMIT IS GREATER THAN AGE START.");
                    }
                }
                else
                {
                    Console.WriteLine("AGE START IS TOO LOW.");
                }

            }

        }


		}
       

    }


