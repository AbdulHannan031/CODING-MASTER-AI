using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coding1
{
    internal class Question
    {
        public (int, string,int) GetQuestion(string language, int userId)
        {
            // Add debugging statement to check the value of the language parameter
            Console.WriteLine("Language parameter: " + language);

            MySqlConnection connection = Program.conn;
            string questionText = "";
            int questionID=0 ;
            int points=0;
            string questionQuery = "SELECT q.QuestionID, q.Language, q.QuestionText, q.Points " +
                                   "FROM question q " +
                                   "WHERE q.Language = @Language " +
                                   "AND NOT EXISTS (SELECT 1 FROM submission s WHERE s.QuestionID = q.QuestionID AND s.UserID = @UserID) " +
                                   "ORDER BY RAND() LIMIT 1";

            try
            {
                connection.Open();
                // Retrieve a question for the given language
                using (MySqlCommand command = new MySqlCommand(questionQuery, connection))
                {
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@UserID", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // Check if any rows are returned
                        {
                            if (reader.Read())
                            {
                                 questionID = reader.GetInt32(0);
                                string languag = reader.GetString(1);
                                questionText = reader.GetString("QuestionText");
                                points = reader.GetInt32(3);
                            }
                        }
                        else
                        {
                            // Handle case where no rows are returned
                            Console.WriteLine("No rows returned for the given language and user ID.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error retrieving question: " + ex.Message);
            }
            finally
            {
                connection.Close();
                
            }
            if(string.IsNullOrEmpty(questionText))
            {
                questionText = "You have completed All Questions for " + language + " language"; 
            }
            // If no question found, return a congratulatory message
            return (questionID,questionText,points);
        }
    }
    }
