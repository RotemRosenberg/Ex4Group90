using ServerSideEx4.BL;
using System;
using System.Data;
using System.Data.SqlClient;

public class DBservices
{

    public DBservices()
    {

    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }


    //--------------------------------------------------------------------------------------------------
    // Courses DB Methods
    //--------------------------------------------------------------------------------------------------


    // insert course
    public int InsertCourse(Course course)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@Title", course.Title);
        paramDic.Add("@Url", course.Url);
        paramDic.Add("@Duration", course.Duration);
        paramDic.Add("@InstructorId", course.InstructorsId);
        paramDic.Add("@Image", course.ImageReference);
        cmd = CreateCommandWithStoredProcedure("SP_CreateCourse", con, paramDic);             // create the command

        try
        {
            int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    // delete course
    public int DeleteCourse(int id)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@CourseId", id);





        cmd = CreateCommandWithStoredProcedure("SP_DeleteCourse", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
                                                     //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //read all courses
    public List<Course> ReadCourse()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedure("SP_ReadCourse", con, null);             // create the command
        List<Course> CoursesList = new List<Course>();
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(dataReader["id"]);
                course.Title = dataReader["title"].ToString();
                course.Url = dataReader["url"].ToString();
                course.Rating = Convert.ToSingle(dataReader["rating"]);
                course.NumberOfReviews = Convert.ToInt32(dataReader["num_reviews"]);
                course.InstructorsId = Convert.ToInt32(dataReader["instructors_id"]);
                course.ImageReference = dataReader["image"].ToString();
                course.Duration = Convert.ToSingle(dataReader["duration"]);
                DateTime Date = Convert.ToDateTime(dataReader["last_update_date"]);
                course.LastUpdate = Date.ToString("dd/MM/yyyy");
                CoursesList.Add(course);
            }
            return CoursesList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //get all courses by rating range
    public List<Course> GetByRatingRange(float minRating, float maxRating)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@minRating", minRating);
        paramDic.Add("@maxRating", maxRating);

        cmd = CreateCommandWithStoredProcedure("SP_SelectByRatingRange", con, paramDic);             // create the command
        List<Course> CoursesList = new List<Course>();
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(dataReader["id"]);
                course.Title = dataReader["title"].ToString();
                course.Url = dataReader["url"].ToString();
                course.Rating = Convert.ToSingle(dataReader["rating"]);
                course.NumberOfReviews = Convert.ToInt32(dataReader["num_reviews"]);
                course.InstructorsId = Convert.ToInt32(dataReader["instructors_id"]);
                course.ImageReference = dataReader["image"].ToString();
                course.Duration = Convert.ToSingle(dataReader["duration"]);
                DateTime Date = Convert.ToDateTime(dataReader["last_update_date"]);
                course.LastUpdate = Date.ToString("dd/MM/yyyy");
                CoursesList.Add(course);
            }
            return CoursesList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }
    //get all courses by duration range
    public List<Course> GetByDurationRange(float minDuration, float maxDuration)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@minDuration", minDuration);
        paramDic.Add("@maxDuration", maxDuration);

        cmd = CreateCommandWithStoredProcedure("SP_SelectByDurationRange", con, paramDic);             // create the command
        List<Course> CoursesList = new List<Course>();
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(dataReader["id"]);
                course.Title = dataReader["title"].ToString();
                course.Url = dataReader["url"].ToString();
                course.Rating = Convert.ToSingle(dataReader["rating"]);
                course.NumberOfReviews = Convert.ToInt32(dataReader["num_reviews"]);
                course.InstructorsId = Convert.ToInt32(dataReader["instructors_id"]);
                course.ImageReference = dataReader["image"].ToString();
                course.Duration = Convert.ToSingle(dataReader["duration"]);
                DateTime Date = Convert.ToDateTime(dataReader["last_update_date"]);
                course.LastUpdate = Date.ToString("dd/MM/yyyy");
                CoursesList.Add(course);
            }
            return CoursesList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }


    //--------------------------------------------------------------------------------------------------
    // instructor DB Methods
    //--------------------------------------------------------------------------------------------------

    //read all Instructors

    public List<Instructor> ReadInstructors()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedure("SP_ReadInstructors", con, null);             // create the command
        List<Instructor> InstructorsList = new List<Instructor>();
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Instructor instructor = new Instructor();
                instructor.Id = Convert.ToInt32(dataReader["id"]);
                instructor.Title = dataReader["title"].ToString();
                instructor.Name = dataReader["name"].ToString();
                instructor.JobTitle = dataReader["jobTitle"].ToString();
                instructor.Image = dataReader["image"].ToString();
                InstructorsList.Add(instructor);
            }
            return InstructorsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    // insert Instructor
    public int InsertInstructor(Instructor instructor)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@Title", instructor.Title);
        paramDic.Add("@Name", instructor.Name);
        paramDic.Add("@jobTitle", instructor.JobTitle);
        paramDic.Add("@Image", instructor.Image);

        cmd = CreateCommandWithStoredProcedure("SP_CreateInstructor", con, paramDic);             // create the command

        try
        {
            int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
   
    // delete Instructor by id

    public int DeleteInstructor(int id)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@InstructorId", id);

        cmd = CreateCommandWithStoredProcedure("SP_DeleteInstructor", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
                                                     //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // get instructor courses DB Method
    //--------------------------------------------------------------------------------------------------

    public List<Course> GetInstructorCourses(int id)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@id", id);

        cmd = CreateCommandWithStoredProcedure("SP_GetInstructorCourses", con, paramDic);             // create the command
        List<Course> CoursesList = new List<Course>();
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(dataReader["id"]);
                course.Title = dataReader["title"].ToString();
                course.Url = dataReader["url"].ToString();
                course.Rating = Convert.ToSingle(dataReader["rating"]);
                course.NumberOfReviews = Convert.ToInt32(dataReader["num_reviews"]);
                course.InstructorsId = Convert.ToInt32(dataReader["instructors_id"]);
                course.ImageReference = dataReader["image"].ToString();
                course.Duration = Convert.ToSingle(dataReader["duration"]);
                DateTime Date = Convert.ToDateTime(dataReader["last_update_date"]);
                course.LastUpdate = Date.ToString("dd/MM/yyyy");
                CoursesList.Add(course);
            }
            return CoursesList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }
    //--------------------------------------------------------------------------------------------------
    // Users DB Method
    //--------------------------------------------------------------------------------------------------
    
    //User Read
    public List<User> ReadUsers()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedure("SP_ReadUsers", con, null);             // create the command
        List<User> UsersList = new List<User>();
        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                User user = new User();
                user.Id = Convert.ToInt32(dataReader["id"]);
                user.Name = dataReader["name"].ToString();
                user.Email = dataReader["email"].ToString();
                user.Password = dataReader["password"].ToString();
                user.IsAdmin = Convert.ToBoolean(dataReader["isAdmin"]);
                user.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                UsersList.Add(user);
            }
            return UsersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //register user
    public int RegisterUser(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@Name", user.Name);
        paramDic.Add("@Email", user.Email);
        paramDic.Add("@Password", user.Password);
        cmd = CreateCommandWithStoredProcedure("SP_RegisterUser", con, paramDic);             // create the command
        try
        {
            int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedure(String spName, SqlConnection con, Dictionary<string, object> paramDic)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        if (paramDic != null)
            foreach (KeyValuePair<string, object> param in paramDic)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);

            }


        return cmd;
    }
}
