using ForgetTheMilk.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsolVerification
{
    public class CreateTaskTests : AssertionHelper
    {
        [Test]
        public void DescriptionAndNoDueDate()
        {
            var input = "Pickup the groceries";

            var task = new Task(input, default(DateTime));

            Expect(task.Description, Is.EqualTo(input));
            Expect(task.DueDate, Is.EqualTo(null));
        }

        [Test]
        public void MayDueDateDoesWrapYear()
        {
            var input = "Pickup the groceries may 5 - as of 2015-05-31";
            var today = new DateTime(2015, 5, 31);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.EqualTo(new DateTime(2016, 5, 5)));
        }

        [Test]
        public void MayDueDateDoesNotWrapYear()
        {
            var input = "Pickup the groceries may 5 as of 2015-05-04";
            
            var today = new DateTime(2015, 5, 4);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.EqualTo(new DateTime(2015,5,5)));
        }

        [Test]
        public void AprilDueDate()
        {
            var input = "Groceries apr 5";
            var today = new DateTime(2015, 5, 30);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.Not.Null);
            Expect(task.DueDate.Value.Month, Is.EqualTo(4));
        }


    }


}

