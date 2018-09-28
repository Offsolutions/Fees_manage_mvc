using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFeeManage.Areas.Auth.Models
{
    public class Home
    {

    }
    public class tblstudentdata
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int rollno { get; set; }
        [Required]
        public string name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dob { get; set; }
        public string fathername { get; set; }
        [AllowHtml]
        public string address { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string phone { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string fatherphn { get; set; }
        public string language { get; set; }
        public string board { get; set; }
        public string qualification { get; set; }
        public string coaching { get; set; }
        public string institutename { get; set; }
        public string type { get; set; }
        public string refferedby { get; set; }
        public string image { get; set; }
        public string uid { get; set; }
        public bool Status { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string remarks { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "You must provide a valid email address.")]
        public string email { get; set; }
        public string discount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> date { get; set; }

    }
    public enum gender
    {
        Male,
        Female
    }
    public enum board
    {
        CBSE,
        PSEB,
        ICSE,
        Other
    }
    public enum type
    {
        AC,
        GT
    }
    public class Fees_Master
    {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public int TotalFees { get; set; }
        public int PaidFees { get; set; }
        //public string CourseId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AlertDate { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string discount { get; set; }
        public bool Status { get; set; }
    }
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Fees { get; set; }
        //public virtual ICollection<Student_Course> Student_Course { get; set; }
    }
    //public class Student_Course
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public int RollNo { get; set; }
    //    public string CourseId { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public Nullable<System.DateTime> Admitdate { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public Nullable<System.DateTime> enddate { get; set; }
    //    public string Fees { get; set; }
    //    public string Uid { get; set; }
    //    public int RoomId { get; set; }
    //    public bool Status { get; set; }

    //}

    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public int CourseId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Admitdate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> enddate { get; set; }
        public string Fees { get; set; }
        public string Uid { get; set; }
        public int RoomId { get; set; }
        public bool Status { get; set; }

    }
    public class Recipt_Details
    {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string CourseId { get; set; }
        public string ReciptNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date { get; set; }
        public int Amount { get; set; }
        public bool Active { get; set; }
    }
    public class tblReceipt
    {
        [Key]
        public int Id { get; set; }
        public string Start_no { get; set; }
        public string End_no { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date { get; set; }
        public string Current_Recipt { get; set; }
        public bool Status { get; set; }
    }
    public class tblroom
    {
        [Key]
        public int RoomId { get; set; }
        public string room { get; set; }
        public bool status { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
    public class tblreceptionist
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public string name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "You must provide a valid email address.")]
        public string email { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string contact { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string rid { get; set; }
        public string image { get; set; }
        public string Type { get; set; }
        public bool status { get; set; }
    }

    public class tblinquiry
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public string inquiryid { get; set; }
        [Required]
        public string name { get; set; }
        public string fname { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string contact { get; set; }
        public string address { get; set; }
        public string referedby { get; set; }
        public string CourseId { get; set; }
        public bool status { get; set; }
    }
    public class tblfeedback
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public string inquiryid { get; set; }
        public string feedback { get; set; }
        public int days { get; set; }
        public string type { get; set; }
        public string nextfollow { get; set; }
        public string status { get; set; }
        public string loginid { get; set; }
    }
}