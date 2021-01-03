/**
 * Employee.cs
 * @Author : Deepthi Warrier
 * @Date: 09/Feb/2020
 * The Model class for the Employee. 
 * The properties thats used to update all the columns of the 
 * Employee Table depending upon the operation performed.
 */

using System;

namespace ADC_HW2.Models
{
    public class Employee
    {
        public int Id
        {
            get; set;
        }
        public String firstName
        {
            get; set;
        }
        public String lastName
        {
            get; set;
        }

        public String phoneNumber
        {
            get; set;
        }

        public String emailId
        {
            get; set;
        }

        public int age
        {
            get; set;
        }
    }
}
