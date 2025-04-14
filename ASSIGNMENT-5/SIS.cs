namespace demonew
{
    public class SIS
    {
        public List<Student> Students = new List<Student>();
        public List<Course> Courses = new List<Course>();
        public List<Enrollment> Enrollments = new List<Enrollment>();
        public List<Teacher> Teachers = new List<Teacher>();
        public List<Payment> Payments = new List<Payment>();

        public void EnrollStudentInCourse(Student student, Course course)
        {
            student.EnrollInCourse(course);
            var enrollment = new Enrollment(Enrollments.Count + 1, student, course, DateTime.Now);
            Enrollments.Add(enrollment);
        }

        public void AssignTeacherToCourse(Teacher teacher, Course course)
        {
            course.AssignTeacher(teacher);
        }

        public void RecordPayment(Student student, decimal amount, DateTime paymentDate)
        {
            student.MakePayment(amount, paymentDate);
            Payments.Add(new Payment(Payments.Count + 1, student, amount, paymentDate));
        }

        public void GenerateEnrollmentReport(Course course)
        {
            Console.WriteLine($"\nEnrollment Report for {course.Name}:");
            foreach (var student in course.GetEnrollments())
            {
                Console.WriteLine($"- {student.FirstName} {student.LastName} (ID: {student.StudentId})");
            }
        }

        public void GeneratePaymentReport(Student student)
        {
            Console.WriteLine($"\nPayment Report for {student.FirstName} {student.LastName}:");
            foreach (var payment in student.GetPaymentHistory())
            {
                Console.WriteLine($"- Amount: {payment.AmountPaid}, Date: {payment.PaymentDate.ToShortDateString()}");
            }
        }

        public void CalculateCourseStatistics(Course course)
        {
            int count = course.GetEnrollments().Count;
            decimal total = 0;
            foreach (var student in course.GetEnrollments())
            {
                foreach (var payment in student.GetPaymentHistory())
                {
                    total += payment.AmountPaid;
                }
            }
            Console.WriteLine($"\nStatistics for {course.Name}: Enrollments = {count}, Total Payments = {total}");
        }
    }
}
