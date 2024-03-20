using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
namespace coding1
{
     
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static dbconnection dbconnection = new dbconnection();
        public static MySqlConnection conn = dbconnection.GetConnection();
        public static int id;
        public static string email;
        public static void InsertSubmission(int questionID, int marks, int userID)
        {
            MySqlConnection con = Program.conn;
            // SQL query to insert data into the Submission table
            string query = "INSERT INTO Submission (UserID, QuestionID, Marks, SubmissionTime) VALUES (@UserID, @QuestionID, @Marks, @SubmissionTime)";

            // Current date and time
            DateTime submissionTime = DateTime.Now;

            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                // Add parameters
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@QuestionID", questionID);
                command.Parameters.AddWithValue("@Marks", marks);
                command.Parameters.AddWithValue("@SubmissionTime", submissionTime);

                try
                {
                    // Open connection if it's not already open
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Submission successful
                   MessageBox.Show(marks+" Points  Succesfully added And your next question is on screen");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Points not rewared sorry problem at our end");
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public static int points()
        {
            MySqlConnection con = Program.conn;
            int points = 0;
            // SQL query to insert data into the Submission table
            string query = "SELECT SUM(marks) AS total_marks FROM submission WHERE UserID = @userId"; // Current date and time

            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                // Add parameters
                command.Parameters.AddWithValue("@userId", Program.id);

                try
                {
                    // Open connection if it's not already open
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    // Execute the command and get the total marks
                    object result = command.ExecuteScalar();

                    // Check if the result is not null
                    if (result != null && result != DBNull.Value)
                    {
                        points = Convert.ToInt32(result); // Convert the result to integer
                                                          // Do whatever you want with the points
                                                          // For example, display in a message box
                        
                    }
                    else
                    {
                        points = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching information restart application.");
                }
                finally
                {
                    con.Close();
                }
            }
            return points;

        }
    
        public static async Task<string> GenerateResponse(string question, string answer, string language)
        {
            // Replace 'YOUR_API_KEY' with your actual API key
            string apiKey = "AIzaSyDNGi97FTfDgit2XUw2gUyS9VbCANyX_bc";

            // JSON payload
            string jsonPayload = "{\"contents\":[{\"parts\":[{\"text\":\"" + question + "\n\n Language : " + language + "\r\n\r\n" + answer + "\n\nResponse: check the answer to the question and return is it  correct or not if answer to the question is not correct then return fail" + "\"}]}]}";

            // URL
            Console.WriteLine(jsonPayload);
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=" + apiKey;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Prepare the request content
                    StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // Parse JSON response
                        JObject jsonResponse = JObject.Parse(responseBody);
                        // Extract the generated content
                        string generatedContent = (string)jsonResponse["candidates"][0]["content"]["parts"][0]["text"];

                        // Check if the generated content contains the correct answer
                        Console.WriteLine(generatedContent);
                        if (generatedContent.Contains("correct") || generatedContent.Contains("Correct"))
                            return "Correct";
                        else
                            return "Better luck next time";
                    }
                    else
                    {
                        return "Error: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    return "Exception: " + ex.Message;
                }
            }
        }
        [STAThread]
       
        static void Main()
        {
            
            if(conn == null )
            {
            MessageBox.Show("Check Your Internet and try again Thankyou");

                Application.Exit();
            }
            else {
                


                Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                Form1 form1 = new Form1();
                form1.Show();
               
                Application.Run();            }
        }
    }
}
