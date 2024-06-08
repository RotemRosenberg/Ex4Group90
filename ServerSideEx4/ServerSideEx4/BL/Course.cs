namespace ServerSideEx4.BL
{
    public class Course
    {
        int id;
        string title;
        string url;
        double rating;
        int numberOfReviews;
        int instructorsId;
        string imageReference;
        double duration;
        string lastUpdate;

        public Course()
        {
        }
        public Course(int id, string title, string url, double rating, int numberOfReviews, int instructorsId, string imageReference, double duration, string lastUpdate)
        {
            Id = id;
            Title = title;
            Url = url;
            Rating = rating;
            NumberOfReviews = numberOfReviews;
            InstructorsId = instructorsId;
            ImageReference = imageReference;
            Duration = duration;
            LastUpdate = lastUpdate;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Url { get => url; set => url = value; }
        public double Rating { get => rating; set => rating = value; }
        public int NumberOfReviews { get => numberOfReviews; set => numberOfReviews = value; }
        public int InstructorsId { get => instructorsId; set => instructorsId = value; }
        public string ImageReference { get => imageReference; set => imageReference = value; }
        public double Duration { get => duration; set => duration = value; }
        public string LastUpdate { get => lastUpdate; set => lastUpdate = value; }

        public void AddCourse(Course course)
        {
            DBservices dbs = new DBservices();
            dbs.InsertCourse(course);
        }
        public static int Delete(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteCourse(id);
        }
    }
}
